using System.Data.Entity;
using System.Linq;
using AttendeeApp.Core.Interface;

namespace AttendeeApp.Infrastructure.Repository
{
    public class AttendeeRepository : Repository<AttendeeApp.Core.Model.Attendee>, IAttendeeRepository
    {
        public AttendeeRepository(DbContext db) : base(db)
        {
        }

        public AttendeeApp.Core.Model.Attendee GetByEmail(string email)
        {
            return Find(x => x.Email == email).SingleOrDefault();
        }

        public int Count()
        {
            return GetAll().Count();
        }
    }
}