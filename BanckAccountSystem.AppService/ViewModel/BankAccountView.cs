using System;
using System.Collections.Generic;
using System.Text;

namespace BanckAccountSystem.AppService.ViewModel
{
    public class BankAccountView
    {
        public Guid BankAccountId { get; set; }
        public string Balance { get; set; }
        public string CustomerRef { get; set; }
        public IList<TransactionView> Transaction { get; set; }
    }
}
