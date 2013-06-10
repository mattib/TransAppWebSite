using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransAppWebSite.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyUserName { get; set; }
        public int ContactUserId { get; set; }
        public int AddressId { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public int RowStatus { get; set; }
        public int Active { get; set; }
        public int AmountOfUsers { get; set; }
        public int AmountOfTasksPerUser { get; set; }
    }
}