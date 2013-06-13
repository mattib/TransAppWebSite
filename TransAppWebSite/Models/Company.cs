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
        public Address Address { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public int RowStatus { get; set; }
        public int? AmountOfUsers { get; set; }
        public int? AmountOfTasksPerUser { get; set; }
        public string CompanyInfo { get; set; }
    }
}