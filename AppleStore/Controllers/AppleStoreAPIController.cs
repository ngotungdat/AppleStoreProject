using AppleStore.Model;
using AppleStoreIAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppleStore.Controllers
{
    public class AppleStoreAPIController : ApiController
    {
        // GET: api/AppleStoreAPI
        private IProduct iproduct;
        public AppleStoreAPIController(IProduct product)
        {
            iproduct = product;
        }
        [Route("getall")]
        [HttpGet]
        public List<SanPham> Get()
        {
            return iproduct.GetProduct();
        }

        // GET: api/AppleStoreAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AppleStoreAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AppleStoreAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AppleStoreAPI/5
        public void Delete(int id)
        {
        }
    }
}
