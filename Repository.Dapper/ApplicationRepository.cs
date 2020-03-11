using Repository.Dapper.Helpers.Interfaces;
using Repository.Dapper.Interfaces;
using Repository.Dapper.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
            using (var con = new SqlConnection(_Helper.GetConnectionString()))
            {
            }

            return result;
        }
    }
}
