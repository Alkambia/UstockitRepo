using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Ustockit.Uploader.Shared.Models;

namespace Ustockit.Uploader.Web.Infrastructure.Abstract
{
    public interface IFile
    {
        //todo: transfer to another folder, just created this interface fo unit test mock
        Task SaveFileAsync(string extension, IFormFile file, BinaryObject binaryObject);
    }
}
