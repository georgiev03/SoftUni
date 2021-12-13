using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            Console.WriteLine(RemoveTown(context));
        }
        //Problem 3
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        //Problem 4
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context
                .Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return sb.ToString();
        }

        //Problem 5
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    Name = e.FirstName + " " + e.LastName,
                    Department = e.Department.Name,
                    e.Salary
                })
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.Name} from {e.Department} - ${e.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        //Problem 6
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(newAddress);

            var nakovEmployee = context
                .Employees
                .First(e => e.LastName == "Nakov");

            nakovEmployee.Address = newAddress;

            context.SaveChanges();

            var sb = new StringBuilder();
            var employees = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => new
                {
                    Address = e.Address.AddressText
                })
                .Take(10);

            foreach (var e in employees)
            {
                sb.AppendLine(e.Address);
            }

            return sb.ToString();
        }

        //Problem 7
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var empProj = context
                .Employees
                .Where(e => e.EmployeesProjects
                    .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    EmpName = e.FirstName + " " + e.LastName,
                    MngName = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(ep => new
                    {
                        ProjName = ep.Project.Name,
                        ProjStartDate = ep.Project.StartDate,
                        ProjEndDate = ep.Project.EndDate
                    })
                })
                .Take(10)
                .ToList();

            foreach (var e in empProj)
            {
                sb.AppendLine($"{e.EmpName} - Manager: {e.MngName}");

                foreach (var proj in e.Projects)
                {
                    string startDate = proj.ProjStartDate.ToString("M/d/yyyy h:mm:ss tt");
                    string endDate = proj.ProjEndDate.HasValue ?
                        proj.ProjEndDate.Value.ToString("M/d/yyyy h:mm:ss tt")
                            : "not finished";
                    sb.AppendLine($"--{proj.ProjName} - {startDate} - {endDate}");
                }
            }

            return sb.ToString();
        }

        //Problem 8
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var addresses = context
                .Addresses
                .Select(a => new
                {
                    Count = a.Employees.Count,
                    Town = a.Town.Name,
                    AddressText = a.AddressText
                })
                .OrderByDescending(a => a.Count)
                .ThenBy(a => a.Town)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.Town} - {a.Count} employees");
            }

            return sb.ToString();
        }

        //Problem 9
        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employee = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    Name = e.FirstName + " " + e.LastName,
                    JobTitle = e.JobTitle,
                    Projects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjName = ep.Project.Name,
                        })
                        .OrderBy(ep => ep.ProjName).ToList()
                })
                .Single();

            sb.AppendLine($"{employee.Name} - {employee.JobTitle}");
            foreach (var p in employee.Projects)
            {
                sb.AppendLine(p.ProjName);
            }

            return sb.ToString();
        }

        //Problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var departments = context
                .Departments
                .Include(d => d.Employees)
                .Include(d => d.Manager)
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .ToList();

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.Name} - {d.Manager.FirstName} {d.Manager.LastName}");

                foreach (var e in d.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return sb.ToString();
        }

        //Problem 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    Name = p.Name,
                    Desc = p.Description,
                    StartDate = p.StartDate
                })
                .OrderBy(p => p.Name)
                .ToList();

            foreach (var p in projects)
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Desc);
                sb.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }

            return sb.ToString().Trim();
        }

        //Problem 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e =>
                    e.Department.Name == "Engineering" ||
                    e.Department.Name == "Tool Design" ||
                    e.Department.Name == "Marketing" ||
                    e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName);

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary * 1.12m:f2})");
            }

            return sb.ToString();
        }

        //Problem 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var emp = context
                .Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var e in emp)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString();
        }

        //Problem 14
        public static string DeleteProjectById(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var proj = context.Projects.Find(2);

            var empProjs = context
                .EmployeesProjects
                .Where(p => p.ProjectId == 2)
                .ToList();

            context.EmployeesProjects.RemoveRange(empProjs);
            context.Projects.Remove(proj);
            context.SaveChanges();

            foreach (var p in context.Projects.Take(10))
            {
                sb.AppendLine(p.Name);
            }

            return sb.ToString();
        }

        //Problem 15
        public static string RemoveTown(SoftUniContext context)
        {
            const string townToDelete = "Seattle";
            Town town= context.Towns.First(t => t.Name == townToDelete);

            var addressesToDelete = context
                .Addresses
                .Where(a => a.Town.Name == townToDelete)
                .ToList();

            var empWithNoAddress = context
                .Employees
                .Where(e => addressesToDelete.Contains(e.Address))
                .ToList();

            foreach (var employee in empWithNoAddress)
            {
                employee.AddressId = null;
            }

            context.Addresses.RemoveRange(addressesToDelete);
            context.Towns.Remove(town);
            context.SaveChanges();

            return $"{addressesToDelete.Count()} addresses in Seattle were deleted";
        }
    }
}
