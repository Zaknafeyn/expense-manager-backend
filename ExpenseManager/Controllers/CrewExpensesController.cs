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
    public class CrewExpensesController : BaseApiController
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

        // POST api/crewexpenses/1
        // update expenses for a crew
        public void Post(int id, [FromBody]IEnumerable<CrewExpense> expenses)
        {
            if (expenses == null)
                return;

            // update
            foreach (var crewExpense in expenses)
            {
                var originalCrewExpense = _ctx.CrewExpenseses.Find(crewExpense.Id);
                if (originalCrewExpense != null)
                {
                    _ctx.Entry(originalCrewExpense).CurrentValues.SetValues(crewExpense);
                }
                else
                {
                    _ctx.CrewExpenseses.Add(crewExpense);
                }
            }

            _ctx.SaveChangesAsync();
        }

        // PUT api/crewexpenses
        public void Put([FromBody]CrewExpense crewExpense)
        {
            _ctx.CrewExpenseses.Add(crewExpense);
            _ctx.SaveChangesAsync();
        }

        // DELETE api/crewexpenses/5
        public void Delete(int id)
        {
            var crewExpense = _ctx.CrewExpenseses.FirstOrDefault(x => x.Id == id);
            if (crewExpense != null)
            {
                _ctx.CrewExpenseses.Remove(crewExpense);
                _ctx.SaveChangesAsync();
            }
        }

        
    }
}
