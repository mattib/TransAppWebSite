using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
            RowStatus = taskViewModel.RowStatus;
        }


        public TaskViewModel(Task task)
        {
            Id = task.Id;
            DeliveryNumber = task.DeliveryNumber;
            Comment = task.Comment;
            User = task.User;
            TaskStatus = (TaskStatus)task.TaskStatus;
            Company = User.Company;
            ReciverAddress = task.ReciverAddress;
            SenderAddress = task.SenderAddress;
            UsersList = new UsersListViewModel(task.Company.Id);
            AddressesList = new AddressesListViewModel(task.Company.Id);
            Created = task.Created;
            PickedUpAt = task.PickedUpAt;
            DeliveredAt = task.DeliveredAt;
            if (!task.PickUpTime.HasValue)
            {
                PickUpTime = DateTime.Now;
            }
            else 
            {
                PickUpTime = task.PickUpTime.Value;
            }

            if (!task.DeliveryTime.HasValue)
            {
                DeliveryTime = DateTime.Now;
            }
            else
            {
                DeliveryTime = task.DeliveryTime.Value;
            }

            LastModified = task.LastModified;
            RowStatus = task.RowStatus;

            ImageId = task.ImageId;
            var baseUri = new Uri(TransAppConfiguration.ImageRepositoryAddress);
            if (!string.IsNullOrEmpty(task.ImageId))
            {
                ImageUri = new Uri(baseUri, task.ImageId + ".jpg/");
            }
            if (!string.IsNullOrEmpty(task.SignatureId))
            {
                SignatureUri = new Uri(baseUri, task.SignatureId + ".jpg/");
            }

            SignatureId = task.SignatureId;
            UserComment = task.UserComment;
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
        [Display(Name = "PickUpTime:"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime PickUpTime { get; set; }
        [Display(Name = "DeliveryTime:"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime DeliveryTime { get; set; }
        public DateTime LastModified { get; set; }
        public int RowStatus { get; set; }
        //public bool Accepted { get; set; }
        //public bool PackageType { get; set; }
        public string Comment { get; set; }
        //public bool RejectionReason { get; set; }
        public Contact Contact { get; set; }
        //public int TaskType { get; set; }
        //insert generic data in future
        //public string DataExtention { get; set; }
        public string SignatureId { get; set; }
        public string ImageId { get; set; }
        public string UserComment { get; set; }
        public Uri ImageUri { get; set; }
        public Uri SignatureUri { get; set; }
        public bool? Rejected { get; set; }

        public UsersListViewModel UsersList { get; set; }
        public AddressesListViewModel AddressesList { get; set; }

        public Task ToTask()
        {
            var task = new Task();
            task.Id = this.Id;
            task.User = new User();
            task.User.Id = this.User.Id;
            task.Company = new Company();
            task.Company.Id = 1;//this.Company.Id;
            task.SenderAddress = new Address();
            task.SenderAddress.Id = this.SenderAddress.Id;

            task.ReciverAddress = new Address();
            task.ReciverAddress.Id = this.ReciverAddress.Id;
            task.DeliveryNumber = this.DeliveryNumber;
            task.TaskStatus = (int)this.TaskStatus;
            task.Comment = this.Comment;
            task.Contact = new Contact();
            task.Contact.Id =1 ;// this.Contact.Id;
            task.RowStatus = this.RowStatus;
            task.PickUpTime = this.PickUpTime;
            task.DeliveryTime = this.DeliveryTime;
            task.ImageId = this.ImageId;
            task.SignatureId = this.SignatureId;
            task.UserComment = this.UserComment;
            task.Rejected = this.Rejected;

            return task;
        }
    }
}