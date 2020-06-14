using System;
using System.Collections.Generic;
using System.Text;

namespace Ustockit.Uploader.Shared.Models
{
    public class BinaryObject
    {
        public Guid Id { get; set; }
        public byte[] Bytes { get; set; }
        public BinaryObject(byte[] bytes)
        {
            Id = Guid.NewGuid();
            Bytes = bytes;
        }
    }
}
