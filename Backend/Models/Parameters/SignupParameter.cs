using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models.Parameters
{
    public class SignUpParameter
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordAgain { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }

    }
}