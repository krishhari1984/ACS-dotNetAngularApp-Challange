using ACS_dotNetAngularApp.Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ACS_dotNetAngularApp.Business
{
    public class UsersContext : DbContext
    {
        private IConfiguration _config;
        public DbSet<ContactUser> ContactUserDbSet { get; set; }
        public UsersContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config.GetSection("ConnectionsString").GetConnectionString("SQLConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactUser>(entity =>
            {
                entity.Property(e => e.ContactID).HasColumnName("ContactID");

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LName)
                 .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DOB)
                 .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);
                entity.Property(e => e.Email)
                 .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);
                entity.Property(e => e.Phone)
                 .IsRequired()
                   .HasMaxLength(10)
                   .IsUnicode(false);
            });
            modelBuilder.Entity<ContactUser>().ToTable("Users");


        }
    }

        
}
