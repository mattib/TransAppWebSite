using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TransAppWebSite.Models;

namespace TransAppWebSite.Utilities
{
    public static class CustomersExtentions
    {
        public static HtmlString CustomersGrid(this HtmlHelper htmlHelper, Customer[] companies)
        {

            var stringWriter = new StringWriter();

            using (var writer = new HtmlTextWriter(stringWriter))
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Table);

                writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Customer Id");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Name");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Address");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Contact");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("LastModified");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Customer Details");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Updater Customer");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Delete Customer");
                writer.RenderEndTag();
                writer.RenderEndTag();

                foreach (var company in companies)
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.Write(company.Id.ToString());
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.Write(company.Name);
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    var addressString = GetAddressString(company.Address);
                    writer.Write(addressString);
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    var contactString = GetContactString(company.Contact);
                    writer.Write(contactString);
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.Write(company.LastModified.ToString("dd-MM-yyyy HH:mm"));
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, "/Customers/Details/" + company.Id);
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.Write("Details");
                    writer.RenderEndTag();
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, "/Customers/Edit/" + company.Id);
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.Write("Update");
                    writer.RenderEndTag();
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, "/Customers/Delete/" + company.Id);
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.Write("Delete");
                    writer.RenderEndTag();
                    writer.RenderEndTag();
                    writer.RenderEndTag();
                }
                writer.RenderEndTag();
            }

            return new HtmlString(stringWriter.ToString());
        }

        private static string GetAddressString(Address address)
        {
            var result = string.Empty;

            if (address != null)
            {
                result = string.Format("{0} {1}, {2}", address.StreetName, address.StreetNumber, address.City);
            }
            return result;
        }

        private static string GetContactString(Contact contact)
        {
            var result = string.Empty;

            if (contact != null)
            {
                result = string.Format("{0} {1}", contact.FirstName, contact.LastName);
            }
            return result;
        }
    }
}