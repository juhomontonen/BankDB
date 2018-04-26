using System;
using System.Collections.Generic;
using System.Text;
using BankDB.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data.SqlTypes;

namespace BankDB.Repositories
{
    class BankRepository : IBank
    {
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
        public List<Bank> GetBankAccounts()
        {
            throw new NotImplementedException();
        }

        private readonly BankdbContext _context = new BankdbContext();

        public void Create(Bank bank)
        {
            _context.Bank.Add(bank);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var delBank = _context.Bank.FirstOrDefault(p => p.Id == id);
            if (delBank != null)
                _context.Bank.Remove(delBank);
            _context.SaveChanges();
        }
        public Bank GetBankById(long id)
        {
            var bank = _context.Bank.FirstOrDefault(p => p.Id == id);
            return bank;
        }

        public void Update(Bank bank)
        {
            var updateBank = GetBankById(bank.Id);
            if (updateBank != null)
            {
                updateBank.Name = bank.Name;
                _context.Bank.Update(updateBank);
            }
            _context.SaveChanges();
        }

        public List<Bank> GetTransactionsFromBankCustomersAccounts()
        {
            using (var context = new BankdbContext())
            {
                try
                {
                    List<Bank> banks = context.Bank.
                        Include(b => b.Customer)
                        .Include(b => b.Account)
                        .Include(b => b.Account)
                        .ThenInclude(a => a.Transaction)
                        .ToListAsync().Result;
                    return banks;

                }
                catch (Exception ex)
                {
                    throw new NotImplementedException($"{ex.Message}");
                }

            }
        }
    }
}