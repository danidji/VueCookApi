using Microsoft.EntityFrameworkCore;
using VueCookApi.Models;

namespace VueCookApi.Data;

public class VueCookContext : DbContext
{
  public VueCookContext(DbContextOptions<VueCookContext> options) : base(options)
  {
  }

  public DbSet<Recipe> Recipes { get; set; } = null!;
}
