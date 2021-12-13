using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.DTO.Employee;
using FastFood.Services.Interfaces;

namespace FastFood.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;

        public EmployeeService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void Register(RegisterEmployeeDto dto)
        {
            Employee employee = this.mapper.Map<Employee>(dto);

            this.dbContext.Employees.Add(employee);
            this.dbContext.SaveChanges();
        }

        public ICollection<ListAllEmployeesDto> All()
            => dbContext.Employees
                .ProjectTo<ListAllEmployeesDto>(this.mapper.ConfigurationProvider)
                .ToList();
    }
}
