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
        private BankdbContext _context = new BankdbContext();

        public void Create(Bank bank)
        {
            _context.Bank.Add(bank);
            _context.SaveChanges();
        }

        //public void Create(Bank bank)
        //{
        //    throw new NotImplementedException();
        //}

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Bank bank)
        {
            throw new NotImplementedException();
        }
    }
}
