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
    
    public partial class Tag
    {
        public int TagID { get; set; }
        public Nullable<int> TaskID { get; set; }
        public string TagHeader { get; set; }
        public string TagColor { get; set; }
    
        public virtual Task Task { get; set; }
    }
}
