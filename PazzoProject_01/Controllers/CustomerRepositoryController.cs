using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DBRepostitory.Implement;
using DBRepostitory.Models;
using DBRepostitory.ViewModel;
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

        
        public async Task<JsonResult> GetCustomerList(int pageSize = 10, int skip = 0, int take = 10)
        {
            try
            {
                var customers = _res.Selects().AsQueryable();
                int count = customers.Count();
                var result = customers.OrderBy(x => x.CustomerID).Select(x=> new CustomerViewModel() {
                     CustomerID = x.CustomerID,
                     ContactName= x.ContactName,
                     Phone = x.Phone,
                     Address = x.Address
                }).Skip(skip).Take(take).ToList();

                return Json(new { data = result , total= count }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<JsonResult> SaveCustomer(CustomerViewModel detail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Customers data = new Customers()
                    //{
                    //    //Phone = "09-123456789",
                    //    PostalCode = "313",
                    //    Fax = "09-123456777",
                    //    Region = "Here",
                    //    CompanyName = "Name1=1",
                    //    City = "City",
                    //    ContactTitle = "Mr",
                    //    Country = "Country",
                    //    Phone = detail.Phone,
                    //    Address = detail.Address,
                    //    CustomerID = detail.CustomerID,
                    //    ContactName = detail.ContactName
                    //};

                    Mapper.Initialize(cfg=>
                        cfg.CreateMap<CustomerViewModel, Customers>()
                    );

                    Customers data = Mapper.Map<Customers>(detail);

                    if (!db.Customers.Any(c => c.CustomerID == data.CustomerID))
                    {
                        data.CustomerID = Guid.NewGuid().ToString().Substring(0, 5);
                        _res.Create(data);
                    }
                    else
                    {
                        _res.Update(data);
                    }

                    _res.SaveChanges();
                }

                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<JsonResult> DeleteCustomer(CustomerViewModel detail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Customers customer = new Customers()
                    {
                        CustomerID = detail.CustomerID
                    };

                    _res.Delete(customer);
    
                }
                _res.SaveChanges();

                return Json(new { data = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}