using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransAppWebSite.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int LastName { get; set; }
        public string OfficeNumber { get; set; }
        public string CellNumber { get; set; }
        public string Email { get; set; }
        public string AddressId { get; set; }
        public DateTime LastModified { get; set; }
        public int RowStatus { get; set; }
    }
}