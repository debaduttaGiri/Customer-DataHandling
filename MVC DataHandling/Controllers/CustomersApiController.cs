using Microsoft.AspNetCore.Http; 
using System.Net;
using Microsoft.AspNetCore.Mvc;
using MVC_DataHandling.Models;
using Microsoft.AspNetCore.Authorization;

namespace MVC_DataHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CustomersApiController : ControllerBase
    {
        public ICustomerDAL dal;
        public CustomersApiController(ICustomerDAL dal)
        {
            this.dal = dal;
        }
        [HttpGet]
        public List<Customer> Index()
        {
            return dal.Customers_Select();
        }
        [HttpGet("Get/{id}")]
        public Customer Get(int id)
        {
            return dal.Customer_Select(id);
        }
        [HttpPost]
        public HttpResponseMessage Post(Customer customer)
        {
             dal.Customer_Insert(customer);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

    }
}
