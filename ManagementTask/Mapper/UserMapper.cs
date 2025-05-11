using ManagementTask.DTO.UsersDTO;
using ManagementTask.Entity;

namespace ManagementTask.Mapper
{
    public static class UserMapper
    {
        public static Users AddUsersMapper(this AddUserDto users)
        {
            return new Users
            {
                Id = users.Id,
                Email = users.Email,
                PasswordHash = users.PasswordHash,
                Role = users.Role,
                Username= users.Username ,
                DateCreated = users.DateCreated,
            };
        }
    }
}
