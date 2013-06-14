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
    public class ContactsDataSource : TransAppDataSource
    {
        private string m_contactsUrl;

        public ContactsDataSource()
        {
            m_contactsUrl = ApiServiceAddress + "/contact";
        }

        public Contact[] GetAllContacts()
        {
            var result = string.Empty;
            using (var client = new WebClient())
            {
                var data = client.OpenRead(m_contactsUrl);
                var reader = new StreamReader(data);
                result = reader.ReadToEnd();
            }

            var contacts = (List<Contact>)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<Contact>));

            return contacts.ToArray();
        }

        public Contact GetContact(int id)
        {
            var result = string.Empty;
            using (var client = new WebClient())
            {
                var eventUrl = m_contactsUrl + "/" + id;
                var data = client.OpenRead(eventUrl);
                var reader = new StreamReader(data);
                result = reader.ReadToEnd();
            }

            var contact = (Contact)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(Contact));
            return contact;
        }

        public void SaveContact(Contact contact)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(contact, new IsoDateTimeConverter());
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");
                var responsebytes = client.UploadString(m_contactsUrl, "POST", json);
            }
        }

        public void DeleteContact(int id)
        {
            using (var client = new WebClient())
            {
                var eventUrl = m_contactsUrl + "/" + id;
                client.UploadString(eventUrl, "DELETE", string.Empty);
            }
        }
    }
}