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
    public class MerchantController : ControllerBase
    {
        private MyDbContext db;
        public MerchantController(MyDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult getMerchant()
        {
            var items = db.Merchants.ToList();
            if (items.Count < 1)
                return NotFound("The Merchant not found");
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult getMerchantById(long id)
        {
            var item = db.Merchants.FirstOrDefault(a => a.id == id);
            if (item == null)
                return NotFound("The Merchant not found");
            return Ok(item.id);
        }

        [HttpPost]
        public IActionResult createMerchant(Merchant item)
        {
            try
            {
                db.Merchants.Add(item);
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