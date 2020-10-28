using ApplicationCore;
using Microsoft.Extensions.Configuration;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        readonly public ConnectionHelper dbCon;
        public string constr { get; set; }
        public Repository(IConfiguration configuration)
        {
            dbCon = new ConnectionHelper(configuration);
            constr = dbCon.GetConnection();
        }

    }
}
