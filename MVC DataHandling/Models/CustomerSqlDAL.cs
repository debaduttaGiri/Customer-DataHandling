
namespace MVC_DataHandling.Models
{
    public class CustomerSqlDAL : ICustomerDAL
    {
        private readonly  MVCCoreDbContext context;
        public CustomerSqlDAL(MVCCoreDbContext context)
        {
            this.context = context;
        }

        public List<Customer> Customers_Select()
        {
            var customers = context.Customers.Where(C => C.Status ==true).ToList();
            return customers;
        }

        public void Customer_Delete(int CustId)
        {
            Customer customer = context.Customers.Find(CustId);
            if (customer == null) {
                throw new Exception("invalid Request");
                    }
            else
            {
                customer.Status = false;
                context.SaveChanges();
            }

        }

        public void Customer_Insert(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public Customer Customer_Select(int CustId)
        {
            Customer customer = context.Customers.Find(CustId);
            if (customer == null)
            {
                throw new Exception("No Customer exist's with given custid.");
            }
            return customer;
        }

        public void Customer_Update(Customer customer)
        {
            customer.Status = true;
            context.Update(customer);
            context.SaveChanges();
        }
    }
}
