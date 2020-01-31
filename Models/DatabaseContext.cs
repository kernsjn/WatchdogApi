using System;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WatchdogApi.Models;

namespace WatchdogApi.Models
{
  public class DatabaseContext : DbContext
  {
    public DbSet<Facility> Facilities { get; set; }

    public DbSet<Building> Buildings { get; set; }

    public DbSet<Scope> Scopes { get; set; }

    public DbSet<AssignPerson> AssignPersons { get; set; }

    public DbSet<Requestor> Requestors { get; set; }

    public DbSet<PunchListItem> PunchListItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Scope>().HasData(
          new Scope { Id = 1, Description = "Site" },
          new Scope { Id = 2, Description = "Fixed System: Roof" },
          new Scope { Id = 3, Description = "Fixed System: Building Interior" },
          new Scope { Id = 4, Description = "Fixed System: Building Exterior" },
          new Scope { Id = 5, Description = "Operating System: HVAC" },
          new Scope { Id = 6, Description = "Operating System: Electrical" },
          new Scope { Id = 7, Description = "Operating System: Plumbing" },
          new Scope { Id = 8, Description = "Operating System: Fire & Life Safety" },
          new Scope { Id = 9, Description = "Operating System: Kitchen" },
          new Scope { Id = 10, Description = "Operating System: Vertical Transport" },
          new Scope { Id = 11, Description = "Other" }
      );

      modelBuilder.Entity<AssignPerson>().HasData(
               new AssignPerson { Id = 1, AssignRole = "Owner" },
               new AssignPerson { Id = 2, AssignRole = "Architect" },
               new AssignPerson { Id = 3, AssignRole = "General Contractor" },
               new AssignPerson { Id = 4, AssignRole = "Subcontractor" }
      );

      modelBuilder.Entity<Requestor>().HasData(
          new Requestor { Id = 1, RequestRole = "Owner" },
          new Requestor { Id = 2, RequestRole = "Architect" },
          new Requestor { Id = 3, RequestRole = "General Contractor" },
          new Requestor { Id = 4, RequestRole = "Subcontractor" }
 );

    }


    private string ConvertPostConnectionToConnectionString(string connection)
    {
      var _connection = connection.Replace("postgres://", String.Empty);
      var output = Regex.Split(_connection, ":|@|/");
      return $"server={output[2]};database={output[4]};User Id={output[0]}; password={output[1]}; port={output[3]}";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        var envConn = Environment.GetEnvironmentVariable("DATABASE_URL");
        // #warning Update this connection string to point to your own database.
        var conn = "server=localhost;database=WatchdogApiDatabase2";
        if (envConn != null)
        {
          conn = ConvertPostConnectionToConnectionString(envConn);
        }
        optionsBuilder.UseNpgsql(conn);
      }
    }




  }
}
