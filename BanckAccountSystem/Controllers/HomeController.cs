using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BanckAccountSystem.Models;
using BanckAccountSystem.AppService;
using BanckAccountSystem.Model;
using BanckAccountSystem.AppService.Messages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BanckAccountSystem.AppService.ViewModel;

namespace BanckAccountSystem.Controllers
{
    public class HomeController : Controller
    {
        ApplicationBankAccountService _bankService;

        public HomeController(ApplicationBankAccountService bankService)
        {
            _bankService = bankService;
        }
        public IActionResult Index()
        {
            IList<BankAccountView> accounts = new List<BankAccountView>();
            accounts.Clear();
            FindAllBankAccountResponse responseAll = _bankService.GetAllBankAccounts();
            accounts = responseAll.BankAccountView;
            return View(accounts);
        }

        public ViewResult Edit(Guid bankaccountId)
        {
            FindBankAccountResponse response = _bankService.GetBankAccountBy(bankaccountId);
            BankAccountView accView = response.BankAccount;
            return View(accView);
        }

        public ViewResult Deposit(Guid bankaccountId)
        {
            FindBankAccountResponse response = _bankService.GetBankAccountBy(bankaccountId);
            BankAccountView accView = response.BankAccount;
            return View(accView);
        }
        public ViewResult Transfer(Guid bankaccountId)
        {
            FindBankAccountResponse response = _bankService.GetBankAccountBy(bankaccountId);
            BankAccountView accView = response.BankAccount;
            return View(accView);
        }

        public ViewResult Create() => View("Edit", new BankAccountView());



        [HttpPost]
        public IActionResult Edit(BankAccountView vm)
        {

           


            if (ModelState.IsValid)
            {
                BankAccountCreateRequest createAccountRequest = new BankAccountCreateRequest();
                createAccountRequest.CustomerName = vm.CustomerRef;
                _bankService.CreateBankAccount(createAccountRequest);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(vm);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
