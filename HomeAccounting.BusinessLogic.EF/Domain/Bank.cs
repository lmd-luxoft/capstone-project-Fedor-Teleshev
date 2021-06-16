
namespace HomeAccounting.BusinessLogic.EF.Domain
{
    public class Bank : Entity
    {
        public string Bik { get; set; }
        public string CorrespondedAccount { get; set; }
        public string Tittle { get; set; }
    }
}