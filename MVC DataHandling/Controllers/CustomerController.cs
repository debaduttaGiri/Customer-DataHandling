using Microsoft.AspNetCore.Mvc;
using MVC_DataHandling.Models;
using Microsoft.AspNetCore.Authorization;

namespace MVC_DataHandling.Controllers
{
    public class CustomerController : Controller
    {
        //CustomerXmlDAL obj = new CustomerXmlDAL();
        private readonly ICustomerDAL obj;
        public CustomerController(ICustomerDAL obj)
        {
            this.obj = obj;
        }

        public IActionResult Index()
        {
            return View(obj.Customers_Select());
        }
        public ViewResult Get(int CustId)
        {
            return View(obj.Customer_Select(CustId));
        }
        
        public ViewResult Post()
        {
            return View();
        }
        [HttpPost]
        public RedirectToActionResult Post(Customer customer)
        {
            obj.Customer_Insert(customer);
            return RedirectToAction("Index");
        }
       
        public ViewResult Put(int CustId)
        {
            return View(obj.Customer_Select(CustId));
        }
        [HttpPost]
        public RedirectToActionResult Put(Customer customer)
        {
            obj.Customer_Update(customer);
            return RedirectToAction("Index");
        }
      
        public RedirectToActionResult Delete(int Custid)
        {
            obj.Customer_Delete(Custid);
            return RedirectToAction("index");
        }

    }
}
