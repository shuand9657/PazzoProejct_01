using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBModel.Models;

namespace PazzoProject_01.Controllers
{
    public class EFCustomerController : Controller
    {
        // GET: EFCustomer
        public ActionResult Index(int? pageNumber)
        {
            Customers customers = new Customers();
            ProductModel model = new ProductModel();
            model.PageSize = 10;
            model.PageNumber = pageNumber == null ? 1 : Convert.ToInt32(pageNumber);

            NorthwindEntities db = new NorthwindEntities();
            model.CustomerItems =  db.Customers.OrderBy(x => x.CustomerID)
                ?.Skip(model.PageSize * (model.PageNumber - 1))
                .Take(model.PageSize).ToList();
            model.TotalCount = db.Customers.Count();
            model.PageCount = 1 + ((model.TotalCount / model.PageSize) - (model.TotalCount % model.PageSize == 0 ? 1 : 0));

            return View(model);
        }
    }

    public class ProductModel
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public  int PageCount { get; set; }
        public int TotalCount { get; set; }
        public List<Customers> CustomerItems { get; set; }
    }
}