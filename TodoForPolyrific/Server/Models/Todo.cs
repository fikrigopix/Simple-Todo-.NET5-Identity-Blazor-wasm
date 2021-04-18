using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TodoForPolyrific.Shared;

namespace TodoForPolyrific.Server.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Detail { get; set; }

        public TodoStatusEnum Status { get; set; }

        public DateTime LastModified { get; set; }

        [ForeignKey("ApplicationUser")]
        [Required]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
