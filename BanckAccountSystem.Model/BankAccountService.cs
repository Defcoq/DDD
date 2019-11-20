using BanckAccountSystem.Model.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanckAccountSystem.Model
{
    public class BankAccountService
    {
        private IBankAccountRepository _bankAccountRepository;
        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }
        public void Transfer(Guid accountNoTo, Guid accountNoFrom, decimal amount)
        {
            BankAccount bankAccountTo = _bankAccountRepository.FindBy(accountNoTo);
            BankAccount bankAccountFrom = _bankAccountRepository.FindBy(accountNoFrom);
            if (bankAccountFrom.CanWithdraw(amount))
            {
                bankAccountTo.Deposit(amount,"From Acc " +bankAccountFrom.CustomerRef + " ");
                bankAccountFrom.Withdraw(amount,"Transfer To Acc " +bankAccountTo.CustomerRef + " ");
                _bankAccountRepository.Save(bankAccountTo);
                _bankAccountRepository.Save(bankAccountFrom);
            }
            else
            {
                throw new InsufficientFundsException();
            }
        }
    }
}
