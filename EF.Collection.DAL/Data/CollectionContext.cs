using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using EFCollection.DAL.Entities;
using EFCollections.DAL.Configurations;

namespace EFCollections.DAL.Data
{ 
    public class CollectionContext : DbContext 
    {
        public DbSet<Collection> Collection { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CollectionConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Initial Catalog=FaxGuild2;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=True;");
            }
        }

        public CollectionContext(DbContextOptions<CollectionContext> options)
            : base(options)
        {
        }
    }
}
