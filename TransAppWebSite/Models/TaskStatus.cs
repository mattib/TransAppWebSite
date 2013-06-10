using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransAppWebSite.Models
{
    public enum TaskStatus
    {
        Created = 0,

        Assigned,

        Started,

        Accepted,

        Rejected,

        Finished,

        Canceled,

        Reassigned
    }
}