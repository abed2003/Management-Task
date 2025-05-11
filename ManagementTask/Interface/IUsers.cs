using ManagementTask.DTO.UsersDTO;
using ManagementTask.Message;

namespace ManagementTask.Interface
{
    public interface IUsers
    {
        public GeneralErrorMessage AddUser(AddUserDto AddUser);
        public GeneralErrorMessage DeleteUser(string UserId);
        public GeneralErrorMessage UpdateUser(UpdateUserDto NewUserData, string UserId);
        public List<GetUsersQ1Dto> GetAllUser();
        public List<GetUsersQ1Dto> GetUserById(string UserId);

    }
}
