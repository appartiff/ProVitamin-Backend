using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Provitamin.Application.Common.Interfaces;

namespace Provitamin.Persistence
{
    public partial class ProVitaminDbContext : DbContext, IProVitaminDbContext
    {
        public ProVitaminDbContext()
        {
        }

        public ProVitaminDbContext(DbContextOptions<ProVitaminDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
