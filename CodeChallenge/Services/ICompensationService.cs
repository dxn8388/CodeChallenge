using CodeChallenge.Models;
using System.Collections.Generic;

namespace CodeChallenge.Services
{
    public interface ICompensationService
    {
        Compensation Create(Compensation compensation);
        Compensation Read(string id);
        List<Compensation> ReadByEmployeeId(string id);
    }
}
