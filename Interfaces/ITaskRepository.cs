using ProjectFT.Models;
using System.Threading.Tasks;

namespace ProjectFT.Interfaces
{
    public interface ITaskRepository
    {
        //Get All Tasks

        Task<IEnumerable<TaskItem>> GetAllTasks();

        Task<TaskItem> GetTaskById(int Id);

        Task <bool>AddTask(TaskItem item);

        Task <bool>UpdateTask(int Id,TaskItem item);

        Task <bool>DeleteTask(int id);


    }
}
