using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.interfaces
{
   public interface ITaskRepository
    {
        Task InsertTask(Task task);
        Task GetTask(int TaskId);
        IEnumerable GetTasks();

        Task UpdateTask(Task task);

        bool RemoveTask(int TaskId);

        void Save();
    }
}
