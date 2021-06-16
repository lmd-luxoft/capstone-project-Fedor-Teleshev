using HomeAccounting.BusinessLogic.Contract;
using HomeAccounting.BusinessLogic.Contract.Dto;
using HomeAccounting.UI.Models;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("CreateSimpleAccount")]
        public IActionResult CreateSimpleAccount(AccountModel account)
        {
            var model = new AccountDto
            {
                Tittle = account.Tittle,
                Amount = account.Amount,
                Type = (AccountDto.AccountType)account.Type,
            };

            var result = _accountingService.CreateSimpleAccount(model);
            return Json(new { StatusCode = result });
        }

        [HttpGet("CreateCash")]
        public IActionResult CreateCash(CashModel account)
        {
            var model = new CashDto
            {
                Tittle = account.Tittle,
                Amount = account.Amount,
                Type = (AccountDto.AccountType)account.Type,
                CoinNumber = account.CoinNumber,
                CashNumber = account.CashNumber
            };

            var result = _accountingService.CreateCash(model);
            return Json(new { StatusCode = result });
        }

        [HttpGet("CreateDeposit")]
        public IActionResult CreateDeposit(DepositModel account)
        {
            var model = new DepositDto
            {
                Tittle = account.Tittle,
                Amount = account.Amount,
                Type = (AccountDto.AccountType)account.Type,
                Percent = account.Percent,
                Bank = new BankDto
                {
                    Bik = account.Bank.Bik,
                    Tittle = account.Bank.Tittle,
                    CorrespondedAccount = account.Bank.CorrespondedAccount
                }
            };

            var result = _accountingService.CreateDeposit(model);
            return Json(new { StatusCode = result });
        }

        [HttpGet("CreateProperty")]
        public IActionResult CreateProperty(PropertyModel account)
        {
            var model = new PropertyDto
            {
                Tittle = account.Tittle,
                Amount = account.Amount,
                Type = (AccountDto.AccountType)account.Type,
                Location = account.Location,
                PropertyType = account.PropertyType
            };

            var result = _accountingService.CreateProperty(model);
            return Json(new { StatusCode = result });
        }
    }
}