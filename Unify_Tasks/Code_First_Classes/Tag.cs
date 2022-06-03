using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unify_Tasks.Code_First_Classes
{
    internal class Tag
    {
        public int TagID { get; set; }
        public Nullable<int> TaskID { get; set; }
        public Nullable<int> ProjectID { get; set; }
        public string TagHeader { get; set; }
        public string TagColor { get; set; }

        public virtual Project Project { get; set; }
        public virtual Task Task { get; set; }
    }
}
