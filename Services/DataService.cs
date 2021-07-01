using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseTransaction.Database;

namespace DatabaseTransaction.Interfaces
{
    public class DataService : IDataService
    {
        private readonly ApplicationDbContext _db;

        public DataService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> AddPerson(People p)
        {
            try
            {
                _db.People.Add(p);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }                                       
            
        }

        public async Task AddPeopleByTransaction(IEnumerable<People> people)
        {
            try
            {
                await _db.Database.BeginTransactionAsync();
                foreach (var p in people)
                {
                    _db.People.Add(p);
                    await _db.SaveChangesAsync();
                }

                await _db.Database.CommitTransactionAsync();

            }
            catch (Exception)
            {
                await _db.Database.RollbackTransactionAsync();
            }

            
        }

        public async Task<List<People>> GetPeople()
        {
            return await _db.People.ToListAsync();
        }
    }
}
