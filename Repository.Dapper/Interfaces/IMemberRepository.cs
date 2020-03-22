using Repository.Dapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Dapper.Parameters;

namespace Repository.Dapper.Interfaces
{
    public interface IMemberRepository
    {
        /// <summary>
        /// 新增Member
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool Create(MemberAddRptParameter parameter);

        /// <summary>
        /// 更新Member
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool Update(MemberUpdateRptParameter parameter);

        /// <summary>
        /// 用id取得Member
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MemberModel Get(Guid id);

        /// <summary>
        /// 取得Member
        /// </summary>
        /// <returns></returns>
        List<MemberModel> Get();

        /// <summary>
        /// 用account取得Member
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        ///
        /// <returns></returns>
         MemberModel CheckLogin(string account, string password)

    }
}
