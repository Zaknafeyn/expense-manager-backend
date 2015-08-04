using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using ExpenseManager.DataAccess.Models.Enums;

namespace ExpenseManager.Controllers
{
    /// <summary>
    /// Exposes different dictionaries (like registered currencies, categories etc)
    /// </summary>
    public class DictionariesController : ApiController
    {
        // GET api/dictionaries
        public object Get()
        {
            // return all dictionaries

            return new {Categories = GetCategories(), Currencies = GetCurrencies()};
        }

//        // GET api/dictionaries/category/<name>
        [Route("api/v1/dictionaries/category/{categoryName}")]
        public IEnumerable<object> Get(string categoryName)
        {
            switch (categoryName)
            {
                case "categories":
                    yield return GetCategories();
                    break;
                case "currencies":
                    yield return GetCurrencies();
                    break;
            }
        }

        private IEnumerable<object> GetCurrencies()
        {
            var currencyId = 0;
            foreach (var currency in Enum.GetNames(typeof(Currency)))
                yield return new { id = currencyId++, currency };
        }

        private IEnumerable<object> GetCategories()
        {
            var catId = 0;
            foreach (var category in Enum.GetNames(typeof(Category)))
                yield return new { id = catId++, category };
        } 
    }
}
