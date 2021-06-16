using HomeAccounting.BusinessLogic.Contract;
using HomeAccounting.BusinessLogic.Contract.Dto;
using HomeAccounting.BusinessLogic.EF.Domain;
using System;
using System.Linq;

namespace HomeAccounting.BusinessLogic.EF.ApplicationLogic
{
    public class AccountingService : IAccountingService
    {
        DomainContext _ctx;
        public AccountingService(DomainContext ctx)
        {
            _ctx = ctx;
        }
        
        public string CreateSimpleAccount(AccountDto account)
        {
            var newAccount = new Domain.Account
            {
                Balance = account.Amount,
                CreationDate = DateTime.Now,
                Tittle = account.Tittle,
            };
            _ctx.Accounts.Add(newAccount);
            _ctx.SaveChanges();
            return "Ok";
        }

        public string CreateCash(CashDto account)
        {
            var cash = new Cash
            {
                Balance = account.Amount,
                CreationDate = DateTime.Now,
                Tittle = account.Tittle,
                CoinNumber = account.CoinNumber,
                CashNumber = account.CashNumber
            };
            _ctx.Cashes.Add(cash);
            _ctx.SaveChanges();
            return "Ok";
        }

        public string CreateDeposit(DepositDto account)
        {
            var bank = _ctx.Banks.Where(x => x.Bik == account.Bank.Bik).FirstOrDefault();
            
            var deposit = new Deposit
            {
                Balance = account.Amount,
                CreationDate = DateTime.Now,
                Tittle = account.Tittle,
                Percent = account.Percent,
                Bank = bank == null ? bank : new Bank
                {
                    Bik = account.Bank.Bik,
                    CorrespondedAccount = account.Bank.CorrespondedAccount,
                    Tittle = account.Bank.Tittle
                },
            };
            _ctx.Deposits.Add(deposit);
            _ctx.SaveChanges();
            return "Ok";
        }

        public string CreateProperty(PropertyDto account)
        {
            var property =  new Property
            {
                Balance = account.Amount,
                CreationDate = DateTime.Now,
                Location = account.Location,
                Tittle = account.Tittle,
                Type = (PropertyType) account.PropertyType
            };
            _ctx.Propertes.Add(property);
            _ctx.SaveChanges();
            return "Ok";
        }

         
    }
}
