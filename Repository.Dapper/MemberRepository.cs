﻿using Repository.Dapper.Helpers.Interfaces;
using Repository.Dapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Repository.Dapper.Models;
using Repository.Dapper.Parameters;

namespace Repository.Dapper
{
    public class MemberRepository : BaseRepository, IMemberRepository
    {
        public MemberRepository(IDatabaseHelper databaseHelper) : base(databaseHelper)
        {
        }

        /// <summary>
        /// 新增Member
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool Create(MemberAddRptParameter parameter)
        {
            using (var conn = new SqlConnection(_Helper.GetConnectionString()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Member (ID, Account, Password, Name, Enable, DateIn, ModifiedDate, Approve, Mobile) ");
                sql.AppendLine("VALUES(@ID, @Account, @Password, @Name, @Enable, @DateIn, @ModifiedDate, @Approve, @Mobile)");
                var result = conn.Execute(sql.ToString(), parameter);
                return result == 1;
            }
        }

        /// <summary>
        /// 更新Member
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool Update(MemberUpdateRptParameter parameter)
        {
            DynamicParameters sqlParameters = new DynamicParameters();
            var properties = new List<string>();
            if (!string.IsNullOrEmpty(parameter.Name))
            {
                sqlParameters.Add("Name", parameter.Name);
                properties.Add("Name");
            }

            if (!string.IsNullOrEmpty(parameter.Mobile))
            {
                sqlParameters.Add("Mobile", parameter.Mobile);
                properties.Add("Mobile");
            }

            if (parameter.Password.Length > 0)
            {
                sqlParameters.Add("Password", parameter.Password);
                properties.Add("Password");

            }

            if (parameter.Approve.HasValue)
            {
                sqlParameters.Add("Approve", parameter.Approve);
                properties.Add("Approve");

            }

            if (parameter.Enable.HasValue)
            {
                sqlParameters.Add("Enable", parameter.Enable);
                properties.Add("Enable");
            }

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE Member SET ");
            sql.AppendLine(string.Join(",", properties.Select(x => $"{x} = @{x}")));
            sql.AppendLine(" WHERE ID = @ID");
            sqlParameters.Add("ID", parameter.ID);

            using (var conn = new SqlConnection(_Helper.GetConnectionString()))
            {
                var result = conn.Execute(sql.ToString(), parameter);
                return result == 1;
            }
        }

        /// <summary>
        /// 用id取得Member
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MemberModel Get(Guid id)
        {
            using (var conn = new SqlConnection(_Helper.GetConnectionString()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM Member WHERE Id = @id");
                sql.AppendLine("SELECT * FROM MemberApplicationDeny WHERE MemberID = @id");
                sql.AppendLine("SELECT * FROM MemberRoleRelation WHERE MemberID = @id");

                var temp = conn.QueryMultiple(sql.ToString(), new { id });
                var member = temp.ReadFirstOrDefault<MemberModel>();
                var applicationDeny = temp.Read<MemberApplicationDenyModel>().ToList();
                var relation = temp.Read<MemberRoleRelationModel>().ToList();
                if (member != null)
                {
                    member.MemberApplicationDeny = applicationDeny;
                    member.MemberRoleRelation = relation;
                }
                return member;
            }
        }

        /// <summary>
        /// 取得Member
        /// </summary>
        /// <returns></returns>
        public List<MemberModel> Get()
        {
            using (var conn = new SqlConnection(_Helper.GetConnectionString()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM Member ");
                sql.AppendLine("SELECT * FROM MemberApplicationDeny");
                sql.AppendLine("SELECT * FROM MemberRoleRelation");
                var temp = conn.QueryMultiple(sql.ToString());

                var members = temp.Read<MemberModel>().ToList();
                var applicationDeny = temp.Read<MemberApplicationDenyModel>().ToList();
                var relation = temp.Read<MemberRoleRelationModel>().ToList();
                members.ForEach(m =>
                {
                    m.MemberApplicationDeny = applicationDeny.FindAll(a => a.MemberID == m.ID);
                    m.MemberRoleRelation = relation.FindAll(x => x.MemberID == m.ID);
                });
                return members;
            }
        }
    }
}
