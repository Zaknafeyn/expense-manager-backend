using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using ExpenseManager.Common;
using ExpenseManager.DataAccess;
using ExpenseManager.DataAccess.Models;

namespace ExpenseManager.Controllers
{
    /// <summary>
    /// Crew operations
    /// </summary>
    public class CrewController : BaseApiController
    {
        // GET api/crew
        public CrewController(ExpenseManagerContext ctx) : base(ctx)
        {
        }

        public IEnumerable<object> Get()
        {
            return _ctx.CarCrews.Include(table => table.CrewMember).Select(x => new {x.Id, x.IsCarOwner, tripId = x.TripRefId, x.IsDriver, x.CrewMember.Name});
        }

        // GET api/crew/5
        public IEnumerable<object> Get(int tripId)
        {
            return _ctx.CarCrews.Where(x => x.TripRefId == tripId).ToList();
        }

        // POST api/crew
        public void Post([FromBody]string value)
        {
        }

        // PUT api/crew/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/crew/5
        public void Delete(int id)
        {
        }
    }
}
