using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransAppWebSite.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string DeliveryNumber { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int SenderAddressId { get; set; }
        public int ReciverAddressId { get; set; }
        public int TaskStatus { get; set; }
        public DateTime Created { get; set; }
        public DateTime PickedUpAt { get; set; }
        public DateTime DeliveredAt { get; set; }
        public DateTime PickUpTime { get; set; }
        public DateTime DeliveryTime { get; set; }
        public DateTime LastModified { get; set; }
        public bool Accepted { get; set; }
        public bool PackageType { get; set; }
        public string Comment { get; set; }
        public bool RejectionReason { get; set; }
        public int ContactId { get; set; }
        public int RowStatus { get; set; }
        public int TaskType { get; set; }
        public string DataExtention { get; set; }
    }
}