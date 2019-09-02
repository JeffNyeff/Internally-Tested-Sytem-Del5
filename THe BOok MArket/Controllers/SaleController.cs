using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THe_BOok_MArket.Models;

namespace THe_BOok_MArket.Controllers
{
    public class SaleController : Controller
    {
        The_Book_MarketEntities db = new The_Book_MarketEntities();
        // GET: Sale
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "Name")
            {
                return View(db.Customers.Where(x => x.Customer_Name.Contains(search) || search == null).ToList());
            }
            else if (searchBy == "Surname")
            {
                return View(db.Customers.Where(x => x.Customer_Surname.StartsWith(search) || search == null).ToList());
            }

            else
            {
                List<Customer> customers = db.Customers.ToList();

            }
            return View(db.Customers);
        }

        int customerId = 0;
        int orderId = 0;
        public ActionResult SaveOrder(string name, long phone, string product, Sale[] order)
        {
            string result = "Error! could not complete sale!";
            if (name != null && product != null && order != null)
            {
                Customer model = new Customer();
                customerId += 1;
                model.Customer_Name = name;
                model.Customer_Contact = phone;
                model.Product_Name = product;
                model.Customer_ID = customerId;
                model.Date = DateTime.Now;
                db.Customers.Add(model);

                foreach (var item in order)
                {

                    orderId += 1;
                    Sale sale = new Sale()
                    {

                        Sale_ID = orderId,
                        Quantity = item.Quantity,
                        Price = item.Price,
                        Total = item.Total,
                        Customer_ID= customerId
                    };
                    db.Sales.Add(sale);

                }
                db.SaveChanges();

                result = "Success! Sale Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }





    }
}