using AppleStoreAL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppleStoreTEST
{
    [TestFixture]
    public class SearchTest
    {
        private Product prod;
        [SetUp]
        public void SetUp()
        {
            prod = new Product();
        } 
        [Test]
        [TestCase(0)]
        public void Test_Detail(string id)
        {
            var result = prod.Detail(id);
            Assert.AreEqual(result, id);
        }
    }
}
