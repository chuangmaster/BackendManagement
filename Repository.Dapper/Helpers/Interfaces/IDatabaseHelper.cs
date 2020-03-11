using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Dapper.Helpers.Interfaces
{
    public interface IDatabaseHelper
    {
        /// <summary>
        /// Get database connection string
        /// </summary>
        /// <returns></returns>
        string GetConnectionString();
    }
}
