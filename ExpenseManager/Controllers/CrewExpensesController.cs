using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ExpenseManager.Common;
using ExpenseManager.DataAccess;
using ExpenseManager.DataAccess.Models;

namespace ExpenseManager.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CrewExpensesController : BaseApiController<ExpenseManagerContext>
    {
        // GET api/crewexpenses
        public CrewExpensesController(ExpenseManagerContext ctx) : base(ctx)
        {
        }

        public IEnumerable<CrewExpense> Get()
        {
            return _ctx.CrewExpenseses;
        }

        // GET api/crewexpenses/5
        public IEnumerable<CrewExpense> Get(int id)
        {
            var result = _ctx.CrewExpenseses.Include(x => x.Buyer).Include(x => x.CarCrew).Where(x => x.CarCrew.Id == id).ToList();
            return result;
        }

        // POST api/crewexpenses
        public void Post([FromBody]string value)
        {
        }

        // PUT api/crewexpenses/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/crewexpenses/5
        public void Delete(int id)
        {
        }
    }
}
