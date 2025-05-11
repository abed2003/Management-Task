using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementTask.Entity
{
    [Table("Task")]
    public class UserTask
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }  
        public Users User { get; set; }  
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
