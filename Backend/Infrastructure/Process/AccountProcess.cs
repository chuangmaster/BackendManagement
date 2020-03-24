using Backend.Models;
using Repository.Dapper;
using Repository.Dapper.Helpers.Interfaces;
using Repository.Dapper.Interfaces;
using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using AutoMapper;
using Backend.Infrastructure.Consts;
using Backend.Infrastructure.Profiles;
using Backend.Models.Parameters;
using Repository.Dapper.Models;
using Repository.Dapper.Parameters;

namespace Backend.Infrastructure.Process
{
    public class AccountProcess
    {
        private IMemberRepository _MemberRepository;
        private IMapper _Mapper;
        public AccountProcess(IDatabaseHelper databaseHelper)
        {
            _MemberRepository = new MemberRepository(databaseHelper);
            _Mapper = ApplicationMapper.Mapper;
        }


        /// <summary>
        /// 執行登入
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public BaseResultModel<MemberModel> DoLogin(LoginParameter parameter)
        {
            var result = new BaseResultModel<MemberModel>()
            {
                Result = false
            };

            var memeber = _MemberRepository.CheckLogin(parameter.Email, parameter.Password);

            if (memeber != null)
            {
                var now = DateTime.Now;
                var ticket = new FormsAuthenticationTicket(
                    version: 1,
                    name: memeber.Name,
                    issueDate: DateTime.Now,
                    expiration: now.AddHours(1),
                    isPersistent: false,
                    userData: memeber.Account,
                    cookiePath: FormsAuthentication.FormsCookiePath);
                var encryptTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
                cookie.Expires = ticket.Expiration;
                HttpContext.Current.Response.Cookies.Add(cookie);
                HttpContext.Current.Session.Add(ApplicationConst.LoginSessionKey, memeber);
                result.Result = true;
                result.Data = memeber;
            }
            else
            {
                result.Message = "帳號或密碼錯誤";
                result.Description = "錯誤";
            }
            return result;
        }

        /// <summary>
        /// 執行註冊
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public BaseResultModel<object> DoSignUp(SignUpParameter parameter)
        {
            var result = new BaseResultModel<object>()
            {
                Result = false
            };
            var rptParameter = _Mapper.Map<MemberAddRptParameter>(parameter);
            var member = _MemberRepository.Get().FirstOrDefault(x => x.Account == parameter.Email);
            if (member != null)
            {
                result.Message = "信箱已經被註冊";
                result.Description = "錯誤";
            }
            else
            {
                var rptResult = _MemberRepository.Create(rptParameter);
                if (rptResult)
                {
                    result.Message = "註冊成功";
                    result.Description = "成功";
                }
                else
                {
                    result.Message = "註冊失敗";
                    result.Description = "註冊失敗";
                }
            }
            return result;
        }
    }
}