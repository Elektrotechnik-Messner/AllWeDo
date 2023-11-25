using Microsoft.EntityFrameworkCore;
using Schulmuseum.Models;

namespace Schulmuseum.Data;

public class Database : DbContext
{
    public Database(DbContextOptions<Database> options) : base(options)
    {
        
    }
    public DbSet<UserModel> Users { get; set; }
    public DbSet<BlogPost> Posts { get; set; }
    public DbSet<SettingsModel> Settings { get; set; }
    public DbSet<SubjectModel> Subjects { get; set; }
}