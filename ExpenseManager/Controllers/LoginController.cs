using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using ExpenseManager.Common;
using ExpenseManager.DataAccess;
using ExpenseManager.DataAccess.Models;
using ExpenseManager.DataObjects;
using Microsoft.Ajax.Utilities;

namespace ExpenseManager.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : BaseApiController
    {
        private MD5 _hashFunc = MD5.Create(); 

        // GET api/login
        public LoginController(ExpenseManagerContext ctx) : base(ctx)
        {
        }

        // POST api/login
//        [HttpOptions, HttpPost]
        public Profile Post([FromBody]LoginData loginData)
        {
            if (Request.Method.Method.ToUpper() == "OPTIONS")
                return null;

            var result = _ctx.Profiles.ToList().SingleOrDefault(x => GetHash(x.Login) == loginData.LoginHash && x.PasswordHash == loginData.PasswordHash.Trim());
            
            return result;
        }

        private string GetHash(string @string, bool upperCase = false)
        {
            var inputBytes = Encoding.ASCII.GetBytes(@string);
            byte[] hash = _hashFunc.ComputeHash(inputBytes);

            var result = new StringBuilder(hash.Length * 2);

            for (int i = 0; i < hash.Length; i++)
                result.Append(hash[i].ToString(upperCase ? "X2" : "x2"));

//            System.Diagnostics.Trace.WriteLine("Converting string " + @string + ". Resulting hash: " + result);

            return result.ToString();
        }
    }
}
