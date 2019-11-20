using BanckAccountSystem.AppService.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanckAccountSystem.AppService.Messages
{
    public class FindBankAccountResponse : ResponseBase
    {
        public BankAccountView BankAccount { get; set; }
    }
}
