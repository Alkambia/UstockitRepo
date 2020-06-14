using System.Threading.Tasks;
using Ustockit.Uploader.Web.Controllers;
using Shouldly;
using Xunit;

namespace Ustockit.Uploader.Web.Tests.Controllers
{
    public class HomeController_Tests: UploaderWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
