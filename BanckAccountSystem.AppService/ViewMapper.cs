using AutoMapper;
using BanckAccountSystem.AppService.ViewModel;
using BanckAccountSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanckAccountSystem.AppService
{
    public class ViewMapper: Profile
    {
        public ViewMapper()
        {
            CreateMap<BankAccount, BankAccountView>();
            CreateMap<Transaction, TransactionView>();
        }
    }
}
