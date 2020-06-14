using Microsoft.EntityFrameworkCore;

namespace Ustockit.Uploader.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<UploaderDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for UploaderDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
