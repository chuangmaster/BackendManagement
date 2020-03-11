using Repository.Dapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Dapper.Interfaces
{
    public interface IApplicationRepository
    {
        List<ApplicationModel> Get();
    }
}
