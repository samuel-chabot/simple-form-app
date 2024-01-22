using Microsoft.EntityFrameworkCore;

namespace SimpleFormApp.Database;

public class ApplicationContext : DbContext
{
    public DbSet<RequestFormRecord> RequestForms { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> opts)
        : base(opts)
    { }

    protected ApplicationContext(DbContextOptions opts)
        : base(opts)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RequestFormRecord>()
            .OwnsOne(c => c.Tag, d =>
            {
                d.ToJson();
            });

        base.OnModelCreating(modelBuilder);
    }
}
