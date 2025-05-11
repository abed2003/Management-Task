using ManagementTask.DTO.TaskDTO;
using ManagementTask.DTO.UsersDTO;
using ManagementTask.Message;

namespace ManagementTask.Interface
{
    public interface ITask
    {
        public GeneralErrorMessage AddTask(AddTaskDto AddTask);
        public GeneralErrorMessage DeleteTaks(int TaskId);
        public GeneralErrorMessage UpdateTaks(UpdateTaskDto NewTaskData, int TaskId);
        public List<GetTaskQ1Dto> GetAllTasks();
        public List<GetTaskQ1Dto> GetTaskByUserId(string UserId);
        public List<GetTaskQ1Dto> GetTaskById(int TaskId);

    }
}
