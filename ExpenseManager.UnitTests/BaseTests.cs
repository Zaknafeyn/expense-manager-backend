using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManager.DataAccess;
using NUnit.Framework;

namespace ExpenseManager.UnitTests
{
    [TestFixture]
    public class BaseTests
    {
        private ExpenseManagerContext _target;

        [SetUp]
        public void OnStart()
        {
            _target = new ExpenseManagerContext("ExpenseManagerContextLocal");
        }

        [TearDown]
        public void OnTearDown()
        {
            _target.Dispose();
        }

        [Test]
        public void LocalTest()
        {
            var result = _target.CrewExpenseses.ToList().Count();
            Assert.AreEqual(result, 5);
        }
    }
}
