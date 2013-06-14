using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransAppWebSite.DataSources;

namespace TransAppWebSite.Models
{
    public class TaskViewModel
    {
        private UsersDataSource m_usersDataSource = new UsersDataSource();

        public TaskViewModel()
        { }

        public TaskViewModel(TaskViewModel taskViewModel)
        {
            Id = taskViewModel.Id;
            DeliveryNumber = taskViewModel.DeliveryNumber;
            Comment = taskViewModel.Comment;
            Company = taskViewModel.Company;
            User = taskViewModel.User;
            SenderAddress = taskViewModel.SenderAddress;
            ReciverAddress = taskViewModel.ReciverAddress;
            TaskStatus = taskViewModel.TaskStatus;
            LastModified = taskViewModel.LastModified;
            Contact = taskViewModel.Contact;
        }


        public TaskViewModel(Task task)
        {
            Id = task.Id;
            DeliveryNumber = task.DeliveryNumber;
            Comment = task.Comment;
            User = GetUser(task.Id);
            TaskStatus = (TaskStatus)task.TaskStatus;
            Company = User.Company;
            UsersListList = new UsersListViewModel(task.Company.Id);
            Created = task.Created;
            PickedUpAt = task.PickedUpAt;
            DeliveredAt = task.DeliveredAt;
            PickUpTime = task.PickUpTime;
            DeliveryTime = task.DeliveryTime;
            LastModified = task.LastModified;
        }

        private User GetUser(int userId)
        {
            var user = m_usersDataSource.GetUser(userId);
            return user;
        }

        public int Id { get; set; }
        public string DeliveryNumber { get; set; }
        public User User { get; set; }
        public Company Company { get; set; }
        public Address SenderAddress { get; set; }
        public Address ReciverAddress { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public DateTime Created { get; set; }
        public DateTime? PickedUpAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public DateTime? PickUpTime { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public DateTime LastModified { get; set; }
        //public bool Accepted { get; set; }
        //public bool PackageType { get; set; }
        public string Comment { get; set; }
        //public bool RejectionReason { get; set; }
        public Contact Contact { get; set; }
        //public int TaskType { get; set; }
        //insert generic data in future
        //public string DataExtention { get; set; }

        public UsersListViewModel UsersListList { get; set; }

        public Task ToTask()
        {
            var task = new Task();
            task.Id = this.Id;
            task.User.Id = this.User.Id;
            //task.CompanyId = this.Company.Id;
            //task.SenderAddressId = this.SenderAddress.Id;
            //task.ReciverAddressId = this.ReciverAddress.Id;
            task.TaskStatus = (int)this.TaskStatus;
            task.Comment = this.Comment;
            //task.ContactId = this.Contact.Id;

            return task;
        }
    }
}