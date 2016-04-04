using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace MyTunes
{
    public interface IStreamLoader
    {
        Stream GetStreamForFilename(string filename);
    }
}
