using System;
using System.Collections.Generic;
using System.Text;

namespace BanckAccountSystem.AppService.Messages
{
    public class WithdrawalRequest
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
