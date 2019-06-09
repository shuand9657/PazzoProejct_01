using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using AutoMapper.Configuration;
using BussinessLogic.Implement;
using DBRepostitory.Models;
using DBRepostitory.ViewModel;

namespace BussinessLogic.Controllers
{
    public class CustomersController : ApiController
    {
        // RestFul API Http Verb Get[R] Post[Update] Put[Create] Delete .....

        #region "非正規Restful用法"
        //[Route("api/Customers/GetCustomer")]
        //// GET api/<controller>
        //public IEnumerable<string> GetCustomer()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //[Route("api/Customers/GetCustomerByID")]
        //// GET api/<controller>
        //public IEnumerable<string> GetCustomerByID()
        //{
        //    return new string[] { "value3", "value4" };
        //}
        #endregion

        private CustomerService _service = null;

        public CustomersController()
        {
            _service = new CustomerService();
        }

        public List<CustomerViewModel> GetCustomers()
        {
            try
            {
                var customerData = _service.Selects().OrderBy(x => x.ContactName);

                Mapper.Initialize(cfg => { cfg.CreateMap<List<Customers>, List<CustomerViewModel>>(); });

                List<CustomerViewModel> result = Mapper.Map<List<CustomerViewModel>>(customerData);

                //var cfg = new MapperConfigurationExpression(); // 建立設定
                //cfg.CreateMap<List<CustomerViewModel>, List<Customers>>(); // 對應 <來源,欲修改> 
                //Mapper.Initialize(cfg);

                ////var result = Mapper.Map<IOrderedQueryable<Customers>, List<CustomerViewModel>>(customerData).ToList();
                //var result = Mapper.Map<List<CustomerViewModel>>(customerData.ToList());
                ////Mapper.Initialize(cfg => {
                ////    cfg.AllowNullCollections = true;
                ////    cfg.CreateMap<IOrderedQueryable<Customers>, IOrderedQueryable<CustomerViewModel>>(customerData);
                ////});

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
        

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}