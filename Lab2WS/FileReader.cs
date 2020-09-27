using System.IO;
using System.Reflection;

namespace Lab2WS
{
    class FileReader
    {
        public string[] Read(string filename)
        {
            
            return File.ReadAllLines(filename);
           
        }
    }
}
