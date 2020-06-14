using Ustockit.Uploader.EntityFrameworkCore;

namespace Ustockit.Uploader.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly UploaderDbContext _context;

        public TestDataBuilder(UploaderDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}