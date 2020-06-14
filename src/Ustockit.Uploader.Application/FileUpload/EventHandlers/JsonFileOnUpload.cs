using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ustockit.Uploader.FileUpload.BackgroundJobs;
using Ustockit.Uploader.FileUpload.EventData;
using Ustockit.Uploader.FileUpload.JobArgs;

namespace Ustockit.Uploader.FileUpload.EventHandlers
{
    public class JsonFileOnUpload : IAsyncEventHandler<JsonFileImportEventData>,
        ITransientDependency
    {
        private readonly IBackgroundJobManager _backgroundJobManager;
        public JsonFileOnUpload(IBackgroundJobManager backgroundJobManager)
        {
            _backgroundJobManager = backgroundJobManager;
        }
        public async Task HandleEventAsync(JsonFileImportEventData eventData)
        {
            await _backgroundJobManager.EnqueueAsync<JsonFileImportBackgroundJob, JsonFileImportArg>(new JsonFileImportArg()
            {
                File = eventData.File,
                BinaryObjectFile = eventData.BinaryObjectFile
            });
        }
    }
}
