﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankDB.Models
{
    public partial class Bank
    {
        public Bank()
        {
            Account = new HashSet<Account>();
            Customer = new HashSet<Customer>();
        }

        public Bank(string name, string bic)
        {
            Name = name;
            Bic = bic;
        }

        public long Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Column("BIC", TypeName = "nchar(10)")]
        public string Bic { get; set; }

        [InverseProperty("Bank")]
        public ICollection<Account> Account { get; set; }
        [InverseProperty("Bank")]
        public ICollection<Customer> Customer { get; set; }
    }
}
