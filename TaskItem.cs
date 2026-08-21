using Microsoft.OpenApi.MicrosoftExtensions;
using System.ComponentModel.DataAnnotations;

namespace MyFirstWebAPI
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = " name is required")]
        [StringLength(100, ErrorMessage="Name cannot exceed 100 characters")]
        public string Name { get; set; }
        public bool IsCompleted { get; set; }


    }
}
