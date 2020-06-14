using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ustockit.Uploader.Shared.Extension;
using Ustockit.Uploader.Shared.Models;

namespace Ustockit.Uploader.Web.Controllers
{
    public class HomeController : UploaderControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Upload()
        {
            //todo: make constant string enum
            var exts = new List<string>() { ".csv", ".json", ".xlsx" };
            var files = Request.Form.Files;
            string message = "Successfully Uploaded";
            string status = "Success";

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    string extension = System.IO.Path.GetExtension(file.FileName);
                    if (exts.Contains(extension))
                    {
                        byte[] fileBytes;
                        using (var stream = file.OpenReadStream())
                        {
                            fileBytes = stream.ReadAllBytes();
                            var binaryObject = new BinaryObject(fileBytes);
                            await SaveFileAsync(extension, file, binaryObject);
                        }
                    }
                    else
                    {
                        status = "Error";
                        message = "Unsupported file Extension";
                        break;
                    }
                }
            }

            await Task.FromResult(true);
            var msg = new { Status = status, Message = message };
            return Json(msg);
        }
    }
}