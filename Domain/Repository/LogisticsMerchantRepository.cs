using ICH.King;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class LogisticsMerchantRepository : EfCoreRepository<LogisticsMerchant>, ILogisticsMerchantRepository
    {
        public LogisticsMerchantRepository(DbContext context) : base(context)
        {
        }
    }
    public interface ILogisticsMerchantRepository : IRepository<LogisticsMerchant>
    {
        //扩展额外的方法
    }
}
