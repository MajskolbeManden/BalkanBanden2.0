namespace RESTChatAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SignalRAdmin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SignalRAdmin()
        {
            SignalRGroups = new HashSet<SignalRGroup>();
        }

        [Key]
        public int AdminID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserAdmin { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminPassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SignalRGroup> SignalRGroups { get; set; }
    }
}
