using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Dapper.Models
{
    public class MemberApplicationDenyModel
    {
        public int ID { get; set; }
        public Guid MemberID { get; set; }
        public int ApplicationID { get; set; }
    }
}
