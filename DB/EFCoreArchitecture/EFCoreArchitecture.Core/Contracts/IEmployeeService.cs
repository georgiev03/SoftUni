using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EFCoreArchitecture.Core.Models;
using EFCoreArchitecture.Infrastructure.Data.Models;

namespace EFCoreArchitecture.Core.Contracts
{
    public interface IEmployeeService
    {
        Task<EmployeeModel> GetEmployeeWithHighestSalary();
    }
}
