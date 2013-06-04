using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
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
            var result = string.Empty;
            using (var client = new WebClient())
            {
                var reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("Id", user.Id.ToString());
                reqparm.Add("FisrtName", user.FisrtName);
                reqparm.Add("LastName", user.LastName);
                reqparm.Add("UserName", user.UserName);
                reqparm.Add("PhoneNumber", user.PhoneNumber);
                reqparm.Add("Email", user.Email);
                reqparm.Add("ReferenceId", user.ReferenceId);
                reqparm.Add("Password", user.Password);
                reqparm.Add("CompanyId", user.CompanyId.ToString());
                reqparm.Add("Role", user.Role.ToString());
                reqparm.Add("TimeCreated", user.TimeCreated.ToString());
                reqparm.Add("LastModified", user.LastModified.ToString());
                reqparm.Add("RowStatus", user.RowStatus.ToString());
                reqparm.Add("Active", user.Active.ToString());
                var responsebytes = client.UploadValues(m_usersUrl, "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(responsebytes);
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