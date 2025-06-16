using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Arrecadar3.Models;

namespace Arrecadar3.Data;

public class Arrecadar3Context : IdentityDbContext<IdentityUser>
{
    public Arrecadar3Context(DbContextOptions<Arrecadar3Context> options)
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

    public DbSet<Arrecadar3.Models.Ong>? Ong { get; set; }

    public DbSet<Arrecadar3.Models.Campanha>? Campanha { get; set; }

    public DbSet<Arrecadar3.Models.Atualizacao_Campanha>? Atualizacao_Campanha { get; set; }
}
