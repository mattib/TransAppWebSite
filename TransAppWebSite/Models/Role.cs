using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransAppWebSite.Models
{
    public enum Role
    {
        ClientUser = 0,

        PortalRead,

        PortalEdit,

        Admin,

        AllAdmin
    }
}