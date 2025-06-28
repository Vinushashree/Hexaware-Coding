using Microsoft.EntityFrameworkCore;
 using Microsoft. EntityFrameworkCore.Design;

using Microsoft. Extensions. Configuration;

using System.IO;

namespace HotPot.DAL.Context

{

    // references

public class HotPotDbContextFactory : IDesignTimeDbContextFactory<HotPotDbContext>
    {

    //    O references

public HotPotDbContext CreateDbContext(string[] args)

        {

            // Hardcoded base path to fix design-time error

            IConfigurationRoot configuration = new ConfigurationBuilder()

            .SetBasePath(@"C:\Hexaware coding CaseStudy\Final CaseStudy\HotPotApp\HotPot.API")

            .AddJsonFile("appsettings.json")

            .Build();

            var builder = new DbContextOptionsBuilder<HotPotDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new HotPotDbContext(builder.Options);
        }
    }
}