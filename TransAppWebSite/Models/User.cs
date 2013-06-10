using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransAppWebSite.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ReferenceId { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
        public int Role { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime LastModified { get; set; }
        public int RowStatus { get; set; }
        public int Active { get; set; }
    }
}