using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore
{
    public class ConnectionHelper
    {
        private IConfiguration _configuration;
        public string ConStr { get; set; }
        public ConnectionHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            ConStr = _configuration.GetConnectionString("DefaultConnection");
            return ConStr;
        }
    }
}
