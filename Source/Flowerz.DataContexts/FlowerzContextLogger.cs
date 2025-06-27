using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace Flowerz.DataContext.InMem;

internal class FlowerzContextLogger
{
    public static void WriteLine(string message)
    {
        string path = Path.Combine(GetFolderPath(
          SpecialFolder.DesktopDirectory), "flowerzlog.txt");

        StreamWriter textFile = File.AppendText(path);
        textFile.WriteLine("FlowerzAPI InMem: " + message);
        textFile.Close();
    }
}
