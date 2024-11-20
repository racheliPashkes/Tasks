using EX2.models;
using System.Threading.Tasks;

namespace EX2.services
{
    public interface ITaskService
    {
        IEnumerable<TaskModel> GetTasks();
        void addTask(string Id, string Name,  string Status,string DueDate);
        void DeleteTaskById(string id);
        void updateTask(TaskModel newTask);
    }
}
