using Microsoft.EntityFrameworkCore;
//using Flowerz.DataContext.SqlServer;
////using Microsoft.Data.SqlClient; // To use SqlConnectionStringBuilder.
//using Flowerz.EntityModels;

namespace Flowerz.DataContexts;

public partial class FlowerzContext : DbContext
{
    public FlowerzContext()
    { }

    public FlowerzContext(DbContextOptions options)
        : base(options)
    { }

   public virtual DbSet<Flowerz.Persistence.Entities.Bloom> Blooms { get; set; }


    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Flowerz;Integrated Security=true;TrustServerCertificate=true;");

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseInMemoryDatabase("MyDatabase");
    //}

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        //SqlConnectionStringBuilder builder = new();

    //        //builder.DataSource = "."; // "ServerName\InstanceName" e.g. @".\sqlexpress"
    //        //builder.InitialCatalog = "Flowerz";
    //        //builder.TrustServerCertificate = true;
    //        //builder.MultipleActiveResultSets = true;

    //        //// Because we want to fail faster. Default is 15 seconds.
    //        //builder.ConnectTimeout = 3;

    //        //// If using Windows Integrated authentication.
    //        //builder.IntegratedSecurity = true;

    //        // If using SQL Server authentication.
    //        // builder.UserId = Environment.GetEnvironmentVariable("MY_SQL_USR");
    //        // builder.Password = Environment.GetEnvironmentVariable("MY_SQL_PWD");

    //        //  optionsBuilder.UseSqlServer(builder.ConnectionString);
    //        optionsBuilder.UseInMemoryDatabase("MyDatabase");

    //        optionsBuilder.LogTo(FlowerzContextLogger.WriteLine,
    //          new[] { Microsoft.EntityFrameworkCore
    //    .Diagnostics.RelationalEventId.CommandExecuting });
    //    }
    //}

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    OnModelCreatingPartial(modelBuilder);
    //}

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
