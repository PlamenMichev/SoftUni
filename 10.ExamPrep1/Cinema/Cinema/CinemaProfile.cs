using AutoMapper;
using Cinema.Data.Models;
using Cinema.DataProcessor.ImportDto;
using System;
using System.Globalization;

namespace Cinema
{
    public class CinemaProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public CinemaProfile()
        {
            this.CreateMap<ImportProjectionDto, Projection>()
                .ForMember(x => x.DateTime, y => y.MapFrom(z => DateTime.ParseExact(z.DateTime, "yyyy-MM-dd HH:mm:ss",
                                                                                        CultureInfo.InvariantCulture)));
        }
    }
}
