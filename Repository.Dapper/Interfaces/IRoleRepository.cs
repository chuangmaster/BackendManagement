using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Dapper.Models;
using Repository.Dapper.Parameters;

namespace Repository.Dapper.Interfaces
{
    public interface IRoleRepository
    {
        /// <summary>
        /// 取得Role
        /// </summary>
        /// <returns></returns>
        List<RoleModel> Get();
        /// <summary>
        /// 新增 Role
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool Create(RoleAddRptParameter parameter);
    }
}
