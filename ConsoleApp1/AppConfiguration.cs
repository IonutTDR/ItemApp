using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class AppConfiguration
    {
        //constructor
        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder(); // obtains configuration settings
            configBuilder.AddJsonFile(@"C:\Users\Ionut\source\repos\ItemApp\API\appsettings.json", false);
            var root = configBuilder.Build();
            var appSetting = root.GetSection("ConnectionStrings:ItemDBConnection");

            SqlConnectionString = appSetting.Value;
        }

        public string SqlConnectionString { get; set; }
    }
}
