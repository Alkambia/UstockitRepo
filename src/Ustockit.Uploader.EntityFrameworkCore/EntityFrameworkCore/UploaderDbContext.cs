using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ustockit.Uploader.EntityFrameworkCore
{
    public class UploaderDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public UploaderDbContext(DbContextOptions<UploaderDbContext> options) 
            : base(options)
        {

        }
    }
}
