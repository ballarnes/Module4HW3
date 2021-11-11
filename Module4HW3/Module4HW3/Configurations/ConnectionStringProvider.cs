using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Module4HW3.Configurations
{
    public class ConnectionStringProvider
    {
        public Config Init()
        {
            var configFile = File.ReadAllText("appsettings.json");
            var config = JsonConvert.DeserializeObject<Config>(configFile);
            return config;
        }
    }
}
