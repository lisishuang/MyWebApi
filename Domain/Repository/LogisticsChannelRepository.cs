using ICH.King;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class LogisticsChannelRepository : EfCoreRepository<LogisticsChannel>, ILogisticsChannelRepository
    {
        public LogisticsChannelRepository(DbContext context) : base(context)
        {
        }
    }
    public interface ILogisticsChannelRepository : IRepository<LogisticsChannel>
    {
        //扩展额外的方法
    }
}
