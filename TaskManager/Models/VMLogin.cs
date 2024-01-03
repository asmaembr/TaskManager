using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
	public class VMLogin
	{
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Email { get; set; }
		public string? Password { get; set; }
		public bool keepLoggedIn { get; set; }
	}
}
