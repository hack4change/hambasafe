using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace Hambasafe.DataLayer.Entities
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
    }

    public class HambasafeDataContext : DbContext
    {
        public HambasafeDataContext()
        {
        }
        public HambasafeDataContext(DbContextOptions options) : base(options)
        {
        }

        // TODO : Should this not be cahnged to singular? This could maybe be the reason for pluralised table names...
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
