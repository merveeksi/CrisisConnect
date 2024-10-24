using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }

    public DbSet<Alert> Alerts { get; set; }
    public DbSet<Center> Centers { get; set; }
    public DbSet<Disaster> Disasters { get; set; }
    public DbSet<Donor> Donors { get; set; }
    public DbSet<Logistic> Logistics { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Shelter> Shelters { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Volunteer> Volunteers { get; set; }
    
    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
        Database.EnsureCreated();  //veritabanının oluştuğundan emin ol
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //bu assembly'deki tüm entity'lerin konfigürasyonlarını uygula
    }
}