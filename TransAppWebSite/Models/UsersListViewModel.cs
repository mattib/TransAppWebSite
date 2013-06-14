using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using TransAppWebSite.DataSources;

namespace TransAppWebSite.Models
{
    public class UsersListViewModel
    {
        public UsersListViewModel(int comapnyId)
        {
            var usersDataSource = new UsersDataSource();
            var users = usersDataSource.GetUsersByCompanyId(comapnyId);
            var userOptions = users.Select(user => new UserModel(user)).ToList();
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