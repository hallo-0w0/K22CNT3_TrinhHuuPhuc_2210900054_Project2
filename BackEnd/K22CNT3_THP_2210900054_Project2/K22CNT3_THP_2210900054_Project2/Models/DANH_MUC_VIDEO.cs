//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace K22CNT3_THP_2210900054_Project2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DANH_MUC_VIDEO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DANH_MUC_VIDEO()
        {
            this.VIDEOs = new HashSet<VIDEO>();
        }
    
        public int ma_danh_muc { get; set; }
        public string ten_danh_muc { get; set; }
        public string mo_ta { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VIDEO> VIDEOs { get; set; }
    }
}
