
namespace HomeAccounting.BusinessLogic.EF.Domain
{
    public class Deposit : Account
    {
        public string NumberOfBankAccount { get; set; }
        public decimal Percent { get; set; }
        public Bank Bank { get; set; }
    }
}