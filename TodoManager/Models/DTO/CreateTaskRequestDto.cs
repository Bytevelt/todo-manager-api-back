namespace TodoManager.Models.DTO
{
    public class CreateTaskRequestDto
    {
        public string description { get; set; }
        public int priority { get; set; }
        public DateTime dueDate { get; set; }
        public DateTime createdTime { get; set; }
        public string label { get; set; }
        public bool isVisible { get; set; }
    }
}
