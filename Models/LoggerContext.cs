using Microsoft.EntityFrameworkCore;

namespace Logger.Models {

    public class LoggerContext : DbContext {

        public virtual DbSet<Log> Logs { get; set; }

        public LoggerContext(DbContextOptions<LoggerContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder) {

        }

    }
}