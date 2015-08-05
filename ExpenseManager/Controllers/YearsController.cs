using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Cors;
using ExpenseManager.Common;
using ExpenseManager.DataAccess;

namespace ExpenseManager.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class YearsController : BaseApiController
    {
        // GET api/years
        public YearsController(ExpenseManagerContext ctx)
            : base(ctx)
        {
        }

        public IEnumerable<int> Get()
        {
            return _ctx.Trips.Select(x => x.Year).Distinct().ToList();
        }
    }
}
