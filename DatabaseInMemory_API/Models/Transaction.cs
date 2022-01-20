using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseInMemory_API.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long payment_id { get; set; }
        public long transaction_id { get; set; }
        public long accountCode { get; set; }
        public long merchant { get; set; }
        public decimal sum { get; set; }
        public byte? paymentstatus { get; set; }

        //public ICollection<Account> Account { get; set; }
    }
}
