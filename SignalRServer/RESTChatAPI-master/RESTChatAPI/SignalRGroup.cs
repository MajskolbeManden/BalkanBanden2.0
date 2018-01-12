namespace RESTChatAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SignalRGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SignalRGroup()
        {
            SignalRMessages = new HashSet<SignalRMessage>();
        }

        [Key]
        public int GroupID { get; set; }

        public int UserID { get; set; }

        public int AdminID { get; set; }

        public virtual SignalRAdmin SignalRAdmin { get; set; }

        public virtual SignalRUser SignalRUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SignalRMessage> SignalRMessages { get; set; }
    }
}
