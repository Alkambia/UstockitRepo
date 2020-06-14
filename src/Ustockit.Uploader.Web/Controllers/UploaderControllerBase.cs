using Abp.AspNetCore.Mvc.Controllers;
using Abp.Events.Bus;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Ustockit.Uploader.FileUpload.EventData;
using Ustockit.Uploader.Shared.Models;
using Ustockit.Uploader.Web.Infrastructure.Abstract;
using Ustockit.Uploader.Web.Infrastructure.Concrete;

namespace Ustockit.Uploader.Web.Controllers
{
    public abstract class UploaderControllerBase: AbpController, IFile
    {
        public IEventBus _eventBus { get; set; }
        protected UploaderControllerBase()
        {
            _eventBus = NullEventBus.Instance;
            LocalizationSourceName = UploaderConsts.LocalizationSourceName;
        }

        public async Task SaveFileAsync(string extension, IFormFile file, BinaryObject binaryObject)
        {
            switch (extension)
            {
                case ".csv": { 
                        await new CsvParser().ParseAsync(file.FileName, binaryObject); 
                        break; }
                case ".json":
                    {
                        //todo: manual trigger sample
                        await _eventBus.TriggerAsync(new JsonFileImportEventData { File = file.FileName, BinaryObjectFile = binaryObject });
                        break;
                    }
                case ".xlsx": { 
                        await new ExcelParser().ParseAsync(file.FileName, binaryObject); 
                        break; 
                    }
            }
        }

    }
}