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
    /// 配送单相关
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    //[StewardAuthorize]
    public class OrderController : Controller
    {
        private readonly ILogger _logger;
        private readonly IAuthorizeClient _client;
        public OrderController(ILogger<AuthorizationCodeController> logger, IAuthorizeClient client)
        {
            _logger = logger;
            _client = client;
        }
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <returns></returns>
        [HttpPost("OrderList")]
        [Authorize]
        public IActionResult OrderList()
        {
            return (IActionResult)Json(ResponseResult.Execute(new
            {
                code = 0,
                message="success",
                messageType=MessageType.success
            }));
        }
        /// <summary>
        /// 查询订单流程
        /// </summary>
        /// <returns></returns>
        [HttpPost("OrderProcess/{orderId}")]
        [Authorize]
        public IActionResult OrderProcess(string orderId)
        {
            return (IActionResult)Json(ResponseResult.Execute(new
            {
                code = 0,
                message = "success",
                messageType = MessageType.success
            }));
        }
        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpdateOrderState/{orderId,state}")]
        [Authorize]
        public IActionResult UpdateOrderState(string orderId, int state)
        {
            return (IActionResult)Json(ResponseResult.Execute(new
            {
                code = 0,
                message = "success",
                messageType = MessageType.success
            }));
        }
        /// <summary>
        /// 查询监控-配送单数量
        /// </summary>
        /// <param name="logisticsType">物流类型</param>
        /// <param name="goodsId">商品</param>
        /// <param name="state">配送单状态</param>
        /// <returns></returns>
        [HttpPost("GetOrderCount/{logisticsType,goodsId,state}")]
        [Authorize]
        public IActionResult GetOrderCount(int logisticsType,string goodsId,int state)
        {
            int orderCount = 0;
            return (IActionResult)Json(ResponseResult.Execute(new
            {
                data = orderCount,
                code = 0,
                message = "success",
                messageType = MessageType.success
            }));
        }
    }
}