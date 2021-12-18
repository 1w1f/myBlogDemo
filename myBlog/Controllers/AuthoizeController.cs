using System.Text;
using System;
using System.Threading.Tasks;
using Iservice;
using Microsoft.AspNetCore.Mvc;
using MyModel.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using myBlogDemo.Utility.ApiResult;
using myBlogDemo.Utility.Common;

namespace myBlogDemo.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthoizeController : ControllerBase
    {
        private IWriteInfoService _IWriterInfoService;


        public AuthoizeController(IWriteInfoService writeInfoService)
        {
            _IWriterInfoService = writeInfoService;
        }

        [HttpPost("login")]
        public async Task<ApiResult> Login(string username, string password)
        {
            var Md5Encrypt = Md5Helper.Md5Encrypt(password);
            WriterInfo writer = await _IWriterInfoService.FindAsync(item => item.Name == username && item.PassWord == Md5Encrypt);
            if (writer != null)
            {
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name,writer.Name),
                    new Claim("Id",writer.Id.ToString()),
                    new Claim("Username",writer.UserName),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("myBl-ogJw-tsss-sssu"));
                var token = new JwtSecurityToken(
                    issuer: "http://192.168.50.16:5000",
                    audience: "http://192.168.50.16:5000",
                    claims: claims, 
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
                var jwtToken=new JwtSecurityTokenHandler().WriteToken(token);
                return ApiResultHelper.Success(jwtToken);
            }
            return ApiResultHelper.Error("账号密码错误");
        }



    }
}
