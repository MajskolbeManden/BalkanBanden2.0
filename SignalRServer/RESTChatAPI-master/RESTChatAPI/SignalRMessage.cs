namespace RESTChatAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SignalRMessage
    {
        [Key]
        public int MessageID { get; set; }

        [Required]
        [StringLength(50)]
        public string Message { get; set; }

        public DateTime? Time { get; set; }

        public int GroupID { get; set; }

        public virtual SignalRGroup SignalRGroup { get; set; }
    }
}
