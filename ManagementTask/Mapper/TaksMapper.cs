using ManagementTask.DTO.TaskDTO;
using ManagementTask.Entity;

namespace ManagementTask.Mapper
{
    public static class TaksMapper
    {
        public static UserTask AddTask ( this AddTaskDto addTask)
        {
            return new UserTask
            {
               UserId = addTask.UserId,
               Category = addTask.Category,
               Description = addTask.Description,
               DueDate = addTask.DueDate,
               Priority = addTask.Priority,
               Status = addTask.Status,
               Title = addTask.Title,             
            };
        }
    }
}
