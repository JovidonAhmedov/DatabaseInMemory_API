using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseInMemory_API.Data;
using DatabaseInMemory_API.Filter;
using DatabaseInMemory_API.Models;
using DatabaseInMemory_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseInMemory_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[APIKeyAuth]
    public class AccountController : ControllerBase
    {
        private MyDbContext db;

        //for result
        private ApiResponse result;
        public AccountController(MyDbContext db)
        {
            this.db = db;
            result = new ApiResponse();
        }
        
        [HttpGet]
        public IActionResult getAccount()
        {
            var account = db.Accounts.ToList();
            if (account.Count < 1)
                return NotFound("The Account not found");
            return Ok(account);
        }

        [HttpGet("{accountCode}")]
        public IActionResult getAccount([FromQuery]long accountCode)
        {
            var account = db.Accounts.SingleOrDefault(a => a.accountCode == accountCode);
            if (account == null)
                return NotFound("The Account not found");
            return Ok(account + "  " + result.Code);
        }

        [HttpPost]
        public IActionResult createAccount([FromBody]Account account)
        {
            try
            {
                db.Accounts.Add(account);
                db.SaveChanges();
            }
            catch
            {
                result.Code = 0;
                return NotFound("Exception "+ result.Code);
            }
            result.Code = 1;
            return Ok(account.msisdn + "   " + result.Code);
        }

        #region
        public void M()
        {
            //private IRepository<Account> repository;

            //public AccountController(IRepository<Account> repository)
            //{
            //    this.repository = repository;
            //}



            //[HttpGet]
            //public IActionResult getAccount()
            //{
            //    var account = repository.GetAll();
            //    if (account==null)
            //        return NotFound("The Account not found");
            //    return Ok(account);
            //}


            //[HttpPost]
            //public IActionResult createAccount([FromBody]Account account)
            //{
            //    var entity=repository.Create(account);
            //    if(entity==null)
            //        return NotFound("Exception");
            //    return Ok(entity.Status + "   " + 1);
            //}
        }
        #endregion
    }
}