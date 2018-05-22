using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using DataLayer.interfaces;
using DataLayer.repositories;

namespace BusinessLayer
{
   public class TaskManager : Manager
    {
        public Task currentTask;


        public Status RemoveTask(int TaskId)
        {
            try
            {
                ITaskRepository taskRepository = new TaskRepository();
                taskRepository.RemoveTask(TaskId);
                taskRepository.Save();

                return Status.Success;
            }
            catch (Exception)
            {

                return Status.Fail;
            }
        }

        public Status UpdateStatus(int TaskId,int TaskStatus)
        {

            try
            {
                
                ITaskRepository taskRepository = new TaskRepository();
                Task task = taskRepository.GetTask(TaskId);
                task.Status = TaskStatus;
                taskRepository.UpdateTask(task);
                taskRepository.Save();
                return Status.Success;

            }
            catch (Exception)
            {

                return Status.Fail;
            }

        }

        public Status AddTask(Task task)
        {
            try
            {
                ITaskRepository taskRepository = new TaskRepository();

                currentTask = taskRepository.InsertTask(task);



                taskRepository.Save();

                SetCurrentTask(taskRepository.GetTask(currentTask.TaskId));

                return Status.Success;
            }
            catch (Exception e)
            {

                return Status.Fail;
            }
        }

        private void SetCurrentTask(Task currentTask)
        {
            this.currentTask = new Task
            {
                TaskId = currentTask.TaskId,
                Name = currentTask.Name,
                Description = currentTask.Description,
                Deadline = currentTask.Deadline,
                Status = currentTask.Status,
                User = new User { UserId = currentTask.UserId,Username = currentTask.User.Username },
                Story = new Story { Name=currentTask.Story.Name}
            };
        }

        public IEnumerable GetTasks()
        {
            ITaskRepository taskRepository = new TaskRepository();

            return taskRepository.GetTasks();
        }
    }
}
