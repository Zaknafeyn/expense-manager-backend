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
            return new string[] { "value1", "value2" };
        }

        // GET api/dictionaries/5
        public IEnumerable<object> Get(int id)
        {
            switch (id)
            {
                case 1: // categories
                    var catId = 1;
                    foreach (var category in Enum.GetNames(typeof (Category)))
                        yield return new {id = catId++, category};
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
