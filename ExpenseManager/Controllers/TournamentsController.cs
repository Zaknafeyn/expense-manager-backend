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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TournamentsController : BaseApiController<ExpenseManagerContext>
    {
        public TournamentsController(ExpenseManagerContext ctx)
            : base(ctx)
        {
        }

        // GET api/tournaments
        public IEnumerable<Tournament> Get()
        {
            return _ctx.Tournaments.OrderBy(x => x.StartDate).ToList();
        }

        // GET api/tournaments
        public IEnumerable<Tournament> Get(string filter, string value)
        {
            if (filter.ToLower() == "year")
            {
                var year = int.Parse(value);
                return _ctx.Tournaments.Where(x => x.Year == year).OrderBy(x => x.StartDate).ToList();
            }

            return null;
        }

        // GET api/tournaments/5
        public Tournament Get(int id)
        {
            var tournament = _ctx.Tournaments.ToList().FirstOrDefault(x => x.Id == id);
            if (tournament == null)
                return new Tournament();

            return tournament;
        }

        // POST api/tournaments
        public void Post([FromBody]Tournament tournament)
        {
            var originalTournament = _ctx.Tournaments.Find(tournament.Id);
            _ctx.Entry(originalTournament).CurrentValues.SetValues(tournament);
            _ctx.SaveChangesAsync();
        }

        // PUT api/tournaments/5
        public void Put([FromBody]Tournament tournament)
        {
            _ctx.Tournaments.Add(tournament);
            _ctx.SaveChangesAsync();
        }

        // DELETE api/tournaments/5
        public void Delete(int id)
        {
            var tournament = _ctx.Tournaments.FirstOrDefault(x => x.Id == id);
            if (tournament != null)
            {
                _ctx.Tournaments.Remove(tournament);
                _ctx.SaveChangesAsync();
            }
        }
    }
}
