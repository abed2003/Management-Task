using ManagementTask.DBCon;
using ManagementTask.DTO.UsersDTO;
using ManagementTask.Interface;
using ManagementTask.Mapper;
using ManagementTask.Message;
using Microsoft.EntityFrameworkCore;

namespace ManagementTask.Reposetry
{
    public class UsersRepo : IUsers
    {
        private readonly DBC _context;
        public UsersRepo(DBC context)
        {
            _context = context;
        }
        public GeneralErrorMessage AddUser(AddUserDto AddUser)
        {
            if (AddUser == null)
            {
                GeneralErrorMessage Msg = new GeneralErrorMessage(
                    ErrorMsg.ENTER_DATA_NOT_FOUND,
                    "NOT FOUND ANY DATA "
                    );
                return Msg;
            }
            else
            {
                var getUser = _context.User.Any(p => p.Id == AddUser.Id);
                if (getUser)
                {
                    GeneralErrorMessage Msg = new GeneralErrorMessage(
                    ErrorMsg.DUBLECATE_ACCOUNT,
                    "Enter the new Account "
                    );
                    return Msg;
                }
                else
                {
                    try
                    {
                        _context.User.Add(AddUser.AddUsersMapper());
                        _context.SaveChanges();
                        GeneralErrorMessage Msg = new GeneralErrorMessage(
                        SuccessfulMsg.Successful_ADD_NEW_ACCOUNT,
                        "Successfully add new account "
                        );
                        return Msg;
                    }
                    catch (Exception ex) {
                        GeneralErrorMessage Msg = new GeneralErrorMessage(
                        ErrorMsg.ERROR,
                        "Enter the new Account "
                        );
                        return Msg;
                    }
                }
            }
        }
        public GeneralErrorMessage DeleteUser(string UserId )
        {
            var getUser = _context.User.FirstOrDefault(p => p.Id == UserId);
            if (getUser != null)
            {
                try
                {
                _context.User.Remove(getUser);
                _context.SaveChanges();
                GeneralErrorMessage Msg1 = new GeneralErrorMessage(
                SuccessfulMsg.Successful_DELETE_ACCOUNT,
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
                      ErrorMsg.NOT_FOUNT_ANY_USER_HAVE_SAME_ID,
                      "Enter the new Account "
                      );
            return Msg;
        }
        public GeneralErrorMessage UpdateUser(UpdateUserDto NewUserData , string UserId )
        {
            var GetOldDate = _context.User.FirstOrDefault(p => p.Id == UserId);
            if (GetOldDate != null)
            {
                try
                {
                    GetOldDate.Username = NewUserData.Username;
                    GetOldDate.PasswordHash = NewUserData.PasswordHash;
                    GetOldDate.Email = NewUserData.Email;
                    GetOldDate.Role = NewUserData.Role; 
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
                      ErrorMsg.NOT_FOUNT_ANY_USER_HAVE_SAME_ID,
                      "Enter the new Account "
                      );
            return Msg;
        }
        public List<GetUsersQ1Dto> GetAllUser()
        {
            string sql = @"
                        select * from Users
                        ";
            var result = _context.Database.SqlQueryRaw<GetUsersQ1Dto>(sql).ToList();
            return result;
        }
        public List<GetUsersQ1Dto> GetUserById(string UserId )
        {
            string sql = @"
                        select * from Users
                        where id = @p0
                        ";
            var result = _context.Database.SqlQueryRaw<GetUsersQ1Dto>(sql , UserId).ToList();
            return result;
        }
    }
}
