using System.Data.Entity;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using ExpenseManager.DataAccess;
using Newtonsoft.Json.Bson;

namespace ExpenseManager.Common
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public abstract class BaseApiController : BaseApiController<ExpenseManagerContext>
    {
        protected ExpenseManagerContext _ctx;

        protected BaseApiController(ExpenseManagerContext ctx)
            : base(ctx)
        {
            _ctx = ctx;
        }
    }

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public abstract class BaseApiController<TCtx> : ApiController where TCtx : DbContext
    {
        protected TCtx _ctx;

        protected BaseApiController(TCtx ctx)
        {
            _ctx = ctx;
        }

//        public void Options()
//        {
//
//        }
//
//        public void Options(int id)
//        {
//            Options();
//        }

        protected void HandleOptions()
        {
#if DEBUG
            // add custom header when run on DEBUG on local machine
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
#endif
        }
    }
}