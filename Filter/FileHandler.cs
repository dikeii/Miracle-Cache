using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;

namespace PacketMonitor.Filter
{
    internal class FileHandler
    {
        public static void ReadFromFileToArrayList(string file, ArrayList list)
        {
            try
            {
                string line;
                TextReader read = File.OpenText(file);
                while ((line = read.ReadLine()) != null)
                {
                    list.Add(line);
                }
                read.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void WriteFromArrayListToFile(string file, ArrayList list)
        {
            try
            {
                TextWriter write = File.CreateText(file);
                foreach (string line in list)
                {
                    write.WriteLine(line);
                }
                write.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}