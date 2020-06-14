using System;
using System.Collections.Generic;
using System.Text;
using Ustockit.Uploader.Shared.Models;

namespace Ustockit.Uploader.FileUpload.JobArgs
{
    public class JsonFileImportArg
    {
        public string File { get; set; }
        public BinaryObject BinaryObjectFile { get; set; }
    }
}
