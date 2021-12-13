using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbContext = new ProductShopContext();

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //var usersAsString = File.ReadAllText("Datasets/users.xml");
            //var productsAsString = File.ReadAllText("Datasets/products.xml");
            //var categoriesAsString = File.ReadAllText("Datasets/categories.xml");
            //var categoriesProductsAsString = File.ReadAllText("Datasets/categories-products.xml");

            //Console.WriteLine(ImportUsers(dbContext, usersAsString));
            //Console.WriteLine(ImportProducts(dbContext, productsAsString));
            //Console.WriteLine(ImportCategories(dbContext, categoriesAsString));
            //Console.WriteLine(ImportCategoryProducts(dbContext, categoriesProductsAsString));

            Console.WriteLine(GetProductsInRange(dbContext));
        }

        //Problem 1
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = GenerateXmlSerializer("Users", typeof(ImportUsersDto[]));

            StringReader sr = new StringReader(inputXml);

            var usersDto = (ImportUsersDto[])xmlSerializer.Deserialize(sr);

            ICollection<User> users = new HashSet<User>();

            foreach (var userDto in usersDto)
            {
                var user = new User()
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Age = userDto.Age
                };

                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Problem 2
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = GenerateXmlSerializer("Products", typeof(ImportProductDto[]));

            StringReader sr = new StringReader(inputXml);
            var productsDto = (ImportProductDto[])xmlSerializer.Deserialize(sr);

            ICollection<Product> products = new HashSet<Product>();

            foreach (var productDto in productsDto)
            {
                Product p = new Product()
                {
                    Name = productDto.Name,
                    Price = decimal.Parse(productDto.Price),
                    SellerId = productDto.SellerId,
                    BuyerId = productDto.BuyerId
                };

                products.Add(p);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Problem 3
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = GenerateXmlSerializer("Categories", typeof(ImportCategoryDto[]));

            StringReader sr = new StringReader(inputXml);
            var categoriesDto = (ImportCategoryDto[])xmlSerializer.Deserialize(sr);

            ICollection<Category> categories = new HashSet<Category>();

            foreach (var categoryDto in categoriesDto)
            {
                if (categoryDto.Name is null)
                {
                    continue;
                }

                var c = new Category()
                {
                    Name = categoryDto.Name
                };

                categories.Add(c);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Problem 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = GenerateXmlSerializer("CategoryProducts", typeof(ImportCategoryProductDto[]));

            StringReader sr = new StringReader(inputXml);
            var catProductsDto = (ImportCategoryProductDto[])xmlSerializer.Deserialize(sr);

            ICollection<CategoryProduct> categoryProducts = new HashSet<CategoryProduct>();

            foreach (var categoryProductDto in catProductsDto)
            {
                Product p = context.Products.Find(categoryProductDto.ProductId);
                Category c = context.Categories.Find(categoryProductDto.CategoryId);

                if (c is null || p is null)
                {
                    continue;
                }

                var catProd = new CategoryProduct()
                {
                    Category = c,
                    Product = p
                };

                categoryProducts.Add(catProd);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Problem 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            var sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            var xmlSerializer = GenerateXmlSerializer("Products", typeof(ExportProductsInRangeDto[]));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ExportProductsInRangeDto()
                {
                    Name = p.Name,
                    Price = p.Price.ToString(),
                    BuyerName = $"{p.Buyer.FirstName} {p.Buyer.LastName}",
                })
                .Take(10)
                .ToArray();

            xmlSerializer.Serialize(sw, products, namespaces);

            return sb.ToString().Trim();
        }

        //Problem 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            var sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            var xmlSerializer = GenerateXmlSerializer("Users", typeof(ExportUsersWithSoldProductsDto[]));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var users = context
                .Users
                .Include(u => u.ProductsSold)
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new ExportUsersWithSoldProductsDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Products = u.ProductsSold
                        .Select(sp => new GetSoldProductDto()
                        {
                            Name = sp.Name,
                            Price = sp.Price.ToString()
                        })
                        .ToArray()
                })
                .Take(5)
                .ToArray();

            xmlSerializer.Serialize(sw, users, namespaces);

            return sb.ToString().Trim();
        }

        //Problem 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var sb = new StringBuilder();
            StringWriter sr = new StringWriter(sb);

            var xmlSerializer = GenerateXmlSerializer("Categories", typeof(ExportCategoryAndProductsCountDto[]));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var categories = context
                .Categories
                .Select(c => new ExportCategoryAndProductsCountDto()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice =
                        (c.CategoryProducts.Average(cp => cp.Product.Price)).ToString(),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price).ToString()
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => decimal.Parse(c.TotalRevenue))
                .ToArray();

            xmlSerializer.Serialize(sr, categories, namespaces);

            return sb.ToString().Trim();
        }

        //Problem 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            var xmlSerializer = GenerateXmlSerializer("Users", typeof(ExportUserWithProductsCount[]));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var users = context
                .Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportUserWithProductsCount()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = u.ProductsSold.Select(p => new ProductsSoldDto()
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                            .Select(ps => new ProductsOutputDto()
                            {
                                Name = ps.Name,
                                Price = ps.Price.ToString()
                            }).ToArray()
                    }).ToArray()

                })
                .Take(10)
                .ToArray();

            xmlSerializer.Serialize(sw, users, namespaces);

            return sb.ToString().Trim();
        }

        private static XmlSerializer GenerateXmlSerializer(string rootName, Type dtoType)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);

            XmlSerializer xmlSerializer = new XmlSerializer(
                dtoType, xmlRoot);

            return xmlSerializer;
        }
    }
}