using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DatabaseInMemory_API.Data;
using DatabaseInMemory_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseInMemory_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private MyDbContext db;
        public TransactionController(MyDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult getTransaction()
        {
            var items = db.Transactions.ToList();
            if (items.Count < 1)
                return NotFound("The Transaction not found");
            return Ok(items);
        }

        [HttpGet("{transaction_Id}")]
        public IActionResult checkTransaction(long transaction_Id)
        {
            var item = db.Transactions.FirstOrDefault(a => a.transaction_id == transaction_Id);
            if (item == null)
                return NotFound("The Transaction not found");
            return Ok(item.payment_id);
        }

        [HttpPost]
        public IActionResult createTransaction(Transaction item)
        {
            try
            {
                db.Transactions.Add(item);
                db.SaveChanges();
            }
            catch
            {
                return NotFound("Exception");
            }
            return Ok(item + "   " + 1);
        }
    }
}