using Booking.Server.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Server.DB
{
    public class DatabaseContext : DbContext
    {
        public DbSet<BookingInfo> BookingInfo { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
