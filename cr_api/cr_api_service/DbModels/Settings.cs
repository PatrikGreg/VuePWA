using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cr_api_service.DbModels
{
    public class Settings
    {
        public string ConnectionString;
        public string Database;
        public IConfigurationRoot iConfigurationRoot;
    }
}
