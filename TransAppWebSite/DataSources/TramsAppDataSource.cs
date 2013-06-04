using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace TransAppWebSite.DataSources
{
    public class TransAppDataSource
    { 
        public string ApiServiceAddress = ConfigurationManager.AppSettings.Get("ApiServiceAddress");
    }
}