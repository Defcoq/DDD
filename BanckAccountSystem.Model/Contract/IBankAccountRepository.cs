using System;
using System.Collections.Generic;
using System.Text;

namespace BanckAccountSystem.Model.Contract
{
    public interface IBankAccountRepository
    {
        void Add(BankAccount bankAccount);
        void Save(BankAccount bankAccount);
        IEnumerable<BankAccount> FindAll();
        BankAccount FindBy(Guid AccountId);
    }
}
