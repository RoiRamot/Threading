using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var openFile = new OpenFile();
            openFile.WriteToTemp();
            Console.ReadLine();
        }
    }
}
