using Mel_TPI.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mel_TPI.Models;

namespace Mel_TPI.Data;

public class Mel_TPIContext : IdentityDbContext<Mel_TPIUser>
{
    public Mel_TPIContext(DbContextOptions<Mel_TPIContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<Mel_TPI.Models.Contact>? Contact { get; set; }

    public DbSet<Mel_TPI.Models.Lesson>? Lesson { get; set; }

    public DbSet<Mel_TPI.Models.Student>? Student { get; set; }

    public DbSet<Mel_TPI.Models.Teacher>? Teacher { get; set; }
}
