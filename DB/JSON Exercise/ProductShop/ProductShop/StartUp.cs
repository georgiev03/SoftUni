using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions.Impl;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dtos.Input;
using ProductShop.Dtos.Output;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;
        private static JsonSerializerSettings jsonSettings;

        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var usersJsonAsString = File.ReadAllText("../../../Datasets/users.json");
            //var productsJsonAsString = File.ReadAllText("../../../Datasets/products.json");
            //var categoriesJsonAsString = File.ReadAllText("../../../Datasets/categories.json");
            //var categoriesProductsJsonAsString = File.ReadAllText("../../../Datasets/categories-products.json");

            //Console.WriteLine(ImportUsers(context, usersJsonAsString));
            //Console.WriteLine(ImportProducts(context, productsJsonAsString));
            //Console.WriteLine(ImportCategories(context, categoriesJsonAsString));
            //Console.WriteLine(ImportCategoryProducts(context, categoriesProductsJsonAsString));

            Console.WriteLine(GetUsersWithProducts(context));
        }

        //Problem 1
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IEnumerable<UserInputDto> users = JsonConvert.DeserializeObject<IEnumerable<UserInputDto>>(inputJson);

            InitializeMapper();

            var mappedUsers = mapper.Map<IEnumerable<User>>(users);

            context.Users.AddRange(mappedUsers);
            context.SaveChanges();

            return $"Successfully imported {mappedUsers.Count()}";
        }

        //Problem 2
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<ProductInputDto> products = JsonConvert
                .DeserializeObject<IEnumerable<ProductInputDto>>(inputJson);

            InitializeMapper();

            var mappedProducts = mapper.Map<IEnumerable<Product>>(products);

            context.Products.AddRange(mappedProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedProducts.Count()}";
        }

        //Problem 3
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoryInputDto> categories = JsonConvert
                .DeserializeObject<IEnumerable<CategoryInputDto>>(inputJson)
                .Where(x => !x.Name.IsNullOrEmpty());

            InitializeMapper();

            var mappedCategories = mapper.Map<IEnumerable<Category>>(categories);

            context.Categories.AddRange(mappedCategories);
            context.SaveChanges();

            return $"Successfully imported {mappedCategories.Count()}";
        }

        //Problem 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert
                .DeserializeObject<IEnumerable<CategoryProductInputDto>>(inputJson);

            InitializeMapper();

            var mappedCatProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoryProducts);

            context.CategoryProducts.AddRange(mappedCatProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedCatProducts.Count()}";
        }

        //Problem 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            var result = context.Products
                .Include(p => p.Seller)
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .ToList();

            InitializeMapper();
            var mappedProducts = mapper.Map<IEnumerable<ProductOutputDto>>(result);

            SettingUpJson();
            var jsonResult = JsonConvert.SerializeObject(mappedProducts, jsonSettings);

            return jsonResult;
        }

        //Problem 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            var people = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(ps=> new
                        {
                            Name = ps.Name,
                            Price = ps.Price,
                            BuyerFirstName = ps.Buyer.FirstName,
                            BuyerLastName = ps.Buyer.LastName
                        })
                });

            SettingUpJson();

            var soldProductsAsJsonString = JsonConvert.SerializeObject(people, jsonSettings);

            return soldProductsAsJsonString;
        }

        //Problem 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(p => p.Product.Price).ToString("f2"),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price).ToString("f2")
                })
                .OrderByDescending(c => c.ProductsCount)
                .ToList();

            SettingUpJson();

            var categoriesAsJsonString = JsonConvert.SerializeObject(categories, jsonSettings);
            return categoriesAsJsonString;
        }

        //Problem 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context
                .Users
                .Include(u => u.ProductsSold)
                .Where(u => u.ProductsSold.Any())
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold
                            .Count(ps => ps.BuyerId != null),
                        Products = u.ProductsSold
                            .Where(b => b.BuyerId !=null)
                            .Select(ps =>new
                            {
                                Name = ps.Name,
                                Price = ps.Price.ToString("f2")
                            })
                    }
                });

            var usersWithCount = new
            {
                UsersCount = usersWithProducts.Count(),
                Users = usersWithProducts
            };

            SettingUpJson();

            var usersWithProductsAsJson = JsonConvert.SerializeObject(usersWithCount, jsonSettings);

            return usersWithProductsAsJson;
        }

        private static void SettingUpJson()
        {
            jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public static void InitializeMapper()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = new Mapper(mapperConfig);
        }
    }
}