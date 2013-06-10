using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransAppWebSite.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public DateTime LastModified { get; set; }
        public int RowStatus { get; set; }
    }
}