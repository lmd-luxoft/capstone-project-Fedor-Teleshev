using System;

namespace HomeAccounting.BusinessLogic.Contract
{
    public class Account
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
