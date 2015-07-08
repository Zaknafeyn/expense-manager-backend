using System.Data.Entity;
using System.Web.Http;
using System.Web.Http.Cors;
using ExpenseManager.DataAccess;

namespace ExpenseManager.Common
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public abstract class BaseApiController : BaseApiController<ExpenseManagerContext>
    {
        protected ExpenseManagerContext _ctx;

        protected BaseApiController(ExpenseManagerContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }

    public abstract class BaseApiController<TCtx> : ApiController where TCtx : DbContext
    {
        protected TCtx _ctx;

        protected BaseApiController(TCtx ctx)
        {
            _ctx = ctx;
        }
    }
}