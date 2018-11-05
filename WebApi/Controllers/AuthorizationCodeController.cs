using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICH.Authorize;
using ICH.Util.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    /// <summary>
    /// 权限校验
    /// </summary>
    [Route("api/[controller]")]
    public class AuthorizationCodeController : Controller
    {
        private readonly ILogger _logger;
        private readonly IAuthorizeClient _client;
        public AuthorizationCodeController(ILogger<AuthorizationCodeController> logger, IAuthorizeClient client)
        {
            _logger = logger;
            _client = client;
        }

        /// <summary>
        /// 根据code得到令牌信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]AuthorizationCodeModel data)
        {
            var (error, result) = await _client.GetToken(data.code, data.state, data.redirect_uri);

            return !string.IsNullOrEmpty(error)
                ? Ok(ResponseResult.Execute("10027", error))
                : (IActionResult)Json(ResponseResult.Execute(new
                {
                    access_token = result.AccessToken,
                    token_type = result.TokenType,
                    expires_in = result.ExpiresIn,
                    refresh_token = result.RefreshToken
                }));
        }
    }
    public class AuthorizationCodeModel
    {
        /// <summary>
        /// 授权码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 状态值
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// 重定向URI
        /// </summary>
        public string redirect_uri { get; set; }
    }
}