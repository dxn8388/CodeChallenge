using CodeChallenge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeChallenge.Repositories
{
    public interface ICompensationRepository
    {
        Compensation Create(Compensation compensation);
        Compensation Read(string id);

        List<Compensation> ReadByEmployeeID(string empID);
        Task SaveAsync();

    }
}
