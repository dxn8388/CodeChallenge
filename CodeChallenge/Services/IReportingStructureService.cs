using System.Collections.Generic;
using CodeChallenge.Models;

namespace CodeChallenge.Services
{
    public interface IReportingStructureService
    {
        List<Employee> GetReportingStructure(Employee employee);
    }
}
