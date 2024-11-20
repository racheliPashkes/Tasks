using EX2.Repositories;
using EX2.models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EX2.services
{
    public class TaskService: ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public IEnumerable<TaskModel> GetTasks()
        {
            return _taskRepository.GetTasks();
        }
        public void addTask(string Id, string Name, string Status,string DueDate)
        {
            TaskModel newTask = new TaskModel();
            newTask.Id = Id;
            newTask.Name = Name;
            newTask.Status = Status;
            newTask.DueDate = DueDate;
            _taskRepository.addTask(newTask);
        }
        public void DeleteTaskById(string id)
        {
            _taskRepository.DeleteTaskById(id);
        }
        public void updateTask(TaskModel newTask)
        {
            _taskRepository.updateTask(newTask);
        }
    }
}