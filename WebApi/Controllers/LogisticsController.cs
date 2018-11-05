using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICH.Util.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    /// <summary>
    /// 物流服务
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LogisticsController : Controller
    {
        /// <summary>
        /// 物流服务查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("LogisticsList")]
        [Authorize]
        public IActionResult LogisticsList()
        {
            List<Logistics> list = new List<Logistics>();
            return (IActionResult)Json(ResponseResult.Execute(new
            {
                data = list,
                code = 0,
                message = "success",
                messageType = MessageType.success
            }));
        }
    }
    public class Logistics
    {
        /// <summary>
        /// 物流应用名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 物流应用状态
        /// </summary>
        public int State { get; set; }
    }
}