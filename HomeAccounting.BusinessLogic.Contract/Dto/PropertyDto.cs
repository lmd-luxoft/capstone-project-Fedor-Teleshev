
namespace HomeAccounting.BusinessLogic.Contract.Dto
{
    public class PropertyDto : AccountDto
    {
        public string Location { get; set; }
        public decimal BasePrice { get; set; }
        public int PropertyType { get; set; }
    }
}
