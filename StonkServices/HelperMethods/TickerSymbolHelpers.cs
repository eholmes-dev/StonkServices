using StonkServices.Models;

namespace StonkServices.HelperMethods
{
    /// <summary>
    /// Helper methods for TickerSymbol related functions
    /// </summary>
    public class TickerSymbolHelpers
    {
        /// <summary>
        /// Applies all properties to a TickerSymbol object from a dynamic.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static TickerSymbol ApplyTickerSymbolValues(dynamic i)
        {
            TickerSymbol symbol = new TickerSymbol();
            symbol.Type = i.type;
            symbol.Name = i.name;
            symbol.Currency = i.currency;
            symbol.Country = i.country;
            symbol.Exchange = i.exchange;
            symbol.Symbol = i.symbol;
            return symbol;
        }
    }
}
