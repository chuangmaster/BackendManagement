using Backend.Models;
using Repository.Dapper;
using Repository.Dapper.Helpers.Interfaces;
using Repository.Dapper.Interfaces;
using System;
using System.Web;
using System.Web.Security;
using Backend.Models.Parameters;
using Repository.Dapper.Parameters;

namespace Backend.Infrastructure.Process
{
    public class AccountProcess
    {
        private IMemberRepository _MemberRepository;
        public AccountProcess(IDatabaseHelper databaseHelper)
        {
            _MemberRepository = new MemberRepository(databaseHelper);
        }


        /// <summary>
        /// 執行登入
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public BaseResultModel<object> DoLogin(LoginParameter parameter)
        {
            var result = new BaseResultModel<object>()
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
                cookie.Expires = now.AddHours(1);
                HttpContext.Current.Response.Cookies.Add(cookie);
                result.Result = true;
            }
            else
            {
                result.Message = "帳號或密碼錯誤";
                result.Description = "錯誤";
            }
            return result;
        }

        /// <summary>
        /// 執行登入
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public BaseResultModel<object> DoSignUp(SignUpParameter parameter)
        {
            var result = new BaseResultModel<object>()
            {
                Result = false
            };

            _MemberRepository.Create(new MemberAddRptParameter());
            return result;
        }
    }
}