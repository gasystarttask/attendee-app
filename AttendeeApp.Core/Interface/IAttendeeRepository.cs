using AttendeeApp.Core.Model;

namespace AttendeeApp.Core.Interface
{
    public interface IAttendeeRepository : IRepository<Attendee>
    {
        Attendee GetByEmail(string email);
        int Count();
    }
}