using CodeChallenge.Models;
using CodeChallenge.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CodeChallenge.Services
{
    public class ReportingStructureService : IReportingStructureService

    {
        private readonly ILogger<ReportingStructureService> _logger;

        public ReportingStructureService(ILogger<ReportingStructureService> logger)
        {
        
            _logger = logger;
        }
        public List<Employee> GetReportingStructure(Employee employee)
        {
            return employee.DirectReports;               
        }
    }
}
