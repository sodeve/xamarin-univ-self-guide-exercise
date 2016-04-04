using MyTunes;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MyTunes
{
    class StreamLoader : IStreamLoader
    {
        public Stream GetStreamForFilename(string filename)
        {
            return File.OpenRead(filename);
        }
    }
}
