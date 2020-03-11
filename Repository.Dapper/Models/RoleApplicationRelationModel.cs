using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Dapper.Models
{
    public class RoleApplicationRelationModel
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public int ApplicationID { get; set; }
    }
}
