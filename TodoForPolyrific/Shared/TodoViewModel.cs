using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoForPolyrific.Shared
{
    public class TodoViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Detail { get; set; }
        public TodoStatusEnum Status { get; set; }
        public DateTime LastModified { get; set; }
    }
}
