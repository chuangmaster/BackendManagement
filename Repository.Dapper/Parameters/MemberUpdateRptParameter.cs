using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Dapper.Parameters
{
    public class MemberUpdateRptParameter
    {
        public Guid ID { get; set; }
        public byte[] Password { get; set; }
        public string Name { get; set; }
        public bool? Enable { get; set; }
        public bool? Approve { get; set; }
        public string Mobile { get; set; }
    }
}
