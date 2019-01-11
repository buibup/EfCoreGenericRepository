using EfCoreGenericRepository.DAL.Models;
using EfCoreGenericRepository.DAL.Models.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EfCoreGenericRepository.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogDetail> BlogDetails { get; set; }
        public DbSet<Post> Posts { get; set; }

        public virtual void Save()
        {
            base.SaveChanges();
        }
        public string UserProvider
        {
            get
            {
                if (!string.IsNullOrEmpty(WindowsIdentity.GetCurrent().Name))
                    return WindowsIdentity.GetCurrent().Name.Split('\\')[1];
                return string.Empty;
            }
        }

        public Func<DateTime> TimestampProvider { get; set; } = ()
            => DateTime.UtcNow;
        public override int SaveChanges()
        {
            TrackChanges();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            TrackChanges();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void TrackChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (entry.Entity is IAuditable)
                {
                    var auditable = entry.Entity as IAuditable;
                    if (entry.State == EntityState.Added)
                    {
                        auditable.CreatedBy = UserProvider;//
                        auditable.CreatedOn = TimestampProvider();
                        auditable.UpdatedOn = TimestampProvider();
                    }
                    else
                    {
                        auditable.UpdatedBy = UserProvider;
                        auditable.UpdatedOn = TimestampProvider();
                    }
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Post>()
                .HasOne(b => b.Blog)
                .WithMany(p => p.Posts)
                .IsRequired();
        }
    }
}
