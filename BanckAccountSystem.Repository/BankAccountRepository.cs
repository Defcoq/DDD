using BanckAccountSystem.Model;
using BanckAccountSystem.Model.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BanckAccountSystem.Repository
{
    public class BankAccountRepository : IBankAccountRepository

    {
        private BanckAccountContext context;
        public BankAccountRepository(BanckAccountContext ctx)
        {
            context = ctx;

        }
        public void Add(BankAccount bankAccount)
        {
            context.BankAccounts.Add(bankAccount);

            context.SaveChanges();
            updateOrCreateTransaction(bankAccount);
        }

        public IEnumerable<BankAccount> FindAll()
        {
           var result =  context.BankAccounts.Include(x => x.Transaction).ToList();
            //to break circular reference
            foreach (BankAccount bankaccount in result)
            {
                if(bankaccount.Transaction != null)
                {
                    foreach (Transaction trs  in bankaccount.Transaction)
                    {
                       trs.BankAccount  = null;
                    }
                }
            }
            return result;
            
        }

        public BankAccount FindBy(Guid AccountId)
        {
            return context.BankAccounts.Include(y=>y.Transaction).FirstOrDefault(x => x.BankAccountId == AccountId);
        }

        public void Save(BankAccount bankAccount)
        {
            BankAccount account = context.BankAccounts.FirstOrDefault(x => x.BankAccountId == bankAccount.BankAccountId);
            account.CustomerRef = bankAccount.CustomerRef;
            account.Balance = bankAccount.Balance;
            context.SaveChanges();
            updateOrCreateTransaction(bankAccount);
        }

        private void updateOrCreateTransaction(BankAccount bankAccount)
        {
            BankAccount account = context.BankAccounts.FirstOrDefault(x => x.BankAccountId == bankAccount.BankAccountId);
           var currentTrans = context.Transactions.Where(x=>x.BankAccount.BankAccountId == bankAccount.BankAccountId).ToList();
            foreach (Transaction trs in currentTrans)
            {
                context.Transactions.Remove(trs);
                context.SaveChanges();

            }

            foreach (Transaction trs in bankAccount.Transaction)
            {
                context.Transactions.Add(trs);
                context.SaveChanges();

            }

            

        }

    }
}
