using System;
using System.Collections.Generic;
using System.Text;
using BankDB.Models;
using BankDB.Repositories;

namespace BankDB.Repositories
{
    interface ICustomer
    {
        List<Bank> GetBanks();
        List<Bank> GetBankCustomers();
        List<Bank> GetBankAccounts();
        void Create(CustomerRepository customer);
        void Create(Account account);
        void Delete(int id);
    }
}