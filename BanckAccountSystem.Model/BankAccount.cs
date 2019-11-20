using System;
using System.Collections.Generic;
using System.Text;

namespace BanckAccountSystem.Model
{
    public class BankAccount
    {
        //private decimal _balance;
        //private Guid _accountNo;
        //private string _customerRef;
        //private IList<Transaction> _transactions;
        //public BankAccount() : this(Guid.NewGuid(), 0, new List<Transaction>(), "")
        //{
        //    Transaction.Add(new Transaction(0m, 0m, "account created", DateTime.Now));
        //}
        //public BankAccount(Guid Id, decimal balance, IList<Transaction> transactions, string customerRef)
        //{
        //    AccountNo = Id;
        //    _balance = balance;
        //    _transactions = transactions;
        //    _customerRef = customerRef;
        //}

        //public Guid AccountNo
        //{
        //    get { return BankAccountId; }
        //    internal set { BankAccountId = value; }
        //}
        public decimal Balance { get; set; }

        public Guid BankAccountId { get; set; }
      
        public List<Transaction> Transaction { get; set; }
        
      
        public string CustomerRef
        {
            get; set;
        }
        public bool CanWithdraw(decimal amount)
        {
            return (Balance >= amount);
        }
        public void Withdraw(decimal amount, string reference)
        {
            if (CanWithdraw(amount))
            {
                Balance -= amount;
                Transaction.Add(new Transaction(0m, amount,
                reference, DateTime.Now));
            }
            else
            {
                throw new InsufficientFundsException();
            }
        }
        public void Deposit(decimal amount, string reference)
        {
            Balance += amount;
            Transaction.Add(new Transaction(amount, 0m, reference, DateTime.Now));
        }
        public IEnumerable<Transaction> GetTransactions()
        {
            return Transaction;
        }
    }
}
