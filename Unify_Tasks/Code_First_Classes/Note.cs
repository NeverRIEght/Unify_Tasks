using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unify_Tasks.Code_First_Classes
{
    internal class Note
    {
        public int NoteID { get; set; }
        public Nullable<int> TaskID { get; set; }
        public string Notepath { get; set; }

        public virtual Task Task { get; set; }
    }
}
