using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Dapper.Models
{
    public class ApplicationModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> ParentID { get; set; }
        public bool Enable { get; set; }
        public string Url { get; set; }
        public int Sort { get; set; }
        public bool Blank { get; set; }
        public string Icon { get; set; }
        public bool ShowInMenu { get; set; }
    }
}
