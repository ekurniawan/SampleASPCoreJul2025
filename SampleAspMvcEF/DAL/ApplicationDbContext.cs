using System;
using Microsoft.EntityFrameworkCore;
using SampleAspMvcEF.Models;

namespace SampleAspMvcEF.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; } = null!;


}
