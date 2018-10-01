using System;
using System.Threading.Tasks;

namespace AttendeeApp.Core.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IAttendeeRepository Attendees { get; }

        int ExecStoreProcedure(string sql);
        int Commit();
        Task<int> CommitAsync();
    }
}