
namespace HomeAccounting.BusinessLogic.Contract.Dto
{
    public class AccountDto
    {
        public enum AccountType
        {
            Simple,Deposit,Property,Cash
        }

        public string Tittle { get; set; }
        public decimal Amount { get; set; }
        public AccountType Type { get; set; }
    }
}
