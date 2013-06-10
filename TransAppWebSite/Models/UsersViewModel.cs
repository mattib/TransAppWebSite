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
            CompaniesUsersList = userOptions;                                       
        }
        public class UserModel
        {
            public UserModel(User user)
            {
                Id = user.Id;
                FirstName = user.FirstName;
                LastName = user.LastName;
                FullName = string.Format("{0} {1}", FirstName, LastName);
            }
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string FullName { get; set; }
        }

        public IEnumerable<UserModel> CompaniesUsersList; 


        [DisplayName("Full Name")]
        public string FullName { get; set; }
    }
}