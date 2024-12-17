using Microsoft.EntityFrameworkCore;

namespace Db;
public class Context : DbContext
{
    public DbSet<Entities.HackathonTable> HackathonTables { get; set; }
    public DbSet<Entities.DeveloperTable> DeveloperTables { get; set; }
    public DbSet<Entities.WishlistTable> WishlistTables { get; set; }
    public DbSet<Entities.TeamTable> TeamTables { get; set; }
    public Context(DbContextOptions<Context> options) : base(options) { }
}
