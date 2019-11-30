namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Dtos.Export;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Import
            this.CreateMap<ImportSuppliersDto, Supplier>();
            this.CreateMap<ImportPartsDto, Part>();
            this.CreateMap<ImportCustomerDto, Customer>();
            this.CreateMap<ImportSalesDto, Sale>();

            //Export
            this.CreateMap<Car, ExportCarsDistancesDto>();
            this.CreateMap<Car, ExportBMWsDto>();
        }
    }
}
