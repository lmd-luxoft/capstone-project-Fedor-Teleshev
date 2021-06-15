using HomeAccounting.BusinessLogic.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinessLogic.Contract
{
    public interface IAccountingService
    {
        void CreateAccount(AccountModel account);
    }
}
