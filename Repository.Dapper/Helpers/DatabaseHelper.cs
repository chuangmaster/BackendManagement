using Repository.Dapper.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Dapper.Helpers
{
    public class DatabaseHelper : IDatabaseHelper
    {
        private string _ConnectionString;
        public DatabaseHelper(string connectionString)
        {
            _ConnectionString = connectionString;
        }
        public string GetConnectionString()
        {
            return _ConnectionString;
        }
    }
}
