using HomeAccounting.BusinessLogic.Contract;
using HomeAccounting.DataSource.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinessLogic
{
    public class AccountingService : IAccounting
    {
        private readonly IRepository _repo;
             
        public AccountingService(IRepository repo)
        {
            _repo = repo;
        }

        public void CreateAccount(Account account)
        {
            DBAccount dto = new DBAccount 
            {
                Id = account.Id,
                Tittle = account.Tittle,
                CreationDate = account.CreationDate
            };
            _repo.AddAccount(dto);
        }

        public Account GetAccountById(int id)
        {
            var dBAccount = _repo.GetAccountById(id);
            return new Account
            {
                Id = dBAccount.Id,
                CreationDate = dBAccount.CreationDate,
                Tittle = dBAccount.Tittle
            };
        }

        public void SaveAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
