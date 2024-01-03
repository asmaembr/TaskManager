using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{

        public class MyTask
        {

        [Key]
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }

        public MyTask()
        {
        }

        public MyTask(string? title, string? description , DateTime dueDate)
        {
            title = Title;
            description = Description;
            dueDate = DueDate;
        }
    
    }
    

}
