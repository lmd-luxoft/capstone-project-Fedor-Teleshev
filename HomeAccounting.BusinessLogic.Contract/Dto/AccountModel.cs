using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinessLogic.Contract.Dto
{
    public class AccountModel
    {
        public enum AccountType
        {
            Simple,Deposit,Property,Cash
        }

        public string Tittle { get; set; }
        public decimal Amount { get; set; }
        public AccountType Type { get; set; }
        public CashModel Cash { get; set; }
        public DepositModel Deposit { get; set; }
        public PropertyModel Property { get; set; }
    }

    public class CashModel
    {
        public int CoinNumber { get; set; }
        public int CashNumber { get; set; }
    }

    public class DepositModel
    {
        public BankModel Bank { get; set; }
        public decimal Percent { get; set; }
    }

    public class BankModel
    {
        public string Bik { get; set; }
        public string CorrespondedAccount { get; set; }
        public string Tittle { get; set; }
    }

    public class PropertyModel
    {
        public string Location { get; set; }
        public int PropertyType { get; set; }
    }


}
