using System;
using System.Collections.Generic;
using System.Text;
using BankDB.Models;

namespace BankDB.Repositories
{
    interface IBank
    {
        void Create(Bank bank);
        void Update(Bank bank);
        void Delete(int Id);
    }
}
