using CodeChallenge.Services;
using CodeChallenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CodeChallenge.Controllers
{
    [Route("api/reportingStructure")]
    [ApiController]
    public class ReportingStructureController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IEmployeeService _employeeService;
        private readonly IReportingStructureService _reportingStructureService;

        public ReportingStructureController(ILogger<EmployeeController> logger,
            IEmployeeService employeeService,
            IReportingStructureService reportingStructureService)
        {
            _logger = logger;
            _employeeService = employeeService;
            _reportingStructureService = reportingStructureService;
        }

        [HttpGet("{id}", Name = "getReportingStructure")]
        public IActionResult GetReportingStructure(String id)
        {
            _logger.LogDebug($"Received reporting structure get request for '{id}'");

            var employee = _employeeService.GetById(id);
            
            if (employee == null)
                return NotFound();

            var reportingStructure = new ReportingStructure(employee);

            if (reportingStructure == null)
                return NotFound();

            return Ok(reportingStructure);

        }
    }
}
