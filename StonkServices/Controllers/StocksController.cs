using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StonkServices.HelperMethods;
using StonkServices.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StonkServices.Controllers
{
    /// <summary>
    /// API Endpoint for getting list of stock Ticker Symbols.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        // GET: api/<StocksController>
        /// <summary>
        /// GET method which retrieves a list of stock Ticker Symbols.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<TickerSymbol>> GetAsync()
        {
            List<TickerSymbol> result = new List<TickerSymbol>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twelve-data1.p.rapidapi.com/stocks?exchange=NASDAQ&format=json"),
                Headers =
                {
                    { "x-rapidapi-host", "twelve-data1.p.rapidapi.com" },
                    { "x-rapidapi-key", "74d0d806d6mshd52daf5b115a0c2p163176jsnd6fc2160f069" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                JObject jBody = JObject.Parse(body);

                if (jBody["data"] != null)
                {
                    foreach (dynamic i in jBody["data"])
                    {
                        TickerSymbol symbol = TickerSymbolHelpers.ApplyTickerSymbolValues(i);

                        result.Add(symbol);

                    }
                }
            }
            return result;


        }

        // GET api/<StocksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
