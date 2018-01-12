namespace RESTChatAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ChatContext : DbContext
    {
        public ChatContext()
            : base("name=ChatContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<SignalRAdmin> SignalRAdmins { get; set; }
        public virtual DbSet<SignalRGroup> SignalRGroups { get; set; }
        public virtual DbSet<SignalRMessage> SignalRMessages { get; set; }
        public virtual DbSet<SignalRUser> SignalRUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SignalRAdmin>()
                .Property(e => e.UserAdmin)
                .IsUnicode(false);

            modelBuilder.Entity<SignalRAdmin>()
                .Property(e => e.AdminPassword)
                .IsUnicode(false);

            modelBuilder.Entity<SignalRAdmin>()
                .HasMany(e => e.SignalRGroups)
                .WithRequired(e => e.SignalRAdmin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SignalRGroup>()
                .HasMany(e => e.SignalRMessages)
                .WithRequired(e => e.SignalRGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SignalRMessage>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<SignalRUser>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<SignalRUser>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<SignalRUser>()
                .HasMany(e => e.SignalRGroups)
                .WithRequired(e => e.SignalRUser)
                .WillCascadeOnDelete(false);
        }
    }
}
