using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Dapper.Parameters
{
    public class MemberAddRptParameter
    {
        public Guid ID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool Enable { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Approve { get; set; }
        public string Mobile { get; set; }
    }
}
