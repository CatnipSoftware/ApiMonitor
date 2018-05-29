using Microsoft.EntityFrameworkCore;

namespace Monitor.Domain.Model
{
    public class MonitorContext : DbContext
    {
        public MonitorContext() { }
        public MonitorContext(DbContextOptions<MonitorContext> options) : base(options) { }

        public virtual DbSet<Api> Apis { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Server> Servers { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasOne(d => d.Api)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.ApiId);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.ApplicationId);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Server)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.ServerId);

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.TransactionId);
            });
        }
    }
}