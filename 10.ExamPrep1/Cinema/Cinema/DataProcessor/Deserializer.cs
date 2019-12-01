namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Cinema.Data.Models;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var movies = JsonConvert.DeserializeObject<Movie[]>
                (jsonString);

            var sb = new StringBuilder();
            List<Movie> moviesToAdd = new List<Movie>();
            foreach (var movie in movies)
            {

                if (!IsValid(movie) || movies.Count(m => m.Title == movie.Title) != 1)
                {
                    sb.AppendLine(ErrorMessage);
                } 
                else
                {
                    sb.AppendFormat(SuccessfulImportMovie, movie.Title, movie.Genre, $"{movie.Rating:f2}");
                    sb.AppendLine();
                    moviesToAdd.Add(movie);
                }
            }

            context.Movies.AddRange(moviesToAdd);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallsDto = JsonConvert.DeserializeObject<ImportSeatsHallsDto[]>
                (jsonString);

            var sb = new StringBuilder();
            List<Seat> seats = new List<Seat>();
            List<Hall> halls = new List<Hall>();
            foreach (var hallDto in hallsDto)
            {
                
                if (!IsValid(hallDto) || hallDto.Seats <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                }
                else
                {
                    sb.AppendFormat(SuccessfulImportHallSeat, hallDto.Name, 
                        $"{(hallDto.Is4Dx == true ? "4Dx" : "")}" +
                        $"{(hallDto.Is3D == true && hallDto.Is4Dx == true ? "/" : string.Empty)}{(hallDto.Is3D == true || hallDto.Is4Dx == true ? string.Empty : "Normal")}" +
                        $"{(hallDto.Is3D == true ? "3D" : "")}", hallDto.Seats);
                    sb.AppendLine(); 

                    var hall = new Hall
                    {
                        Name = hallDto.Name,
                        Is3D = hallDto.Is3D,
                        Is4Dx = hallDto.Is4Dx
                    };
                    for (int i = 0; i < hallDto.Seats; i++)
                    {
                        Seat seat = new Seat
                        {
                            Hall = hall
                        };
                        hall.Seats.Add(seat);
                        seats.Add(seat);
                    }

                    halls.Add(hall);
                }
            }

            context.AddRange(halls);
            context.AddRange(seats);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportProjectionDto[]),
                new XmlRootAttribute("Projections"));

            ImportProjectionDto[] projectionDtos;

            using (var reader = new StringReader(xmlString))
            {
                projectionDtos = (ImportProjectionDto[])
                    serializer.Deserialize(reader);
            }

            var projections = Mapper.Map<Projection[]>(projectionDtos);
            List<Projection> projectionsToAdd = new List<Projection>();
            var sb = new StringBuilder();
            foreach (var projection in projections)
            {
                if (!IsValid(projection) 
                    || context.Movies.Any(m => m.Id == projection.MovieId) == false
                    || context.Halls.Any(m => m.Id == projection.HallId) == false)
                {
                    sb.AppendLine(ErrorMessage);
                }
                else
                {
                    var movieTitle = context
                        .Movies
                        .First(x => x.Id == projection.MovieId);
                    sb.AppendFormat(SuccessfulImportProjection, movieTitle.Title, 
                        projection.DateTime.ToString(@"MM/dd/yyyy"));
                    sb.AppendLine();
                    projectionsToAdd.Add(projection);
                }
            }

            context.Projections.AddRange(projectionsToAdd);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var serilizar = new XmlSerializer(typeof(ImportCustomersTicketsDto[]),
                new XmlRootAttribute("Customers"));

            var customers = new List<Customer>();
            var tickets = new List<Ticket>();
            ImportCustomersTicketsDto[] dtos;

            using (var reader = new StringReader(xmlString))
            {
                dtos = (ImportCustomersTicketsDto[])
                    serilizar.Deserialize(reader);
            }

            var sb = new StringBuilder();
            foreach (var customerWithItems in dtos)
            {
                if (!IsValid(customerWithItems))
                {
                    sb.AppendLine(ErrorMessage);
                }

                else
                {
                    foreach (var ticket in customerWithItems.Tickets)
                    {
                        if (!IsValid(customerWithItems))
                        {
                            sb.AppendLine(ErrorMessage);
                            return sb.ToString().TrimEnd();
                        }
                    }

                    Customer customer = new Customer
                    {
                        FirstName = customerWithItems.FirstName,
                        LastName = customerWithItems.LastName,
                        Age = customerWithItems.Age,
                        Balance = customerWithItems.Balance
                    };

                    for (int i = 0; i < customerWithItems.Tickets.Length; i++)
                    {
                        Ticket ticket = new Ticket
                        {
                            ProjectionId = customerWithItems.Tickets[i].ProjectionId,
                            Price = customerWithItems.Tickets[i].Price,
                        };

                        customer.Tickets.Add(ticket);
                        tickets.Add(ticket);
                    }

                    customers.Add(customer);
                    sb.AppendFormat(SuccessfulImportCustomerTicket, customer.FirstName,
                        customer.LastName, customer.Tickets.Count);
                    sb.AppendLine();
                }
            }

            context.Customers.AddRange(customers);
            context.Tickets.AddRange(tickets);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, validationContext, results, true);

            return isValid;
        }
    }
}