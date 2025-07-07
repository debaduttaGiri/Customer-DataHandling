using System.Data;

namespace MVC_DataHandling.Models
{
    public class CustomerXmlDAL:ICustomerDAL
    {
        DataSet dataSet;
        public CustomerXmlDAL() { 
            dataSet = new DataSet();
            dataSet.ReadXml("Customer.xml");
            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                dataSet.Tables[0].PrimaryKey = new DataColumn[] { dataSet.Tables[0].Columns["CustId"] };
            }
            else
            {
                DataTable dt = new DataTable("Customer");
                dt.Columns.Add("CustId", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Balance", typeof(decimal));
                dt.Columns.Add("City",typeof(string));
                dt.Columns.Add("Status",typeof(bool));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["CustId"] };
                dataSet.Tables.Add(dt);
            }
        }
        public List<Customer> Customers_Select()
        {
            List<Customer>
                customer = new List<Customer>();
            foreach(DataRow  dr in dataSet.Tables[0].Rows)
            {
                Customer obj = new Customer
                {
                    CustId = Convert.ToInt32(dr["Custid"]),
                    Name = Convert.ToString(dr["Name"]),
                    Balance = Convert.ToDecimal(dr["Balance"]),
                    City = Convert.ToString(dr["City"]),
                    Status = Convert.ToBoolean(dr["Status"])
                };
                customer.Add(obj);
            }
            return customer;
        }
        public Customer Customer_Select(int id)
        {
            DataRow dr = dataSet.Tables[0].Rows[id];
            Customer customer = new Customer
            {
                CustId = Convert.ToInt32(dr["Custid"]),
                Name = Convert.ToString(dr["Name"]),
                Balance = Convert.ToDecimal(dr["Balance"]),
                City = Convert.ToString(dr["City"]),
                Status = Convert.ToBoolean(dr["Status"])
            };
            return customer;
        }
        public void Customer_Insert(Customer customer)
        {
            DataRow dr = dataSet.Tables[0].NewRow();
            dr["Custid"] = customer.CustId;
            dr["Name"] = customer.Name;
            dr["Balance"] = customer.Balance;
            dr["City"] = customer.City;
            dr["Status"] = customer.Status;

            dataSet.Tables[0].Rows.Add(dr);
            dataSet.WriteXml("Customer.xml");   
        }
        public void Customer_Update(Customer customer) 
            {
                DataRow dr = dataSet.Tables[0].Rows.Find(customer.CustId);

                int index = dataSet.Tables[0].Rows.IndexOf(dr);
                dataSet.Tables[0].Rows[index]["Name"] = customer.Name;
                dataSet.Tables[0].Rows[index]["Balance"] = customer.Balance;
                dataSet.Tables[0].Rows[index]["City"] = customer.City;
                dataSet.WriteXml("Customer.xml");
            }
        public void Customer_Delete(int id)
        {
            DataRow dr = dataSet.Tables[0].Rows.Find(id);
            int index = dataSet.Tables[0].Rows.IndexOf(dr);
            dataSet.Tables[0].Rows[index].Delete();
            dataSet.WriteXml("Customer.xml");
        }
    }
}
