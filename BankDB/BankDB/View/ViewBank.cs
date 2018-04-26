using System;
using System.Collections.Generic;
using System.Text;
using BankDB.Models;
using System.Data.SqlTypes;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using static BankDB.Repositories.CustomerRepository;
using BankDB.Repositories;

namespace BankDB.View
{
    class ViewBank
    {
        private readonly CustomerRepository customerRepository = new CustomerRepository();

        public void PrintCustomer()
        {
            var customers = customerRepository.GetBankCustomers();
            foreach (var c in customers)
            {
                Console.WriteLine(c.ToString());
            }
        }
    }
}
