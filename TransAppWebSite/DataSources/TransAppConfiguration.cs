using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace TransAppWebSite.DataSources
{
    public class TransAppConfiguration
    {
        public static string ApiServiceAddress = ConfigurationManager.AppSettings.Get("ApiServiceAddress");

        public static string ImageRepositoryAddress = ConfigurationManager.AppSettings.Get("ImageRepositoryAddress");
    }
}