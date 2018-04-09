﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankDB.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Account = new HashSet<Account>();
        }

        public Customer(string firstName, string lastName)
        {
            Firstname = firstName;
            Lastname = lastName;
        }

        public long Id { get; set; }
        [StringLength(50)]
        public string Firstname { get; set; }
        [StringLength(50)]
        public string Lastname { get; set; }
        public long BankId { get; set; }

        [ForeignKey("BankId")]
        [InverseProperty("Customer")]
        public Bank Bank { get; set; }
        [InverseProperty("Customer")]
        public ICollection<Account> Account { get; set; }
    }
}
