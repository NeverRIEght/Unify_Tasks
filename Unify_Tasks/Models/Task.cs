//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Unify_Tasks.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Task()
        {
            this.CrossElements = new HashSet<CrossElement>();
        }
    
        public int TaskID { get; set; }
        public int ProjectID { get; set; }
        public Nullable<int> Status { get; set; }
        public string Header { get; set; }
        public int NoteID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CrossElement> CrossElements { get; set; }
        public virtual Note Note { get; set; }
        public virtual Project Project { get; set; }
    }
}
