using System.Collections.Generic;

namespace CurrencyConverter.Models
{
    public static class CurrencyData
    {
        public static List<Currency> GetCurrencies()
        {
            return new List<Currency>
            {
                new Currency { Code = "USD", Name = "US Dollar", Rate = 1.0 },
                new Currency { Code = "EUR", Name = "Euro", Rate = 0.85 }, // 1 USD = 0.85 EUR
                new Currency { Code = "JPY", Name = "Japanese Yen", Rate = 110.0 }, // 1 USD = 110.0 JPY
                new Currency { Code = "RUB", Name = "Russian Ruble", Rate = 85.0 }, // 1 USD = 85.0 RUB
                new Currency { Code = "CNY", Name = "Chinese Yuan", Rate = 6.45 }, // 1 USD = 6.45 CNY
                new Currency { Code = "KZT", Name = "Kazakhstani Tenge", Rate = 425.0 }, // 1 USD = 425.0 KZT
                new Currency { Code = "GEL", Name = "Georgian lari", Rate = 0.37 } // 1 USD = 0.37 GEL

            };
        }
    }
}
