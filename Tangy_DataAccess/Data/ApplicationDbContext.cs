using Microsoft.EntityFrameworkCore;

namespace Tangy_DataAccess.Data;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
}