using DatabaseInMemory_API.Data;
using DatabaseInMemory_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseInMemory_API.Repository
{
    public class RepositoryAccount:IRepository<Account>
    {
        private MyDbContext _db;
        public RepositoryAccount(MyDbContext db)
        {
            _db = db;
        }

        //add account
        public async Task<Account> Create(Account _object)
        {
            var obj = await _db.Accounts.AddAsync(_object);
            _db.SaveChanges();
            return obj.Entity;
        }

        //delete account
        public void Delete(Account _object)
        {
            _db.Remove(_object);
            _db.SaveChanges();
        }

        //get accounts
        public IEnumerable<Account> GetAll()
        {
            try
            {
                return _db.Accounts.ToList();
            }
            catch
            {
                throw;
            }
        }

        // get account by Id
        public Account GetById(long Id)
        {
            return _db.Accounts.Where(x => x.id == Id).FirstOrDefault();
        }

        // get account by accountCode
        public Account GetByAccountCode(long accountCode)
        {
            return _db.Accounts.Where(x => x.accountCode == accountCode).FirstOrDefault();
        }

        // update account
        public void Update(Account _object)
        {
            _db.Accounts.Update(_object);
            _db.SaveChanges();
        }
    }
}
