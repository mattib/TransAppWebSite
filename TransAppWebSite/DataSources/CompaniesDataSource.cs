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
    public class CompaniesDataSource : TransAppConfiguration
    {
        private string m_companiesUrl;

        public CompaniesDataSource()
        {
            m_companiesUrl = ApiServiceAddress + "/company";
        }

        public Company[] GetAllCompanies()
        {
            var result = string.Empty;
            using (var client = new WebClient())
            {
                var data = client.OpenRead(m_companiesUrl);
                var reader = new StreamReader(data);
                result = reader.ReadToEnd();
            }

            var companies = (List<Company>)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<Company>));

            return companies.ToArray();
        }

        public Company GetCompany(int id)
        {
            var result = string.Empty;
            using (var client = new WebClient())
            {
                var eventUrl = m_companiesUrl + "/" + id;
                var data = client.OpenRead(eventUrl);
                var reader = new StreamReader(data);
                result = reader.ReadToEnd();
            }

            var eventItem = (Company)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(Company));
            return eventItem;
        }

        public void SaveCompany(Company company)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(company, new IsoDateTimeConverter());
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");
                var responsebytes = client.UploadString(m_companiesUrl, "POST", json);
            }
        }

        public void DeleteCompany(int id)
        {
            using (var client = new WebClient())
            {
                var eventUrl = m_companiesUrl + "/" + id;
                client.UploadString(eventUrl, "DELETE", string.Empty);
            }
        }
    }
}