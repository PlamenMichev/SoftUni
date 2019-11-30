namespace CarDealer
{
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;

    using CarDealer.Data;
    using CarDealer.Dtos.Import;
    using System.IO;
    using AutoMapper;
    using CarDealer.Models;
    using System.Linq;
    using CarDealer.Dtos.Export;
    using AutoMapper.QueryableExtensions;
    using System.Text;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x => x.AddProfile<CarDealerProfile>());
            using (var db = new CarDealerContext())
            {
                var result = GetSalesWithAppliedDiscount(db);
                Console.WriteLine(result);
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(List<ImportSuppliersDto>),
                new XmlRootAttribute("Suppliers"));

            List<ImportSuppliersDto> supplierDtos;
            using (var reader = new StringReader(inputXml))
            {
                supplierDtos = (List<ImportSuppliersDto>)
                    serializer.Deserialize(reader);
            }

            var suppliers = Mapper.Map<Supplier[]>(supplierDtos);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportPartsDto[]),
                new XmlRootAttribute("Parts"));

            ImportPartsDto[] partDtos;
            using (var reader = new StringReader(inputXml))
            {
                partDtos = (ImportPartsDto[])
                    serializer.Deserialize(reader);
            }

            var parts = Mapper.Map<Part[]>(partDtos);
            parts = parts
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportCarsDto[]),
                new XmlRootAttribute("Cars"));

            ImportCarsDto[] carDtos;
            using (var reader = new StringReader(inputXml))
            {
                carDtos = (ImportCarsDto[])
                    serializer.Deserialize(reader);
            }


            var parts = new List<PartCar>();
            var cars = new List<Car>();

            foreach (var car in carDtos)
            {
                Car currentCar = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                var currentParts = car.PartsId
                                    .Select(p => p.Id)
                                    .Where(p => context.Parts.Any(pc => pc.Id == p))
                                    .Distinct();

                foreach (var part in currentParts)
                {
                    PartCar currentPart = new PartCar()
                    {
                        PartId = part,
                        Car = currentCar
                    };

                    parts.Add(currentPart);
                }

                cars.Add(currentCar);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportCustomerDto[]),
                new XmlRootAttribute("Customers"));

            ImportCustomerDto[] customerDtos;

            using (var reader = new StringReader(inputXml))
            {
                customerDtos = (ImportCustomerDto[])
                    serializer.Deserialize(reader);
            }

            var customers = Mapper.Map<Customer[]>(customerDtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportSalesDto[]),
                new XmlRootAttribute("Sales"));

            ImportSalesDto[] saleDtos;
            using (var reader = new StringReader(inputXml))
            {
                saleDtos = (ImportSalesDto[])
                    serializer.Deserialize(reader);
            }

            var sales = Mapper.Map<Sale[]>(saleDtos);

            sales = sales
                .Where(s => context.Cars.Any(c => c.Id == s.CarId))
                .ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var serializer = new XmlSerializer(typeof(ExportCarsDistancesDto[]),
                new XmlRootAttribute("cars"));

            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .ProjectTo<ExportCarsDistancesDto>()
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, cars, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var bmws = context.Cars
                .Where(c => c.Make == "BMW")
                .ProjectTo<ExportBMWsDto>()
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportBMWsDto[]),
                new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, bmws, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSuppliersDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportLocalSuppliersDto[]),
                new XmlRootAttribute("suppliers"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, suppliers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Select(c => new ExportCarDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                                .Select(pc => new ExportPartsForCarDto
                                {
                                    Name = pc.Part.Name,
                                    Price = pc.Part.Price
                                })
                                .OrderByDescending(pc => pc.Price)
                                .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportCarDto[]),
                new XmlRootAttribute("cars"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, carsWithParts, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new ExportCustomerDto
                {
                    Name = c.Name,
                    BoughtCars = c.Sales.Count,
                    MoneySpent = c.Sales
                                    .Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c => c.MoneySpent)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportCustomerDto[]),
                new XmlRootAttribute("customers"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, customers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new ExportSaleDto
                {
                    Car = new ExportCarForSaleDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars
                                .Sum(x => x.Part.Price),
                    PriceWithDiscount = s.Car.PartCars
                                .Sum(x => x.Part.Price) - s.Discount * s.Car.PartCars
                                .Sum(x => x.Part.Price) / 100
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportSaleDto[]),
                new XmlRootAttribute("sales"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, sales, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}