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

namespace WebApi.Controllers
{
    /// <summary>
    /// 物流通用接口
    /// </summary>
    public class LogisticsController : Controller
    {

        private readonly ILogisticsMerchantRepository _logisticsMerchantRepository;
        private readonly IUnitOfWork _unitOfWork;
        public LogisticsController(ILogisticsMerchantRepository logisticsMerchantRepository, IUnitOfWork unitOfWork)
        {
            _logisticsMerchantRepository = logisticsMerchantRepository;
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// 物流应用
        /// 下拉框专用
        /// </summary>
        /// <returns></returns>
        [HttpGet("MerchantList")]
        [AllowAnonymous]
        public async Task<IActionResult> MerchantList()
        {
            List<LogisticsCmb> list = new List<LogisticsCmb>();
            var data = _logisticsMerchantRepository.TableNoTracking.ToList();
            foreach (var item in data)
            {
                list.Add(new LogisticsCmb() { Id = item.Id, Name = item.MerchantName });
            }
            return Ok(list);
        }


    }
    public class LogisticsCmb
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}