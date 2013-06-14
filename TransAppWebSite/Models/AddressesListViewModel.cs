using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using TransAppWebSite.DataSources;

namespace TransAppWebSite.Models
{
    public class AddressesListViewModel
    {
    //    public AddressesListViewModel(int comapnyId)
    //    {
    //        var addressesList = new List<AddressModel>();
    //        var addressesDataSource = new AddressesDataSource();
    //        var addresses = addressesDataSource.GetAddress(comapnyId);
    //        foreach (var address in addresses)
    //        {
    //            addressesList.Add(new AddressModel(address));
    //        }
    //        CompaniesUsersList = addressesList;                                       
    //    }
    //    public class AddressModel
    //    {
    //        public AddressModel(Address address)
    //        {
    //            Id = address.Id;
    //            AddressString = string.Format("{0} {1}, {2}", address.StreetName, address.StreetNumber, address.City);
    //        }
    //        public int Id { get; set; }
    //        public string AddressString { get; set; }
    //    }

    //    public IEnumerable<AddressModel> CompaniesUsersList;


    //    [DisplayName("Address String")]
    //    public string AddressString { get; set; }
    }
}