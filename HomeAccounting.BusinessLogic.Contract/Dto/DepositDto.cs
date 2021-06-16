
namespace HomeAccounting.BusinessLogic.Contract.Dto
{
    public class DepositDto : AccountDto
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
}
