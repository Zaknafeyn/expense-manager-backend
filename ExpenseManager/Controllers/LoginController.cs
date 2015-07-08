using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using ExpenseManager.Common;
using ExpenseManager.DataAccess;
using ExpenseManager.DataAccess.Models;
using ExpenseManager.DataObjects;
using Microsoft.Ajax.Utilities;

namespace ExpenseManager.Controllers
{
    public class LoginController : BaseApiController
    {
        private MD5 _hashFunc = MD5.Create();

        // GET api/login
        public LoginController(ExpenseManagerContext ctx) : base(ctx)
        {
        }

        // POST api/login
        public Profile Post([FromBody]LoginData loginData)
        {
            var result = _ctx.Profiles.SingleOrDefault(x => GetHash(x.Login) == loginData.LoginHash && x.PasswordHash == loginData.PasswordHash.Trim());
            return result;
        }

        private string GetHash(string @string)
        {
            var inputBytes = Encoding.ASCII.GetBytes(@string);
            byte[] hash = _hashFunc.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(i.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
