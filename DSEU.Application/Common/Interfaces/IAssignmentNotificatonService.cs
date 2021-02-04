using Task = System.Threading.Tasks.Task;

namespace DSEU.Application.Common.Interfaces
{
    public interface IAssignmentNotificatonService
    {
        Task UpdateUnreadCounters(int employeeId);
    }
}
