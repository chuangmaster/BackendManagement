using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class BaseResultModel<T>
    {
        public string Description { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }

        public bool Result { get; set; }
    }
}