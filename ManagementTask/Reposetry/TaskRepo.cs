using ManagementTask.DBCon;
using ManagementTask.DTO.TaskDTO;
using ManagementTask.DTO.UsersDTO;
using ManagementTask.Interface;
using ManagementTask.Mapper;
using ManagementTask.Message;
using Microsoft.EntityFrameworkCore;

namespace ManagementTask.Reposetry
{
    public class TaskRepo : ITask
    {
        private readonly DBC _context;
        public TaskRepo(DBC context)
        {
            _context = context;
        }
        public GeneralErrorMessage AddTask(AddTaskDto AddTask)
        {
            if (AddTask == null)
            {
                GeneralErrorMessage Msg = new GeneralErrorMessage(
                    ErrorMsg.ENTER_DATA_NOT_FOUND,
                    "NOT FOUND ANY DATA "
                    );
                return Msg;
            }
            else
            {
                var getUser = _context.User.Any(p => p.Id == AddTask.UserId);
                if (getUser == false)
                {
                    GeneralErrorMessage Msg = new GeneralErrorMessage(
                    ErrorMsg.NOT_FOUNT_ANY_USER_HAVE_SAME_ID,
                    "Enter currect user id , the account is not avalabel "
                    );
                    return Msg;
                }
                else
                {
                    try
                    {
                        _context.Task.Add(AddTask.AddTask());
                        _context.SaveChanges();
                        GeneralErrorMessage Msg = new GeneralErrorMessage(
                        SuccessfulMsg.Successful_ADD_NEW_TASK,
                        "Successfully add new Task "
                        );
                        return Msg;
                    }
                    catch (Exception ex)
                    {
                        GeneralErrorMessage Msg = new GeneralErrorMessage(
                        ErrorMsg.ERROR,
                        "Enter the new Account "
                        );
                        return Msg;
                    }
                }
            }
        }
        public GeneralErrorMessage DeleteTaks(int TaskId)
        {
            var getTask = _context.Task.FirstOrDefault(p => p.Id == TaskId );
            if (getTask != null)
            {
                try
                {
                    _context.Task.Remove(getTask);
                    _context.SaveChanges();
                    GeneralErrorMessage Msg1 = new GeneralErrorMessage(
                    SuccessfulMsg.Successful_DELETE_TASK,
                    "Successfully Delete Taks"
                    );
                    return Msg1;
                }
                catch (Exception ex)
                {
                    GeneralErrorMessage Msg1 = new GeneralErrorMessage(
                      ErrorMsg.ERROR,
                      "Error "
                      );
                    return Msg1;
                }
            }
            GeneralErrorMessage Msg = new GeneralErrorMessage(
                      ErrorMsg.NOT_FOUNT_ANY_TASK_HAVE_SAME_ID,
                      "Feild to delete Task "
                      );
            return Msg;
        }
        public GeneralErrorMessage UpdateTaks(UpdateTaskDto NewTaskData, int TaskId)
        {
            var GetOldDate = _context.Task.FirstOrDefault(p => p.Id == TaskId);
            if (GetOldDate != null)
            {
                try
                {
                    GetOldDate.DueDate = NewTaskData.DueDate;
                    GetOldDate.Status = NewTaskData.Status;
                    GetOldDate.Priority = NewTaskData.Priority;
                    GetOldDate.Category = NewTaskData.Category;
                    GetOldDate.Description = NewTaskData.Description;   
                    GetOldDate.Title = NewTaskData.Title;   

                    _context.SaveChanges();
                    GeneralErrorMessage Msg1 = new GeneralErrorMessage(
                    SuccessfulMsg.Successful_UPDATE_ACCOUNT,
                    "Successfully add user"
                    );
                    return Msg1;
                }
                catch (Exception ex)
                {
                    GeneralErrorMessage Msg1 = new GeneralErrorMessage(
                      ErrorMsg.ERROR,
                      "Enter the new Account "
                      );
                    return Msg1;
                }
            }
            GeneralErrorMessage Msg = new GeneralErrorMessage(
                      ErrorMsg.NOT_FOUNT_ANY_TASK_HAVE_SAME_ID,
                      "Enter the new Account "
                      );
            return Msg;
        }
        public List<GetTaskQ1Dto> GetAllTasks()
        {
            string sql = @"
                        select 
                        u.Id as UserId ,
                        u.Username  ,
                        t.Id as TaskId ,
                        t.Title,
                        t.Description,
                        t.Priority,
                        t.DueDate,
                        t.Status,
                        t.Category,
                        t.CreatedAt
                        from Task t 
                        join Users u on u.Id = t.UserId 
                        ";
            var result = _context.Database.SqlQueryRaw<GetTaskQ1Dto>(sql).ToList();
            return result;
        }
        public List<GetTaskQ1Dto> GetTaskByUserId (string UserId)
        {
            string sql = @"
                        select 
                        u.Id as UserId ,
                        u.Username  ,
                        t.Id as TaskId ,
                        t.Title,
                        t.Description,
                        t.Priority,
                        t.DueDate,
                        t.Status,
                        t.Category,
                        t.CreatedAt
                        from Task t 
                        join Users u on u.Id = t.UserId 
                        where u.id = @p0
                        ";
            var result = _context.Database.SqlQueryRaw<GetTaskQ1Dto>(sql, UserId).ToList();
            return result;
        }
        public List<GetTaskQ1Dto> GetTaskById(int TaskId )
        {
            string sql = @"
                      select 
                        u.Id as UserId ,
                        u.Username  ,
                        t.Id as TaskId ,
                        t.Title,
                        t.Description,
                        t.Priority,
                        t.DueDate,
                        t.Status,
                        t.Category,
                        t.CreatedAt
                        from Task t 
                        join Users u on u.Id = t.UserId 
                        where t.id = @p0
                        ";
            var result = _context.Database.SqlQueryRaw<GetTaskQ1Dto>(sql, TaskId).ToList();
            return result;
        }
    }
}
