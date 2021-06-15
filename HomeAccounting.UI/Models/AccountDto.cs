using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAccounting.UI.Models
{
    public class AccountDto
    {
        public enum AccountType
        {
            Simple, Deposit, Property, Cash
        }

        public string Tittle { get; set; }
        public decimal Amount { get; set; }
        public AccountType Type { get; set; }
        public CashDto Cash { get; set; }
        public DepositDto Deposit { get; set; }
        public PropertyDto Property { get; set; }
    }

    public class CashDto
    {
        public int CoinNumber { get; set; }
        public int CashNumber { get; set; }
    }

    public class DepositDto
    {
        public BankDto Bank { get; set; }
        public decimal Percent { get; set; }
    }

    public class BankDto
    {
        public string Bik { get; set; }
        public string CorrespondedAccount { get; set; }
        public string Tittle { get; set; }
    }

    public class PropertyDto
    {
        public string Location { get; set; }
        public int PropertyType { get; set; }
    }
}
