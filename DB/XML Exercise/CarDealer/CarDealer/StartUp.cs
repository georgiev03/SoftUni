using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using CarDealer.Data;
using CarDealer.DTO.ExportDto;
using CarDealer.DTO.ImportDto;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbContext = new CarDealerContext();

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //var suppliersString = File.ReadAllText("Datasets/suppliers.xml");
            //var partsString = File.ReadAllText("Datasets/parts.xml");
            //var carsString = File.ReadAllText("Datasets/cars.xml");
            //var customersString = File.ReadAllText("Datasets/customers.xml");
            //var salesString = File.ReadAllText("Datasets/sales.xml");

            //Console.WriteLine(ImportSuppliers(dbContext, suppliersString));
            //Console.WriteLine(ImportParts(dbContext, partsString));
            //Console.WriteLine(ImportCars(dbContext, carsString));
            //Console.WriteLine(ImportCustomers(dbContext, customersString));
            //Console.WriteLine(ImportSales(dbContext, salesString));

            Console.WriteLine(GetSalesWithAppliedDiscount(dbContext));
        }

        //Problem 9
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlRoot = new XmlRootAttribute("Suppliers");

            var xmlSerializer = new XmlSerializer(
                typeof(ImportSupplierDto[]), xmlRoot);

            using StringReader strReader = new StringReader(inputXml);

            ImportSupplierDto[] dtos = (ImportSupplierDto[])
                xmlSerializer.Deserialize(strReader);

            ICollection<Supplier> suppliers = new HashSet<Supplier>();
            foreach (var supplierDto in dtos)
            {
                Supplier s = new Supplier()
                {
                    Name = supplierDto.Name,
                    IsImporter = bool.Parse(supplierDto.IsImporter)
                };

                suppliers.Add(s);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}"; ;
        }

        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Parts");

            XmlSerializer xmlSerializer = new XmlSerializer(
                typeof(ImportPartDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            var partDtos = (ImportPartDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Part> parts = new HashSet<Part>();

            foreach (var part in partDtos)
            {
                Supplier supplier = context
                    .Suppliers
                    .Find(part.SupplierId);

                if (supplier is null)
                {
                    continue;
                }

                Part p = new Part()
                {
                    Name = part.Name,
                    Price = decimal.Parse(part.Price),
                    Quantity = part.Quantity,
                    Supplier = supplier
                };

                parts.Add(p);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}"; ;
        }

        //Problem 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Cars");

            XmlSerializer xmlSerializer = new XmlSerializer(
                typeof(ImportCarDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            var carsDto = (ImportCarDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Car> cars = new HashSet<Car>();

            foreach (var carDto in carsDto)
            {
                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TraveledDistance
                };

                ICollection<PartCar> currCarParts = new HashSet<PartCar>();

                foreach (var partIdDto in carDto.Parts.Select(p => p.Id).Distinct())
                {
                    var part = context.Parts.Find(partIdDto);

                    if (part is null)
                    {
                        continue;
                    }

                    PartCar partCar = new PartCar()
                    {
                        Car = car,
                        Part = part
                    };
                    currCarParts.Add(partCar);
                }

                car.PartCars = currCarParts;
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Customers");

            XmlSerializer xmlSerializer = new XmlSerializer(
                typeof(ImportCustomerDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            var customersDto = (ImportCustomerDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Customer> customers = new HashSet<Customer>();

            foreach (var c in customersDto)
            {
                var customer = new Customer()
                {
                    Name = c.Name,
                    BirthDate = DateTime.Parse(c.BirthDate),
                    IsYoungDriver = c.IsYoungDriver
                };

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        //Problem 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Sales");

            XmlSerializer xmlSerializer = new XmlSerializer(
                typeof(ImportSaleDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            var salesDto = (ImportSaleDto[])xmlSerializer.Deserialize(stringReader);
            ICollection<Sale> sales = new HashSet<Sale>();

            foreach (var s in salesDto)
            {
                var car = context.Cars.Find(s.CarId);

                if (car is null)
                {
                    continue;
                }

                var sale = new Sale()
                {
                    Car = car,
                    CustomerId = s.CustomerId,
                    Discount = decimal.Parse(s.Discount)
                };

                sales.Add(sale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //Problem 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var sb = new StringBuilder();
            using StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer xmlSerializer =
                GenerateXmlSerializer("cars", typeof(ExportCarsWithDistanceDto[]));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var carsDtos = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new ExportCarsWithDistanceDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance.ToString()
                })
                .ToArray();


            xmlSerializer.Serialize(stringWriter, carsDtos, namespaces);

            return sb.ToString().Trim();
        }

        //Problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            var xmlSerializer = GenerateXmlSerializer("cars", typeof(ExportBmwDto[]));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var cars = context
                .Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ExportBmwDto()
                {
                    Id = c.Id.ToString(),
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance.ToString()
                })
                .ToArray();

            xmlSerializer.Serialize(writer, cars, namespaces);

            return sb.ToString().Trim();
        }

        //Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlSerializer xmlSerializer = GenerateXmlSerializer("suppliers", typeof(ExportLocalSupplierDto[]));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSupplierDto()
                {
                    Id = s.Id.ToString(),
                    Name = s.Name,
                    PartsCount = s.Parts.Count.ToString()
                })
                .ToArray();

            xmlSerializer.Serialize(writer, suppliers, namespaces);

            return sb.ToString().Trim();
        }

        //Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            var xmlSerializer = GenerateXmlSerializer("cars", typeof(ExportCarWithPartsDto[]));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var cars = context
                .Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Select(c => new ExportCarWithPartsDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance.ToString(),
                    Parts = c.PartCars
                        .OrderByDescending(p => p.Part.Price)
                        .Select(pc => new ExportPartForCarDto()
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price.ToString()
                        })
                        .ToArray()
                })
                .Take(5)
                .ToArray();

            xmlSerializer.Serialize(writer, cars, namespaces);

            return sb.ToString().Trim();
        }

        //Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            var xmlSerializer = GenerateXmlSerializer("customers", typeof(ExportBuyerInfoDto[]));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var customers = context
                .Customers
                .ToArray()
                .Where(c => c.Sales.Any())
                .Select(c => new ExportBuyerInfoDto()
                {
                    FullName = c.Name,
                    BoughtCarsCount = c.Sales.Count.ToString(),
                    MoneySpent = c.Sales
                        .ToArray()
                        .Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c => c.MoneySpent)
                .ToArray();

            xmlSerializer.Serialize(writer, customers, namespaces);

            return sb.ToString().Trim();
        }

        //Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            var xmlSerializer = GenerateXmlSerializer("sales", typeof(ExportSalesWithDiscountDto[]));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var sales = context
                .Sales
                .Select(s => new ExportSalesWithDiscountDto()
                {
                    Car = new ExportCarsWithDistanceDto()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance.ToString()
                    },
                    Discount = s.Discount.ToString(CultureInfo.InvariantCulture),
                    CustomerName = s.Customer.Name,
                    Price = (s.Car.PartCars.Sum(pc => pc.Part.Price)).ToString(CultureInfo.InvariantCulture),
                    PriceWithDiscount =
                        (s.Car.PartCars.Sum(pc => pc.Part.Price) * (1 - s.Discount / 100)).ToString(CultureInfo.InvariantCulture)
                })
                .ToArray();

            xmlSerializer.Serialize(writer, sales, namespaces);

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