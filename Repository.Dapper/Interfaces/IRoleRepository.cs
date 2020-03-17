using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Dapper.Models;

namespace Repository.Dapper.Interfaces
{
    public interface IRoleRepository
    {
        /// <summary>
        /// 取得Role
        /// </summary>
        /// <returns></returns>
        List<RoleModel> Get();
    }
}
