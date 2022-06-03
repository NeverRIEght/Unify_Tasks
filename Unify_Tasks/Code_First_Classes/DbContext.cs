using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unify_Tasks.Code_First_Classes
{
    internal class Context1 : DbContext
    {
        public Context1() : base("Unify_Tasks")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
