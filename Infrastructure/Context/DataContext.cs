using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Artist> Artists {get;set;}
    public DbSet<Track> Tracks {get;set;}
    public DbSet<Album> Albums {get;set;}
}