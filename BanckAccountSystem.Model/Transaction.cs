using System;
using System.Collections.Generic;
using System.Text;

namespace BanckAccountSystem.Model
{
    public class Transaction
    {
        public Transaction(decimal deposit, decimal withdrawal, string reference, DateTime date)
        {
            this.Deposit = deposit;
            this.Withdrawal = withdrawal;
            this.Reference = reference;
            this.Date = date;
        }
        public long TransactionId { get; set; }
        public decimal Deposit
        { get; set; }
        public decimal Withdrawal
        { get; set; }
        public string Reference
        { get; set; }
        public DateTime Date
        { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}
