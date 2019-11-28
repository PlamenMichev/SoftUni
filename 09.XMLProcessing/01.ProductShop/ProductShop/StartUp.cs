namespace ProductShop
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    using ProductShop.Data;
    using ProductShop.Models;
    using ProductShop.Dtos.Import;
    using ProductShop.Dtos.Export;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.Xml.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
                                    cfg.AddProfile<ProductShopProfile>());
            using (var db = new ProductShopContext())
            {
                
                var result = GetUsersWithProducts(db);
                Console.WriteLine(result);
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(List<ImportUserDto>),
                new XmlRootAttribute("Users"));

            List<ImportUserDto> userDtos;

            using (var reader = new StringReader(inputXml))
            {
                userDtos = (List<ImportUserDto>)
                    serializer.Deserialize(reader);
            }


            var users = Mapper.Map<List<User>>(userDtos);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportProductDto[]),
                new XmlRootAttribute("Products"));

            ImportProductDto[] productDtos;

            using (var reader = new StringReader(inputXml))
            {
                productDtos = (ImportProductDto[])
                    serializer.Deserialize(reader);
            }

            var products = Mapper.Map<Product[]>(productDtos);
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportCategoryDto[]),
                new XmlRootAttribute("Categories"));

            ImportCategoryDto[] categoryDtos;

            using (var reader = new StringReader(inputXml))
            {
                categoryDtos = (ImportCategoryDto[])
                    serializer.Deserialize(reader);
            }

            var categories = Mapper.Map<Category[]>(categoryDtos);
            categories = categories
                .Where(c => c.Name != null)
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportCategoryProductDto[]),
                new XmlRootAttribute("CategoryProducts"));

            ImportCategoryProductDto[] productCategoriesDtos;

            using (var reader = new StringReader(inputXml))
            {
                productCategoriesDtos = (ImportCategoryProductDto[])
                    serializer.Deserialize(reader);
            }

            var categoriesProdcucts = Mapper.Map<CategoryProduct[]>(productCategoriesDtos);
            categoriesProdcucts = categoriesProdcucts
                .Where(pc => context.Products.Any(p => p.Id == pc.ProductId) &&
                        context.Categories.Any(c => c.Id == pc.CategoryId))
                .ToArray();

            context.CategoryProducts.AddRange(categoriesProdcucts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProdcucts.Length}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var serializer = new XmlSerializer(typeof(List<ExportProductsInRangeDto>),
                new XmlRootAttribute("Products"));

            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .ProjectTo<ExportProductsInRangeDto>()
                .OrderBy(p => p.Price)
                .Take(10)
                .ToList();

            var result = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var writer = new StringWriter(result))
            {
                serializer.Serialize(writer, productsInRange, namespaces);
            }

            return result.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .ProjectTo<ExportUserProductsDto>()
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.LastName)
                .Take(5)
                .ToList();

            var serializer = new XmlSerializer(typeof(List<ExportUserProductsDto>),
                new XmlRootAttribute("Users"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, users, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new ExportCategoryDto
                {
                    Name = c.Name,
                    ProductsCount = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts
                                        .Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts
                                        .Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.ProductsCount)
                .ThenBy(c => c.TotalRevenue)
                .ToList();

            var serializer = new XmlSerializer(typeof(List<ExportCategoryDto>),
                new XmlRootAttribute("Categories"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, categories, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(b => b.Buyer != null))
                .Select(u => new ExportDetailedUsersDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportProductsArrayDto
                    {
                        Count = u.ProductsSold
                            .Where(b => b.Buyer != null)
                            .Count(),
                        Products = u.ProductsSold
                                    .Where(b => b.Buyer != null)
                                    .Select(p => new ExportProdoctsByUserDto
                                    {
                                        Name = p.Name,
                                        Price = p.Price
                                    })
                                    .OrderByDescending(p => p.Price)
                                    .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .Take(10)
                .ToList();

            var serializer = new XmlSerializer(typeof(ExportUsersAndProductsDto),
                new XmlRootAttribute("Users"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var result = new ExportUsersAndProductsDto
            {
                Count = context.Users.Where(u => u.ProductsSold.Any(b => b.Buyer != null)).Count(),
                Users = users
            };

            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, result, namespaces);
            }

            return sb.ToString().Trim();
        }
    }
}