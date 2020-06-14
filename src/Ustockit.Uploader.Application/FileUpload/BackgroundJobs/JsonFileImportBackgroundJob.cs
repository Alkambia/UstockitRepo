using Abp.BackgroundJobs;
using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using Ustockit.Uploader.FileUpload.JobArgs;

namespace Ustockit.Uploader.FileUpload.BackgroundJobs
{
    //todo: background job can be customized, queue priorities can be set from abstract class
    public class JsonFileImportBackgroundJob : BackgroundJob<JsonFileImportArg>, ITransientDependency
    {
        //declare injected repository here

        public override void Execute(JsonFileImportArg args)
        {
            //code here
            //a response from here will send notification to client,
            //possible setup would be signalr
        }
    }
}
