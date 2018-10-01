using System.Linq;
using System.Threading.Tasks;
using AttendeeApp.Core.Interface;
using AttendeeApp.Infrastructure.Context;

namespace AttendeeApp.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AttendeeAppContext _context;

        public UnitOfWork()
        {
            _context = new AttendeeAppContext();
            Attendees = new AttendeeRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAttendeeRepository Attendees { get; }
        public int ExecStoreProcedure(string sql)
        {
            return _context.Database.SqlQuery<int>($"EXEC {sql}").FirstOrDefault();
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}