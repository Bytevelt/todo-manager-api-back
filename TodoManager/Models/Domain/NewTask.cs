namespace TodoManager.Models.Domain
{
    public class NewTask
    {
        public Guid id { get; set; }
        public string description { get; set; }
        public int priority { get; set; }
        public DateTime dueDate { get; set; }
        public DateTime createdTime { get; set; }
        public int label { get; set; }
        public bool isVisible { get; set; }
    }
}
