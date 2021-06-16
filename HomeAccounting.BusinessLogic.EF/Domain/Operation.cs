using System;
using System.Collections.Generic;

namespace HomeAccounting.BusinessLogic.EF.Domain
{
    public class Operation : Entity
    {
        public DateTime ExecutionDate { get; set; }
        public decimal Amount { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
    }
}