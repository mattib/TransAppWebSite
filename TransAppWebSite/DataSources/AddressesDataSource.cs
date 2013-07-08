using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json.Converters;
using TransAppWebSite.Models;

namespace TransAppWebSite.DataSources
{
    public class AddressesDataSource : TransAppConfiguration
    {
        private string m_addressesUrl;

        public AddressesDataSource()
        {
            m_addressesUrl = ApiServiceAddress + "/address";
        }

        public Address[] GetAllAddresses()
        {
            var result = string.Empty;
            using (var client = new WebClient())
            {
                var data = client.OpenRead(m_addressesUrl);
                var reader = new StreamReader(data);
                result = reader.ReadToEnd();
            }

            var addresses = (List<Address>)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<Address>));

            return addresses.ToArray();
        }

        public Address GetAddress(int id)
        {
            var result = string.Empty;
            using (var client = new WebClient())
            {
                var addressUrl = m_addressesUrl + "/" + id;
                var data = client.OpenRead(addressUrl);
                var reader = new StreamReader(data);
                result = reader.ReadToEnd();
            }

            var address = (Address)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(Address));
            return address;
        }

        public void SaveAddress(Address address)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(address, new IsoDateTimeConverter());
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");
                var responsebytes = client.UploadString(m_addressesUrl, "POST", json);
            }
        }

        public void DeleteAddress(int id)
        {
            using (var client = new WebClient())
            {
                var addressUrl = m_addressesUrl + "/" + id;
                client.UploadString(addressUrl, "DELETE", string.Empty);
            }
        }
    }
}