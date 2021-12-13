using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO.Inputs;
using CarDealer.DTO.Outputs;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;
        private static JsonSerializerSettings jsonSettings;

        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var suppliersAsJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //var partsAsJson = File.ReadAllText("../../../Datasets/parts.json");
            //var carsAsJson = File.ReadAllText("../../../Datasets/cars.json");
            //var customersAsJson = File.ReadAllText("../../../Datasets/customers.json");
            //var salesAsJson = File.ReadAllText("../../../Datasets/sales.json");

            //Console.WriteLine(ImportSuppliers(context, suppliersAsJson));
            //Console.WriteLine(ImportParts(context, partsAsJson));
            //Console.WriteLine(ImportCars(context, carsAsJson));
            //Console.WriteLine(ImportCustomers(context, customersAsJson));
            //Console.WriteLine(ImportSales(context, salesAsJson));

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        //Problem 9
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<ICollection<SupplierInputDto>>(inputJson);

            InitialiseMapper();
            var mappedSuppliers = mapper.Map<ICollection<Supplier>>(suppliers);

            context.Suppliers.AddRange(mappedSuppliers);
            context.SaveChanges();

            return $"Successfully imported {mappedSuppliers.Count()}.";
        }

        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<ICollection<PartInputDto>>(inputJson);

            InitialiseMapper();
            var mappedParts = mapper.Map<ICollection<Part>>(parts)
                .Where(p => p.SupplierId >= 1 && p.SupplierId <= context.Suppliers.Count());

            context.Parts.AddRange(mappedParts);
            context.SaveChanges();

            return $"Successfully imported {mappedParts.Count()}.";
        }

        //Problem 11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<ICollection<CarInputDto>>(inputJson);

            InitialiseMapper();
            List<Car> mappedCars = new List<Car>();

            foreach (var carJson in cars)
            {
                var car = mapper.Map<Car>(carJson);

                foreach (var partId in carJson.PartsId.Distinct())
                {
                    car.PartCars.Add(new PartCar()
                    {
                        CarId = car.Id,
                        PartId = partId
                    });
                }
                mappedCars.Add(car);
            }


            context.Cars.AddRange(mappedCars);
            context.SaveChanges();

            return $"Successfully imported {mappedCars.Count}.";
        }

        //Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customersJson = JsonConvert.DeserializeObject<ICollection<CustomerInputDto>>(inputJson);

            InitialiseMapper();
            var customers = mapper.Map<ICollection<Customer>>(customersJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        //Problem 13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<ICollection<SaleInputDto>>(inputJson);

            InitialiseMapper();
            var mappedSales = mapper.Map<ICollection<Sale>>(sales);

            context.Sales.AddRange(mappedSales);
            context.SaveChanges();

            return $"Successfully imported {mappedSales.Count}.";
        }

        //Problem 14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver
                });

            // SetUpJsonSettings();
            var customersAsJson = JsonConvert.SerializeObject(customers, jsonSettings);

            return customersAsJson;
        }

        //Problem 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Where(c => c.Make == "Toyota")
                .Select(c => new ToyotaOutputDto
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();
            SetUpJsonSettings();
            var carsAsJson = JsonConvert.SerializeObject(cars, jsonSettings);

            return carsAsJson;
        }

        //Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            var suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<LocalSuppliersDto>(mapperConfig)
                .ToList();

            SetUpJsonSettings();
            var suppliersAsJson = JsonConvert.SerializeObject(suppliers, jsonSettings);

            return suppliersAsJson;
        }

        //Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context
                .Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c.PartCars
                        .Select(p => new
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price.ToString("f2")
                        })
                });

            SetUpJsonSettings();
            var carsAsJson = JsonConvert.SerializeObject(carsWithParts, jsonSettings);

            return carsAsJson;
        }

        //Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            SetUpJsonSettings();
            var customersAsJson = JsonConvert.SerializeObject(customers, jsonSettings);

            return customersAsJson;
        }

        //Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount.ToString("f2"),
                    price = s.Car.PartCars.Sum(pc => pc.Part.Price).ToString("f2"),
                    priceWithDiscount = (s.Car.PartCars.Sum
                        (pc => pc.Part.Price) * (1 - (s.Discount / 100))).ToString("f2"),
                })
                .Take(10)
                .ToList();

            SetUpJsonSettings();
            var salesAsJson = JsonConvert.SerializeObject(sales, jsonSettings);

            return salesAsJson;
        }

        private static void SetUpJsonSettings()
        {
            jsonSettings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver(),
                Formatting = Formatting.Indented,
            };
        }

        private static void InitialiseMapper()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = new Mapper(mapperConfig);
        }
    }
}