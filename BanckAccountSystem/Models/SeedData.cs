using BanckAccountSystem.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanckAccountSystem.Models
{
    public  class SeedData
    {
        public static void SeedDatabase(BanckAccountContext context)
        {
            context.Database.Migrate();
            context.BankAccounts.AddRange(
                 new Model.BankAccount { Balance=150,   CustomerRef="Ref 1" , BankAccountId= new Guid(), Transaction = new List<Model.Transaction> { new Model.Transaction(300,100,"ref1",DateTime.Now) { Date= DateTime.Now, Reference="ref1", Deposit=300, Withdrawal=100 } } },
                 new Model.BankAccount { Balance = 150, CustomerRef = "Ref 2", BankAccountId = new Guid(), Transaction = new List<Model.Transaction> { new Model.Transaction(300, 100, "ref2", DateTime.Now) { Date = DateTime.Now, Reference = "ref2", Deposit = 300, Withdrawal = 100 } } },
                 new Model.BankAccount { Balance = 150, CustomerRef = "Ref 3", BankAccountId = new Guid(), Transaction = new List<Model.Transaction> { new Model.Transaction(300, 100, "ref3", DateTime.Now) { Date = DateTime.Now, Reference = "ref3", Deposit = 300, Withdrawal = 100 } } },
                 new Model.BankAccount { Balance = 150, CustomerRef = "Ref 4", BankAccountId = new Guid(), Transaction = new List<Model.Transaction> { new Model.Transaction(300, 100, "ref4", DateTime.Now) { Date = DateTime.Now, Reference = "ref4", Deposit = 300, Withdrawal = 100 } } },
                 new Model.BankAccount { Balance = 150, CustomerRef = "Ref 5", BankAccountId = new Guid(), Transaction = new List<Model.Transaction> { new Model.Transaction(300, 100, "ref5", DateTime.Now) { Date = DateTime.Now, Reference = "ref5", Deposit = 300, Withdrawal = 100 } } },
                 new Model.BankAccount { Balance = 150, CustomerRef = "Ref 6", BankAccountId = new Guid(), Transaction = new List<Model.Transaction> { new Model.Transaction(300, 100, "ref6", DateTime.Now) { Date = DateTime.Now, Reference = "ref6", Deposit = 300, Withdrawal = 100 } } }
                );
            context.SaveChanges();

        }
    }
}
