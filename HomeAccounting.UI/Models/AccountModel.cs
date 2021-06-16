
namespace HomeAccounting.UI.Models
{
    public class AccountModel
    {
        public enum AccountType
        {
            Simple, Deposit, Property, Cash
        }

        public string Tittle { get; set; }
        public decimal Amount { get; set; }
        public AccountType Type { get; set; }
    }
}
