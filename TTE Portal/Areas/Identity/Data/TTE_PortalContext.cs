using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TTE_Portal.Areas.Identity.Data;
using TTE_Portal.Models;

namespace TTE_Portal.Data;

public class TTE_PortalContext : IdentityDbContext<IdentityUser>
{
    public TTE_PortalContext(DbContextOptions<TTE_PortalContext> options)
        : base(options)
    {
    }

    public DbSet<AwbEntry> AwbEntries { get; set; }
    public DbSet<BusinessPartner> BusinessPartners { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<Log> Logs { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<PIEntry> PIEntries { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
  
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
        builder.Property(u => u.BpCode).HasMaxLength(50).IsRequired(true);
        builder.Property(u => u.RoleCode).HasMaxLength(50).IsRequired(true);
        builder.Property(u => u.IsActive).IsRequired(true);
        builder.Property(u => u.FullName).HasMaxLength(500);
    }
}