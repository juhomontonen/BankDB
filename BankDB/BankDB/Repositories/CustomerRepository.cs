using System;
using System.Collections.Generic;
using System.Text;
using BankDB.Models;
using System.Data.SqlTypes;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BankDB.Repositories
{
    class CustomerRepository : ICustomer
    {
        private readonly BankdbContext _context = new BankdbContext();
        public void Create(Customer customer)
        {
            _context.Customer.Add(customer);
            _context.SaveChanges();
        }

        public void Create(Account account)
        {
            _context.Account.Add(account);
            _context.SaveChanges();
        }

        public void Create(CustomerRepository customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var delCustomer = _context.Customer.FirstOrDefault(p => p.Id == id);
            if (delCustomer != null)
                _context.Customer.Remove(delCustomer);
            _context.SaveChanges();
        }

        public List<Bank> GetBankAccounts()
        {
            throw new NotImplementedException();
        }

        public List<Bank> GetBankCustomers()
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    List<Bank> banks = context.Bank
                        .Include(b => b.Customer)
                        .ToListAsync().Result;
                    return banks;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \n");
                }

            }

        }

        public List<Bank> GetBanks()
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    List<Bank> banks = context.Bank.ToListAsync().Result;
                    return banks;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}\n{ex.InnerException.Message} \n");
                }

            }
        }
    }
}