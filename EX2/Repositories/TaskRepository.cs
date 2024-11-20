using EX2.models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading.Tasks;

namespace EX2.Repositories
{
    public class TaskRepository: ITaskRepository
    {
        private readonly TaskDBContext _context;
        public TaskRepository(TaskDBContext context)
        {
            _context = context;
        }
        public IEnumerable<TaskModel> GetTasks()
        {
            return _context.Tasks.ToList();
        }
        public void addTask(TaskModel newTask)
        {
            _context.Tasks.Add(newTask);
            _context.SaveChanges();
        }

        public void DeleteTaskById(string id)
        {
            TaskModel? thisTask = _context.Tasks.Find(id);
            _context.Tasks.Remove(thisTask);
            _context.SaveChanges();

        }
        //public void SaveChanges(List<TaskModel> newListTasks)//כתיבת הרשימה כולל המשימה החדשה לקובץ
        //{
        //    if (!File.Exists(_filePath))
        //    {
        //        return;
        //    }
        //    var newList = JsonSerializer.Serialize(newListTasks);//ממיר  מגיסון למחרוזת
        //    File.WriteAllText(_filePath, newList);//מחזיר  משימות כמחרוזת
        //}
        public void updateTask(TaskModel newTask)
        {
            TaskModel? thisTask = _context.Tasks.Find(newTask.Id);
            _context.Tasks.Remove(thisTask);
            _context.Tasks.Add(newTask);
            _context.SaveChanges();
        }
    }
}
