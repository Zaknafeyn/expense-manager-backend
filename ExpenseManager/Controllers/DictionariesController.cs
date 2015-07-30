using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using ExpenseManager.DataAccess.Models.Enums;

namespace ExpenseManager.Controllers
{
    public class DictionariesController : ApiController
    {
        // GET api/dictionaries
        public IEnumerable<string> Get()
        {
            // return all dictionaries
            return new string[] { "value1", "value2" };
        }

        // GET api/dictionaries/category/<name>
        public IEnumerable<object> Get(string categoryName)
        {
            switch (categoryName)
            {
                case "categories": 
                    var catId = 0;
                    foreach (var category in Enum.GetNames(typeof (Category)))
                        yield return new {id = catId++, category};
                    break;
                case "currencies": 
                    var currencyId = 0;
                    foreach (var currency in Enum.GetNames(typeof(Currency)))
                        yield return new { currencyId = currencyId++, currency};
                    break;
            }
        }

        // POST api/dictionaries
        public void Post([FromBody]string value)
        {
        }

        // PUT api/dictionaries/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/dictionaries/5
        public void Delete(int id)
        {
        }
    }
}
