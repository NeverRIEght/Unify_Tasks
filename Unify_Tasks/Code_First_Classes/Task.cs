using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unify_Tasks.Code_First_Classes
{
    internal class Task
    {
        public int TaskID { get; set; }
        public int ProjectID { get; set; }
        public string Status { get; set; }
        public Nullable<int> Priority { get; set; }
        public string Header { get; set; }
        public Nullable<System.DateTime> Planned { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
