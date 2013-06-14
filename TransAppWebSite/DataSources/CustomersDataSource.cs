using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Converters;
using TransAppWebSite.Models;

namespace TransAppWebSite.DataSources
{
    public class CustomersDataSource : TransAppDataSource
    {
        private string m_customersUrl;

        public CustomersDataSource()
        {
            m_customersUrl = ApiServiceAddress + "/customer";
        }

        public Customer[] GetAllCustomers()
        {
            var result = string.Empty;
            using (var client = new WebClient())
            {
                var data = client.OpenRead(m_customersUrl);
                var reader = new StreamReader(data);
                result = reader.ReadToEnd();
            }

            var customer = (List<Customer>)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<Customer>));

            return customer.ToArray();
        }

        public Customer GetCustomer(int id)
        {
            var result = string.Empty;
            using (var client = new WebClient())
            {
                var eventUrl = m_customersUrl + "/" + id;
                var data = client.OpenRead(eventUrl);
                var reader = new StreamReader(data);
                result = reader.ReadToEnd();
            }

            var customer = (Customer)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(Customer));
            return customer;
        }

        public void SaveCustomer(Customer customer)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(customer, new IsoDateTimeConverter());
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");
                var responsebytes = client.UploadString(m_customersUrl, "POST", json);
            }
        }

        public void DeleteCustomer(int id)
        {
            using (var client = new WebClient())
            {
                var customerUrl = m_customersUrl + "/" + id;
                client.UploadString(customerUrl, "DELETE", string.Empty);
            }
        }
    }
}