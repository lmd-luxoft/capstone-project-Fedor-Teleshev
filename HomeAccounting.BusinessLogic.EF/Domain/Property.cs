using System.Collections.Generic;

namespace HomeAccounting.BusinessLogic.EF.Domain
{
    public class Property : Account
    {
        public decimal BasePrice { get; set; }
        public string Location { get; set; }
        public PropertyType Type { get; set; }
        public IEnumerable<PropertyPriceChange> PropertyPriceChanges { get; set; }
    }
}