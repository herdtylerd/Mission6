using Mission4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class AddTask
    {
        [Key]
        [Required]
        public int TaskId { get; set; }

        [Required]
        public string Task { get; set; }

        public string DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; }

        public bool Completed { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
