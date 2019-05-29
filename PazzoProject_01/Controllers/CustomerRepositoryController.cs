using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBRepostitory.Implement;
using DBRepostitory.Models;
using PazzoProject_01.Utility;

namespace PazzoProject_01.Controllers
{
    public class CustomerRepositoryController : BaseController
    {
        private CustomerRepository<Customers> _res = null;
        public CustomerRepositoryController()
        {
            _res = new CustomerRepository<Customers>();
            
        }
        // GET: CustomerRepository
        public ActionResult Index()
        {
            var customers = _res.Selects().AsQueryable();

            List<Customers> result = customers.OrderBy(x => x.CustomerID).ToList();

            return View(result);
        }
    }
}