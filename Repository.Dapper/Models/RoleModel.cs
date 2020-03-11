using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Dapper.Models
{
    public class RoleModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enable { get; set; }
    }
}
