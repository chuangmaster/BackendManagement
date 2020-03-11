using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Dapper.Models
{
    public class MemberRoleRelationModel
    {
        public int ID { get; set; }
        public Guid MemberID { get; set; }
        public int RoleID { get; set; }
    }
}
