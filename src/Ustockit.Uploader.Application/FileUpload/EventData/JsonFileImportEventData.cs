using System;
using System.Collections.Generic;
using System.Text;
using Ustockit.Uploader.Shared.Models;

namespace Ustockit.Uploader.FileUpload.EventData
{
    public class JsonFileImportEventData : Abp.Events.Bus.EventData
    {
        public string File { get; set; }
        public BinaryObject BinaryObjectFile { get; set; }
    }
}
