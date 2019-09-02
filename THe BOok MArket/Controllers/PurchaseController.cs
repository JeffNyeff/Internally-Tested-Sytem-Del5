using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THe_BOok_MArket.Models;

namespace THe_BOok_MArket.Controllers
{
    public class PurchaseController : Controller
    {
        The_Book_MarketEntities db = new The_Book_MarketEntities();
        // GET: Purchase
        public ActionResult Index( string searchBy, string search)
        {
            if (searchBy == "Name")
            {
                return View(db.Book_Supplier.Where(x => x.BookSupplier_Name.Contains(search) || search == null).ToList());
            }
            else if (searchBy == "Phone")
            {
                return View(db.Book_Supplier.Where(x => x.BookSupplier_Phone.StartsWith(search) || search == null).ToList());
            }
            

            else
            {
                List<Book_Supplier> suppliers = db.Book_Supplier.ToList();

            }
            return View(db.Book_Supplier);
        }


        int customerId = 0;
        int orderId = 0;
        public ActionResult SaveOrder(string name, String phone, string title, string condition, string edition, Purchase[] order)
        {
            string result = "Error! could not complete purchase!";
            if (name != null && phone != null && title != null && condition != null && edition != null && order != null)
            {
                Book_Supplier model = new Book_Supplier();
                customerId += 1;
                model.BookSupplier_Name = name;
                model.BookSupplier_Phone = phone;
                model.BookTitle = title;
                model.Condition = condition;
                model.Edition = edition;
                model.BookSupplier_ID = customerId;
                model.Date = DateTime.Now;

                db.Book_Supplier.Add(model);

                foreach (var item in order)
                {

                    orderId += 1;
                    Purchase purchase= new Purchase()
                    {

                        Purchase_ID = orderId,
                        Quantity = item.Quantity,
                        Price = item.Price,
                        Amount = item.Amount,
                        BookSupplier_ID = customerId
                    };
                    db.Purchases.Add(purchase);


                }
                db.SaveChanges();

                result = "Success! Purchase Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}