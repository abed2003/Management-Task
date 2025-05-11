using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementTask.Entity
{
    [Table("Users")]
    public class Users 
    {
        [Key]
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<UserTask> Tasks { get; set; }  // علاقة المستخدم مع المهام
    }
}
