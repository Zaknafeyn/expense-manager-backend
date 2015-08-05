using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExpenseManager.Common;
using ExpenseManager.DataAccess;

namespace ExpenseManager.Controllers
{
    public class CalculationsController : BaseApiController
    {
        // GET api/calculations
        public CalculationsController(ExpenseManagerContext ctx) : base(ctx)
        {
        }

        // GET api/calculations/5 (tournament id)
        public double Get(int id)
        {
            var crewMembers = _ctx.CarCrews.ToList().Where(x => x.TripRefId == id);
            var crewMembersCount = crewMembers.Count();

            var crewExpenses =
                _ctx.CrewExpenseses.Include(x => x.CarCrew)
                    .Where(x => x.CarCrew.TripRefId == id).Sum(x => x.Expense);

            return crewExpenses / crewMembersCount;
        }
    }
}
