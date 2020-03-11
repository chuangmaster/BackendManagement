using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Dapper.Models
{
    public class MemberModel
    {
        public Guid ID { get; set; }
        public string Account { get; set; }
        public byte[] Password { get; set; }
        public string Name { get; set; }
        public bool Enable { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Approve { get; set; }
        public string Mobile { get; set; }
    }
}
