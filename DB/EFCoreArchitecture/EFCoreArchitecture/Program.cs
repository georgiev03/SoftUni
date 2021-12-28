using System;
using System.Threading.Tasks;
using EFCoreArchitecture.Core.Contracts;
using EFCoreArchitecture.Core.Services;
using EFCoreArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreArchitecture
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<SoftUniContext>(opt =>
                    opt.UseSqlServer("Server=.,1433;Database=SoftUni;User Id=sa;Password=Jorkata03"))
                .AddScoped<ISoftUniRepository, SoftUniRepository>()
                .AddScoped<IEmployeeService, EmployeeService>()
                .BuildServiceProvider();

            var employeeService = serviceProvider.GetService<IEmployeeService>();
            var employee = await employeeService.GetEmployeeWithHighestSalary();

            Console.WriteLine($"{employee.FirstName} {employee.LastName}: {employee.Salary:f2}");
        }
    }
}
