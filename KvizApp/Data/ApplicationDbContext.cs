using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KvizApp.Models;

namespace KvizApp.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{

public DbSet<KvizApp.Models.Option> Option { get; set; } = default!;
public DbSet<Question> Questions { get; set; }

}