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
    public class UsersDataSource : TransAppDataSource
    {
        private string m_usersUrl;

        public UsersDataSource()
        {
            m_usersUrl = ApiServiceAddress + "/user";
        }

        public User[] GetAllUsers()
        {
            var result = string.Empty;
            using (var client = new WebClient())
            {
                var data = client.OpenRead(m_usersUrl);
                var reader = new StreamReader(data);
                result = reader.ReadToEnd();
            }

            var users = (List<User>)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<User>));

            return users.ToArray();
        }

        public User[] GetUsersByCompanyId(int companyId)
        {
            var result = string.Empty;
            using (var client = new WebClient())
            {
                var userUrl = m_usersUrl + "/?comapnyId=" + companyId;
                var data = client.OpenRead(userUrl);
                var reader = new StreamReader(data);
                result = reader.ReadToEnd();
            }

            var users = (List<User>)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<User>));
            return users.ToArray();
        }

        public User GetUser(int id)
        {
            var result = string.Empty;
            using (var client = new WebClient())
            {
                var userUrl = m_usersUrl + "/" + id;
                var data = client.OpenRead(userUrl);
                var reader = new StreamReader(data);
                result = reader.ReadToEnd();
            }

            var user = (User)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(User));
            return user;
        }

        public User GetUser(string userName)
        {
            var result = string.Empty;
            using (var client = new WebClient())
            {
                var userUrl = m_usersUrl + "/?username=" + userName;
                var data = client.OpenRead(userUrl);
                var reader = new StreamReader(data);
                result = reader.ReadToEnd();
            }

            var user = (User)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(User));
            return user;
        }

        public void SaveUser(User user)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(user, new IsoDateTimeConverter());
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");
                var responsebytes = client.UploadString(m_usersUrl, "POST", json);
            }
        }

        public void DeleteUser(int id)
        {
            using (var client = new WebClient())
            {
                var userUrl = m_usersUrl + "/" + id;
                client.UploadString(userUrl, "DELETE", string.Empty);
            }
        }
    }
}