using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using TransAppWebSite.DataSources;

namespace TransAppWebSite.Models
{
    public class UsersViewModel
    {
        public UsersViewModel(int comapnyId)
        {
            var userOptions = new List<UserModel>();
            var usersDataSource = new UsersDataSource();
            var users = usersDataSource.GetUsersByCompanyId(comapnyId);
            foreach(var user in users)
            {
                userOptions.Add(new UserModel(user));
            }
            UsersOptions = userOptions;                                       
        }
        public class UserModel
        {
            public UserModel(User user)
            {
                Id = user.Id;
                UserName = user.UserName;
            }
            public int Id { get; set; }
            public string UserName { get; set; }
        }

        public IEnumerable<UserModel> UsersOptions; 


        [DisplayName("User Name")]
        public string UserName { get; set; }
    }
}