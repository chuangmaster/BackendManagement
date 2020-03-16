using Dapper;
using Repository.Dapper.Helpers.Interfaces;
using Repository.Dapper.Interfaces;
using Repository.Dapper.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Dapper
{
    public class ApplicationRepository : BaseRepository, IApplicationRepository
    {
        public ApplicationRepository(IDatabaseHelper databaseHelper) : base(databaseHelper)
        {

        }
        public List<ApplicationModel> Get()
        {
            var result = new List<ApplicationModel>();
            using (var conn = new SqlConnection(_Helper.GetConnectionString()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM Application");
                result.AddRange(conn.Query<ApplicationModel>(sql.ToString()));
            }
            return result;
        }
    }
}
