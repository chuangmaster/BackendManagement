using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Repository.Dapper.Helpers.Interfaces;
using Repository.Dapper.Interfaces;
using Repository.Dapper.Models;
using Repository.Dapper.Parameters;

namespace Repository.Dapper
{
    public class RoleRepository : BaseRepository, IRoleRepository
    {
        public RoleRepository(IDatabaseHelper databaseHelper) : base(databaseHelper)
        {

        }

        /// <summary>
        /// 取得Role
        /// </summary>
        /// <returns></returns>
        public List<RoleModel> Get()
        {
            using (var conn = new SqlConnection(_Helper.GetConnectionString()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM Role");
                sql.AppendLine("SELECT * FROM RoleApplicationRelation");

                var temp = conn.QueryMultiple(sql.ToString());
                var roles = temp.Read<RoleModel>().ToList();
                var relations = temp.Read<RoleApplicationRelationModel>().ToList();
                roles.ForEach(x => { x.Relation = relations.FindAll(y => y.RoleID == x.ID); });
                return roles;
            }
        }

        /// <summary>
        /// 新增 Role
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool Create(RoleAddRptParameter parameter)
        {
            using (var conn = new SqlConnection(_Helper.GetConnectionString()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Role (Name, Description, Enable) VALUES(@Name, @Description, @Enable)");
                var result = conn.Execute(sql.ToString(), parameter);
                return result == 1;
            }
        }
    }
}
