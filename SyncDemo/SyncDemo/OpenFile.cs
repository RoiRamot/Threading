using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncDemo
{
    class OpenFile
    {
        private static Mutex mut = new Mutex();
        public void Open(string filepath)
        {
            mut.WaitOne();
            File.AppendAllText(filepath, System.Diagnostics.Process.GetCurrentProcess().Id.ToString() + Environment.NewLine);
            Thread.Sleep(500);
            mut.ReleaseMutex();
        }

        public void WriteToTemp()
        {
            string filePath = @"c:/roitemp";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
                File.CreateText(filePath + @"\SyncFileMutex.text");
            }
            for (int i = 0; i < 50000; i++)
            {
                Task.Run(() => Open(filePath + @"\SyncFileMutex.text"));
            }

        }
    }
}
