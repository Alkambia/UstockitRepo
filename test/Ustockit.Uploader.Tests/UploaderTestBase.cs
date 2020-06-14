using System;
using System.Threading.Tasks;
using Abp.TestBase;
using Ustockit.Uploader.EntityFrameworkCore;
using Ustockit.Uploader.Tests.TestDatas;

namespace Ustockit.Uploader.Tests
{
    public class UploaderTestBase : AbpIntegratedTestBase<UploaderTestModule>
    {
        public UploaderTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<UploaderDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<UploaderDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<UploaderDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<UploaderDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<UploaderDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<UploaderDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<UploaderDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<UploaderDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
