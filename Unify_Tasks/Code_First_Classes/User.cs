using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unify_Tasks.Code_First_Classes
{
    internal class User
    {
        public int UserID { get; set; }
        public string login { get; set; }
        public string password { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
