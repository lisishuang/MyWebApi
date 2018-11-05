using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using ICH.King;
using ICH.Util.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    /// <summary>
    /// 充值类
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RechargeController : Controller
    {
        private readonly ILogisticsChannelRepository _logisticsChannelRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RechargeController(ILogisticsChannelRepository repositoryLogisticsChannel, IUnitOfWork unitOfWork)
        {
            _logisticsChannelRepository = repositoryLogisticsChannel;
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// 充值类配置
        /// </summary>
        /// <returns></returns>
        [HttpPost("Add")]
        [AllowAnonymous]
        public async Task<IActionResult> Add([FromBody]LogisticsChannel data)
        {
            data.CreateTime = DateTime.Now;
            _logisticsChannelRepository.Insert(data);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
        /// <summary>
        /// 充值类查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("RechargeList")]
        [AllowAnonymous]
        public async Task<IActionResult> RechargeList()
        {
            //List<LogisticsChannel> list = new List<LogisticsChannel>();
            var data = await _logisticsChannelRepository.TableNoTracking.ToPagedListAsync(0,5);
            return Ok(data);
        }
    }
    /// <summary>
    /// 充值类
    /// </summary>
    public class Recharge
    {
        /// <summary>
        /// 充值类名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 充值类
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 所属应用
        /// </summary>
        public string Application { get; set; }
    }
}