﻿
namespace HomeAccounting.BusinessLogic.EF.Domain
{
    public class Cash : Account
    {
        public int CoinNumber { get; set; }
        public int CashNumber { get; set; }
    }
}