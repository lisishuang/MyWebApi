using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    /// <summary>
    /// 渠道充值类
    /// </summary>
    public class LogisticsChannel
    {
        public int Id { get; set; }
        public int LogisticsMerchantId { get; set; }
        public string ChargeClass { get; set; }
        public string ChannelDescription { get; set; }
        public DateTime CreateTime { get; set; }
        public int Status { get; set; }
    }
}
