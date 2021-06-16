
namespace HomeAccounting.UI.Models
{
    public class DepositModel : AccountModel
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
}
