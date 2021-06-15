using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeAccounting.BusinessLogic.Contract;
using HomeAccounting.BusinessLogic.Contract.Dto;
using HomeAccounting.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HomeAccounting.UI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountingService _accountingService;

        public AccountController(ILogger<HomeController> logger, IAccountingService accountingService)
        {
            _logger = logger;
            _accountingService = accountingService;
        }

        [HttpGet("CreateAccount")]
        public IActionResult CreateAccount(AccountDto account)
        {
            var model = new AccountModel
            {
                Tittle = account.Tittle,
                Amount = account.Amount,
                Type = (AccountModel.AccountType)account.Type,
                Cash = account.Cash ==  null ? null : new CashModel 
                { 
                    CoinNumber = account.Cash.CoinNumber,
                    CashNumber = account.Cash.CashNumber
                },
                Deposit = account.Deposit == null ? null : new DepositModel
                {
                    Percent = account.Deposit.Percent,
                    Bank = new BankModel
                    {
                        Bik = account.Deposit.Bank.Bik,
                        Tittle = account.Deposit.Bank.Tittle,
                        CorrespondedAccount = account.Deposit.Bank.CorrespondedAccount
                    }
                },
                Property = account.Property == null ? null : new PropertyModel
                {
                    Location = account.Property.Location,
                    PropertyType = account.Property.PropertyType
                }
            };

            _accountingService.CreateAccount(model);
            return Json(new { StatusCode = true });
        }
    }
}