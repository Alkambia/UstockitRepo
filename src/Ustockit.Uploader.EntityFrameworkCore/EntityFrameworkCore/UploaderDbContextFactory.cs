using Ustockit.Uploader.Configuration;
using Ustockit.Uploader.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Ustockit.Uploader.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class UploaderDbContextFactory : IDesignTimeDbContextFactory<UploaderDbContext>
    {
        public UploaderDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<UploaderDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(UploaderConsts.ConnectionStringName)
            );

            return new UploaderDbContext(builder.Options);
        }
    }
}