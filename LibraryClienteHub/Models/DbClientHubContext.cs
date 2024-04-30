using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryClienteHub.Models
{
    public partial class DbClientHubContext : DbContext
    {
        public DbClientHubContext()
        {
        }

        public DbClientHubContext(DbContextOptions<DbClientHubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clients> Clients { get; set; } = null!;

        public virtual DbSet<AddressClient> AddressClient { get; set; } = null!;
        public virtual DbSet<AuthToken> Auth { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=DbClientHub;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
