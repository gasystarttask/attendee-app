using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AttendeeApp.Infrastructure.Context
{
    public class AttendeeAppContext : DbContext
    {
        public DbSet<AttendeeApp.Core.Model.Attendee> Attendees { get; set; }

        public AttendeeAppContext() : base("name = AttendeeAppContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<AttendeeAppContext>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}