using System.Data.Entity;
using System.Web.Http;

namespace ExpenseManager.Common
{
    public abstract class BaseApiController<TCtx> : ApiController where TCtx : DbContext
    {
        protected TCtx _ctx;

        protected BaseApiController(TCtx ctx)
        {
            _ctx = ctx;
        }
    }
}