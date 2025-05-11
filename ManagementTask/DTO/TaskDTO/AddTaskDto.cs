using ManagementTask.Entity;

namespace ManagementTask.DTO.TaskDTO
{
    public class AddTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }
        public string Category { get; set; }
    }
}
