using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ExpenseManager.Common;
using ExpenseManager.DataAccess;
using ExpenseManager.DataAccess.Models;
using WebGrease.Css.Extensions;
using System.Web.Http.Cors;

namespace ExpenseManager.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("")]
    public class ProfilesController : BaseApiController
    {
        // GET api/players
        public ProfilesController(ExpenseManagerContext ctx)
            : base(ctx)
        {
        }

        public IEnumerable<Profile> Get()
        {
            var profiles = _ctx.Profiles.ToList();

            return profiles;
        }

        // GET api/players/5
        public Profile Get(int id)
        {
            var profile = _ctx.Profiles.ToList().SingleOrDefault(p => p.Id == id);
            if (profile == null)
                return new Profile()
                {
                    Id = id
                };

            return profile;
        }

        // POST api/prifiles
        public void Post([FromBody]Profile profile)
        {
            var originalProfile = _ctx.Profiles.Find(profile.Id);
            _ctx.Entry(originalProfile).CurrentValues.SetValues(profile);
            _ctx.SaveChangesAsync();
        }

        // PUT api/profiles
        public void Put([FromBody]Profile profile)
        {
            _ctx.Profiles.Add(profile);
            _ctx.SaveChangesAsync();
        }

        // DELETE api/profiles/5
        public void Delete(int id)
        {
            var profile = _ctx.Profiles.FirstOrDefault(x => x.Id == id);
            if (profile != null)
            {
                _ctx.Profiles.Remove(profile);
                _ctx.SaveChangesAsync();
            }
        }
    }
}
