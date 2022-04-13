namespace StonkServices.Models
{
    public class TickerSymbol
    {
        /// <summary>
        /// Ticker symbol for a stock
        /// </summary>
        public string? Symbol { get; set; }

        /// <summary>
        /// Full name of a stock
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Currency for which the stock is exchanged
        /// </summary>
        public string? Currency { get; set; }

        /// <summary>
        /// Market which stock is exchanged on
        /// </summary>
        public string? Exchange { get; set; }

        /// <summary>
        /// Country associated with a stock
        /// </summary>
        public string? Country { get; set; }

        /// <summary>
        /// Type of stock (i.e. 'Common Stock', 'Depositary Receipt', etc.)
        /// </summary>
        public string? Type { get; set; }
    }
}
