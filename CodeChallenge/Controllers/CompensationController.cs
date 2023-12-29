using CodeChallenge.Models;
using CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace CodeChallenge.Controllers
{

    [Route("api/compensation")]
    [ApiController]
    public class CompensationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IEmployeeService _employeeService;
        private readonly ICompensationService _compensationService;

        public CompensationController(ILogger<CompensationController> logger,
            IEmployeeService employeeService,
            ICompensationService compensationService)
        {
            _compensationService = compensationService;
            _employeeService = employeeService;
            _logger = logger;

        }

        [HttpPost]
        public IActionResult CreateCompensation([FromBody] CompensationInput compensationInput)
        {
            _logger.LogDebug($"Received compensation create request for employee '{compensationInput.employeeId}'");

            var compensation = new Compensation();
            var employee = _employeeService.GetById(compensationInput.employeeId);
            if (employee != null)
            {
                compensation.employee = employee;
                compensation.effectiveDate = compensationInput.effectiveDate;
                compensation.salary = compensationInput.salary;
                _compensationService.Create(compensation);
            }

            return CreatedAtRoute("getCompensationById", new { id = compensation.CompensationId }, compensation);
        }

        [HttpGet("{id}", Name = "getCompensationById")]
        public IActionResult GetCompensationById(String id)
        {
            _logger.LogDebug($"Received compensation get request for compensation id: '{id}'");

            var compensation = _compensationService.Read(id);

            if (compensation == null)
                return NotFound();

            return Ok(compensation);
        }

        [HttpGet("byEmployee/{id}", Name = "getCompensationEmployeeById")]
        public IActionResult GetCompensationEmployeeById(String id)
        {
            _logger.LogDebug($"Received compensation get request for employee id: '{id}'");

            Compensation compensation = _compensationService.ReadByEmployeeId(id)
                .OrderByDescending(x => x.effectiveDate)
                .FirstOrDefault();

            if (compensation == null)
            {
                return NotFound();
            }
            else
            {
                var employee = _employeeService.GetById(id);
                compensation.employee = employee;
                return Ok(compensation);
            }

        }
    }
}
