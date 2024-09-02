using System.ComponentModel.DataAnnotations;

namespace ClassLibraryModel
{
    public class TaskModel
    {
        [Key]
        public int TaskManagmentID { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }

        public DateOnly DueDate { get; set; }

        public string TaskPriority { get; set; }
        public string SpecialNote { get; set; }
        public string TaskStatus { get; set; } = "Pending"; 
    }
}
