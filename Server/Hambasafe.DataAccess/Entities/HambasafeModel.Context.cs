using Microsoft.Data.Entity;
using System.Configuration;

namespace Hambasafe.DataAccess.Entities
{

    public class HambasafeDataContext : DbContext
    {
        public HambasafeDataContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (bool.Parse(ConfigurationManager.AppSettings["UseSql"]))
            {
                var connectionString = ConfigurationManager.ConnectionStrings["HambasafeDataContext"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
            else
            {
                optionsBuilder.UseInMemoryDatabase();
            }
        }


        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<AttendanceRating> AttendanceRatings { get; set; }
        public virtual DbSet<BlockedUser> BlockedUsers { get; set; }
        public virtual DbSet<Connection> Connections { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventLocation> EventLocations { get; set; }
        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<ImageResource> ImageResources { get; set; }
        public virtual DbSet<Invitation> Invitations { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
