using System.ComponentModel;

namespace Domain.Products;

public enum CurrencyTypes
{
    [Description("TL")]
    TurkishLira = 0,
    [Description("USD")]
    Dollar = 1,
    [Description("EUR")]
    Euro = 2,
}
