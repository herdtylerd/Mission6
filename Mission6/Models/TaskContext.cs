using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class TaskContext : DbContext
    {
        //Constructor
        public TaskContext (DbContextOptions<TaskContext> options) : base (options)
        {
            // come back to later
        }

        public DbSet<AddTask> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {

        }

    }
}
