
namespace HomeAccounting.BusinessLogic.EF.Domain
{
    public class PropertyPriceChange : Entity
    {
        public int Delta { get; set; }
        public int RegistrationDate { get; set; }
    }
}