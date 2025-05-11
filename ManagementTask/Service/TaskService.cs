using ManagementTask.DBCon;
using ManagementTask.DTO.TaskDTO;
using ManagementTask.DTO.UsersDTO;
using ManagementTask.Interface;
using ManagementTask.Message;

namespace ManagementTask.Service
{
    public class TaskService
    {
        private readonly ITask _context;
        public TaskService(ITask context)
        {
            _context = context;
        }
        public GeneralErrorMessage AddTask(AddTaskDto AddTask)
        {
            return _context.AddTask(AddTask);
        }
        public GeneralErrorMessage DeleteTaks(int TaskId)
        {
            return _context.DeleteTaks(TaskId);
        }
        public GeneralErrorMessage UpdateTaks(UpdateTaskDto NewTaskData, int TaskId)
        {
            return _context.UpdateTaks(NewTaskData, TaskId);
        }
        public List<GetTaskQ1Dto> GetAllTasks()
        {
            return _context.GetAllTasks();
        }
        public List<GetTaskQ1Dto> GetTaskByUserId(string UserId)
        {
            return _context.GetTaskByUserId(UserId);
        }
        public List<GetTaskQ1Dto> GetTaskById(int TaskId)
        {
            return _context.GetTaskById(TaskId);
        }
    }
}
