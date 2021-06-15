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

        public void CreateAccount(AccountModel account)
        {
            switch (account.Type)
            {
                case AccountModel.AccountType.Simple:
                    CreateSimpleAccount(account);
                    break;
                case AccountModel.AccountType.Cash:
                    CreateCash(account);
                    break;
                case AccountModel.AccountType.Deposit:
                    CreateDeposit(account);
                    break;
                
                case AccountModel.AccountType.Property:
                    CreateProperty(account);
                    break;
                default:
                    throw new Exception("Wrong account type");
            }
            _ctx.SaveChanges();
        }

        private void CreateSimpleAccount(AccountModel account)
        {
            var newAccount = new Domain.Account
            {
                Balance = account.Amount,
                CreationDate = DateTime.Now,
                Tittle = account.Tittle,
            };
            _ctx.Accounts.Add(newAccount);
        }

        private void CreateCash(AccountModel account)
        {
            if (account.Cash == null)
                return;

            var cash = new Cash
            {
                Balance = account.Amount,
                CreationDate = DateTime.Now,
                Tittle = account.Tittle,
                CoinNumber = account.Cash.CoinNumber,
                CashNumber = account.Cash.CashNumber
            };
            _ctx.Cashes.Add(cash);
        }

        private void CreateDeposit(AccountModel account)
        {
            if (account.Deposit == null)
                return;

            var bank = _ctx.Banks.Where(x => x.Bik == account.Deposit.Bank.Bik).FirstOrDefault();
            
            var deposit = new Deposit
            {
                Balance = account.Amount,
                CreationDate = DateTime.Now,
                Tittle = account.Tittle,
                Percent = account.Deposit.Percent,
                Bank = bank == null ? bank : new Bank
                {
                    Bik = account.Deposit.Bank.Bik,
                    CorrespondedAccount = account.Deposit.Bank.CorrespondedAccount,
                    Tittle = account.Deposit.Bank.Tittle
                },
            };
            _ctx.Deposits.Add(deposit);
        }

        private void CreateProperty(AccountModel account)
        {
            if (account.Property == null)
                return;

            var property =  new Property
            {
                Balance = account.Amount,
                CreationDate = DateTime.Now,
                Location = account.Property.Location,
                Tittle = account.Tittle,
                Type = (PropertyType) account.Property.PropertyType
            };
            _ctx.Propertes.Add(property);
        }

         
    }
}
