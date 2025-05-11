using ManagementTask.DTO.UsersDTO;
using ManagementTask.Entity;
using ManagementTask.Interface;
using ManagementTask.Message;

namespace ManagementTask.Service
{
    public class UserService
    {
        private readonly IUsers _context;
        public UserService (IUsers context)
        {
            _context = context;
        }

        public GeneralErrorMessage AddUser(AddUserDto AddUser)
        {
            return _context.AddUser(AddUser);
        }
        public GeneralErrorMessage DeleteUser(string UserId)
        {
            return _context.DeleteUser(UserId);
        }
        public GeneralErrorMessage UpdateUser(UpdateUserDto NewUserData, string UserId)
        {
            return _context.UpdateUser(NewUserData, UserId);
        }
        public List<GetUsersQ1Dto> GetAllUser()
        {
            return _context.GetAllUser();
        }
        public List<GetUsersQ1Dto> GetUserById(string UserId)
        {
            return _context.GetUserById(UserId);
        }
    }
}
