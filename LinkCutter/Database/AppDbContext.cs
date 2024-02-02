#nullable disable

using LinkCutter.Models;
using Microsoft.EntityFrameworkCore;

namespace LinkCutter.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Link> Links { get; set; }
}