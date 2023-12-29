using CodeChallenge.Models;
using CodeChallenge.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CodeChallenge.Services
{
    public class CompensationService : ICompensationService
    {

        private readonly ICompensationRepository _compensationRepository;
        private readonly ILogger<CompensationService> _logger;

        public CompensationService(ILogger<CompensationService> logger, ICompensationRepository compensationRepository) {
            _compensationRepository = compensationRepository;
            _logger = logger;
        }
        
        public Compensation Create(Compensation compensation)
        {
           if(compensation != null)
            {
                _compensationRepository.Create(compensation);
                _compensationRepository.SaveAsync().Wait();

            }
           return compensation;
        }

        public Compensation Read(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return _compensationRepository.Read(id);
            }
            return null;
        }

        public List<Compensation> ReadByEmployeeId(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return _compensationRepository.ReadByEmployeeID(id);
            }
            return null;
        }
    }
}
