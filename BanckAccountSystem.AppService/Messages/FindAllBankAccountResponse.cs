using BanckAccountSystem.AppService.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanckAccountSystem.AppService.Messages
{
    public class FindAllBankAccountResponse : ResponseBase
    {
        public IList<BankAccountView> BankAccountView { get; set; }
    }
}
