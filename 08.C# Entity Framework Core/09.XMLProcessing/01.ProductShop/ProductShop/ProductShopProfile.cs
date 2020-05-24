using AutoMapper;
using ProductShop.Dtos.Import;
using ProductShop.Dtos.Export;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //Import
            this.CreateMap<ImportUserDto, User>();
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<ImportCategoryDto, Category>();
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();

            //Export
            this.CreateMap<Product, ExportProductsInRangeDto>()
                .ForMember(x => x.Buyer, y => y.MapFrom(p => $"{p.Buyer.FirstName} {p.Buyer.LastName}"));
            this.CreateMap<Product, ExportProdoctsByUserDto>();
            this.CreateMap<User, ExportUserProductsDto>()
                .ForMember(x => x.Products, y => y.MapFrom(z => z.ProductsSold));
            this.CreateMap<Category, ExportCategoryDto>();
            this.CreateMap<User, ExportDetailedUsersDto>();

        }
    }
}
