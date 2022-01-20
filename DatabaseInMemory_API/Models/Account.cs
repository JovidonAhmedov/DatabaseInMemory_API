using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseInMemory_API.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public long msisdn { get; set; }
        public decimal? balance { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public bool? identification { get; set; }
        public long accountCode { get; set; }


        //[ForeignKey(nameof(Transactions))]
       // public int transactionid { get; set; }
        //public Transaction Transaction { get; set; }
    }
}
