using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StonkServices.Models;

namespace StonkServices.Controllers
{
    /// <summary>
    /// API Endpoint for getting a stock price.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MarketDataController : ControllerBase
    {
        // GET: api/<MarketData>
        /// <summary>
        /// Default GET method. Does nothing.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MarketData>/5
        /// <summary>
        /// GET method accepting a string Ticker Symbol for which to get a stock price.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<MarketData> GetAsync(string id)
        {
            MarketData data = new MarketData();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twelve-data1.p.rapidapi.com/price?symbol=" + id + "&format=json&outputsize=30"),
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
                dynamic jBody = JObject.Parse(body);
                data.Price = jBody.price;
            }
            return data;
        }
    }
}
