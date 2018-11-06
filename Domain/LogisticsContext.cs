using Microsoft.EntityFrameworkCore;
using System;

namespace Domain
{
    public class LogisticsContext : DbContext
    {
        public LogisticsContext()
        {
        }

        public LogisticsContext(DbContextOptions<LogisticsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LogisticsChannel> LogisticsChannel { get; set; }
        public virtual DbSet<LogisticsMerchant> LogisticsMerchant { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
