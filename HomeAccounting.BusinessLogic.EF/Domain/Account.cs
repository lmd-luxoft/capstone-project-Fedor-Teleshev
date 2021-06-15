using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinessLogic.EF.Domain
{
    public class Account : Entity
    {
        public decimal Balance { get; set; }        
        public DateTime CreationDate { get; set; }
        public string Tittle { get; set; }
    }
}