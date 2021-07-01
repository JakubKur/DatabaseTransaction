using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseTransaction.Database;

namespace DatabaseTransaction.Interfaces
{
    public interface IDataService
    {
        Task<List<People>> GetPeople();
        Task<bool> AddPerson(People p);
        Task AddPeopleByTransaction(IEnumerable<People> people);
    }
}
