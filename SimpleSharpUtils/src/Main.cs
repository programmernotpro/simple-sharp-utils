using System.IO;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Drawing;

namespace File 
{   
    public class File
    {
        //Read all contents of a file. Returns: string with all contents
        public static string ReadAll(string filePath)
        {
            string result = "";

            try
            {
                StreamReader sr = new StreamReader(filePath);

                while (sr.ReadLine() != null)
                {
                    result +=  $@"{sr.ReadLine()}\n";
                }
                return result;
            } 
            catch (Exception e)
            {
                return result;
            }

        }

        //Read up to a certain point in a file. By default it returns the first 10 lines of a file. 
        //Returns a string with the content requested
        public static string Read(string filePath, int from=0, int to=10)
        {
            string result = "";

            try {
                StreamReader sr = new StreamReader(filePath);

                for (int i = from; i < to; i++)
                {
                    result += $@"{sr.ReadLine()}\n";
                }

                return result;
            } 
            catch (Exception e)
            {
                return result;
            }
        }

        //Returns the size of a file (string)
        public static string getFormattedSize(string path)
        {   try {
                FileInfo file = new FileInfo(path);
                long size = file.Length;

                string[] possibleSizes = ["B","KB","MB","GB","TB"];
                string currentMeasurement = possibleSizes[0];

                int index = 0;

                while (size > 1024 && currentMeasurement != "TB")
                {
                    index++;
                    size /= 1024;
                    currentMeasurement = possibleSizes[index];
                }

                return $"{size}{currentMeasurement}";
            } catch(Exception e)
            {
                return "";
            }
        }
        

        //Returns the raw size of a file without string formatting
        public static long getSize(string path, string measurement="KB")
        {
            try {
                string[] possibleSizes = ["B","KB","MB","GB","TB"];

                short index = (short)possibleSizes.IndexOf(measurement); // Here, it is converted to a short for some extra crispy efficiency (not that useful to be honest)

                if (index != -1)
                {
                    FileInfo file = new FileInfo(path);
                    long size = file.Length;

                    return  size / (1024 * (index + 1));
                } 
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public static long countWords(string filePath)
        {
            try {
                string content = System.IO.File.ReadAllText(filePath);

                string[] wordCount = content.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                return wordCount.Count();
            } catch (Exception e)
            {
                return -1;
            }
        }
    }
  

}