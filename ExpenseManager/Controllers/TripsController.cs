using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Xml.Schema;
using ExpenseManager.Common;
using ExpenseManager.DataAccess;
using ExpenseManager.DataAccess.Models;

namespace ExpenseManager.Controllers
{
    /// <summary>
    /// Return trips data
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TripsController : BaseApiController
    {
        public TripsController(ExpenseManagerContext ctx)
            : base(ctx)
        {
        }

        // GET api/trips
        public IEnumerable<Trips> Get()
        {
            return _ctx.Trips.OrderBy(x => x.StartDate).ToList();
        }

        // GET api/trips
        public IEnumerable<Trips> Get(string filter, string value)
        {
            if (filter.ToLower() == "year")
            {
                var year = int.Parse(value);
                return _ctx.Trips.Where(x => x.Year == year).OrderBy(x => x.StartDate).ToList();
            }

            return null;
        }

        // GET api/trips/5
        public Trips Get(int id)
        {
            var trip = _ctx.Trips.ToList().FirstOrDefault(x => x.Id == id);
            if (trip == null)
                return new Trips();

            return trip;
        }

        // POST api/trips
        public void Post([FromBody]Trips trip)
        {
            var originalTrip = _ctx.Trips.Find(trip.Id);
            _ctx.Entry(originalTrip).CurrentValues.SetValues(trip);
            _ctx.SaveChangesAsync();
        }

        // PUT api/trips/5
        public void Put([FromBody]Trips trip)
        {
            _ctx.Trips.Add(trip);
            _ctx.SaveChangesAsync();
        }

        // DELETE api/trips/5
        public void Delete(int id)
        {
            var trip = _ctx.Trips.FirstOrDefault(x => x.Id == id);
            if (trip != null)
            {
                _ctx.Trips.Remove(trip);
                _ctx.SaveChangesAsync();
            }
        }
    }
}
