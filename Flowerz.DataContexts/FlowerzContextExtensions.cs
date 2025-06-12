// using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowerz.DataContext.InMem
{
    public static class FlowerzContextExtensions
    {

        /// <summary>
        /// Adds FlowerzContext to the specified IServiceCollection. Uses the SqlServer database provider.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="connectionString">Set to override the default.</param>
        /// <returns>An IServiceCollection that can be used to add more services.</returns>
        public static IServiceCollection AddFlowerzContext(
          this IServiceCollection services, // The type to extend.
          string? connectionString = null)
        {
            //if (connectionString is null)
            //{
            //    SqlConnectionStringBuilder builder = new();

            //    builder.DataSource = ".";
            //    builder.InitialCatalog = "Flowerz";
            //    builder.TrustServerCertificate = true;
            //    builder.MultipleActiveResultSets = true;

            //    // Because we want to fail faster. Default is 15 seconds.
            //    builder.ConnectTimeout = 3;

            //    // If using Windows Integrated authentication.
            //    builder.IntegratedSecurity = true;

            //    // If using SQL Server authentication.
            //    // builder.UserId = Environment.GetEnvironmentVariable("MY_SQL_USR");
            //    // builder.Password = Environment.GetEnvironmentVariable("MY_SQL_PWD");

            //    connectionString = builder.ConnectionString;
            //}
         /////////////////////   services.AddFlowerzContext
          //  services.AddDbContext<FlowerzContext>(options =>
          //  {
          //     // options.UseSqlServer(connectionString);

          //      options.LogTo(FlowerzContextLogger.WriteLine,
          //        new[] { Microsoft.EntityFrameworkCore
          //.Diagnostics.RelationalEventId.CommandExecuting });
          //  },
            //// Register with a transient lifetime to avoid concurrency 
            //// issues with Blazor Server projects.
            //contextLifetime: ServiceLifetime.Transient,
            //optionsLifetime: ServiceLifetime.Transient);

            return services;
        }
    }
}
