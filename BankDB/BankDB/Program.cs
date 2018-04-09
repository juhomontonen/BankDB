using System;
using System.Collections.Generic;
using BankDB.Models;
using BankDB.Repositories;

namespace BankDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Database CRUD operations");
            Bank pankki = new Bank
            {
                Name = "Danske Bank XXX",
                Bic = "DABAFIHH",



                Customer = new List<Customer>
                {
                    new Customer
                    {
                        Firstname ="PekkaXXX",
                        Lastname ="Pätkä"
                    }
                }
                //Account = new List<Account>
                //{
                //    new Account{Iban="FI2041024220421204",Name="Käyttötili",Balance=2000},
                //    new Account{Iban="FI2041024220421203",Name="Säästötili",Balance=5000},
                //}
            };


            BankRepository repository = new BankRepository();
            repository.Create(pankki);
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();

        }
    }
}
