using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    /// <summary>
    /// 物流应用
    /// </summary>
    public class LogisticsMerchant
    {
        public int Id { get; set; }
        public string MerchantName { get; set; }
        public string MerchantDescription { get; set; }
        public int Status { get; set; }
        public DateTime LastTime { get; set; }
    }
}
