using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ExpenseManager.Common;
using ExpenseManager.DataAccess;
using ExpenseManager.DataAccess.Models;
using ExpenseManager.DataObjects;

namespace ExpenseManager.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : BaseApiController
    {
        private MD5 _hashFunc = MD5.Create();

#pragma warning disable 1591
        public LoginController(ExpenseManagerContext ctx) : base(ctx)
        {
        }
#pragma warning restore 1591

        // POST api/login
        /// <summary>
        /// Post login data to server for authentication and getting a profile
        /// </summary>
        public Profile Post([FromBody]LoginData loginData)
        {
            var result = _ctx.Profiles.ToList().SingleOrDefault(x => GetHash(x.Login) == loginData.LoginHash && x.PasswordHash == loginData.PasswordHash.Trim());
            
            return result;
        }

        /// <summary>
        /// Handle Options header
        /// </summary>
        [ApiExplorerSettings(IgnoreApi=true)]
        public void Options()
        {
            HandleOptions();
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
