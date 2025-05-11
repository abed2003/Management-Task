namespace ManagementTask.DTO.TaskDTO
{
    public class GetTaskQ1Dto
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}
