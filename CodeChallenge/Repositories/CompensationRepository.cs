using CodeChallenge.Data;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Repositories
{
    public class CompensationRepository : ICompensationRepository
    {
        private readonly EmployeeContext _employeeContext;

        private readonly ILogger<ICompensationRepository> _logger;
        public CompensationRepository(ILogger<ICompensationRepository> logger, EmployeeContext employeeContext) {
            _employeeContext = employeeContext;
            _logger = logger;
        }
        public Compensation Create(Compensation compensation)
        {
            compensation.CompensationId = Guid.NewGuid().ToString();
            _employeeContext.Compensations.Add(compensation);
            return compensation;
        }

        public Compensation Read(string id)
        {
            return _employeeContext.Compensations.SingleOrDefault(c => c.CompensationId == id);
        }

        public List<Compensation> ReadByEmployeeID(string empID)
        {
            return _employeeContext.Compensations.Where(c => c.employeeId == empID).ToList();
        }

        public Task SaveAsync()
        {
            return  _employeeContext.SaveChangesAsync();
        }
    }
}
