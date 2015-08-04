using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ExpenseManager.Common;
using ExpenseManager.DataAccess;
using Newtonsoft.Json;

namespace ExpenseManager.Controllers
{
    public class CurrenciesController : BaseApiController
    {
        // GET api/currencies
        public CurrenciesController(ExpenseManagerContext ctx)
            : base(ctx)
        {
        }

        public async Task<IEnumerable<object>> Get()
        {
            var uri = new Uri("https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=4");
            var list = new List<object>();

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(uri);
                result.EnsureSuccessStatusCode();
                var content = result.Content;

                var resStr = await content.ReadAsStringAsync();

                var resJson = (dynamic)JsonConvert.DeserializeObject(resStr);

                foreach (dynamic item in resJson)
                {
                    list.Add(new
                    {
                        currencyName = item.ccy,
                        item.buy,
                        item.sale
                    });
                }
            }

            return list;
        }

        // GET api/currencies/5
        public string Get(string currencyName)
        {
            return "value";
        }
    }
}
