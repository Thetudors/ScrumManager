using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.interfaces;
using System.Data.Entity;

namespace DataLayer.repositories
{
    public class TaskRepository : ITaskRepository
    {

        private ScrumManagerEntities context;
        public TaskRepository()
        {
            context = new ScrumManagerEntities();
        }

        public Task GetTask(int TaskId)
        {
            return context.Tasks
                .Include(t => t.User)
                .Include(t => t.Story)
                .Where(t => t.TaskId == TaskId).FirstOrDefault();
        }

        public IEnumerable GetTasks()
        {
            return context.Tasks
                .ToList().
                Select(t => new { t.TaskId, t.Name, t.Description, t.Deadline, t.Status,storyname=t.Story.Name , username = t.User.Username});
        }

        public Task InsertTask(Task task)
        {
            return context.Tasks.Add(task);
        }

        public bool RemoveTask(int TaskId)
        {
            try
            {
                context.Tasks.Remove(GetTask(TaskId));
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public Task UpdateTask(Task task)
        {
            context.Entry(task).State = EntityState.Modified;
            return task;
        }
    }
}
