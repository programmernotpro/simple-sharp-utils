using System.IO;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Drawing;
using System.Data.Common;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Numerics;

namespace FileUtils
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
                string? line;

                do
                {
                    result +=  $@"{sr.ReadLine()}" + "\n";

                } while ((line = sr.ReadLine()) != null);

                return result;
            } 
            catch (Exception)
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
                    if (sr.EndOfStream) break;

                    result += $@"{sr.ReadLine()}" + "\n";
                }

                return result;
            } 
            catch (Exception)
            {
                return result;
            }
        }

        //Returns the size of a file (string)
        public static string GetFormattedSize(string path)
        {   try 
        {
                decimal fileSize = new FileInfo(path).Length;

                string[] possibleSizes = {"B","KB","MB","GB","TB"};

                int index = 0;
                string currentMeasurement = possibleSizes[index];

                while (fileSize > 1024 && currentMeasurement != "TB")
                {
                    index++;
                    fileSize /= 1024; ;
                    currentMeasurement = possibleSizes[index];
                }

                return $"{Math.Round(fileSize,2)}{currentMeasurement}";
            } 
            
            catch(Exception)
            {
                return "";
            }
        }
        

        //Returns the raw size of a file without string formatting
        public static decimal GetSize(string path, string measurement="KB")
        {   
        
                try 
                {
                    decimal fileSize = new FileInfo(path).Length;

                    string[] possibleSizes = {"B","KB","MB","GB","TB"};

                    int measurementIndex = possibleSizes.IndexOf(measurement);

                    string currentMeasurement = possibleSizes[measurementIndex];

                    if (measurementIndex == -1) return -1;

                    for (int i = 0; i < measurementIndex; i++)
                    {
                        fileSize /= 1024; 
                    }

                    return Math.Round(fileSize,2);
                } 

                catch(Exception)
                {
                    return -1;
                }
            }

        public static long CountWords(string filePath)
        {
            try {
                string content = System.IO.File.ReadAllText(filePath);

                string[] wordCount = content.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                return wordCount.Count();
            } catch (Exception)
            {
                return -1;
            }
        }

        public static string GetExtension(string filePath)
        {
            try 
            {
                return filePath.Substring(filePath.LastIndexOf('.'));
            }  
            catch (Exception)
            {
                return "";
            }
        }
    }

    public class Directory
    {
        public static int GetFilesNumber(string path) 
        {
            try {
                string[] dir = System.IO.Directory.GetFiles(path);
                
                int numberOfFiles = dir.Length;

                return numberOfFiles;

            }
            catch(Exception)
            {
                return -1;
            }
        }

        public static long GetFilesNumberMulti(string[] paths)
        {
            try
            {
                long total = 0;
                foreach (string path in paths)
                {
                    total += System.IO.Directory.GetFiles(path).Length;
                }

                return total; 
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static string[] GetFiles(string path, int first = 0)
        {
            try
            {
                string[] files = System.IO.Directory.GetFiles(path);

                if (first == 0)
                    return files;

                return files[..first];
            }
            catch (Exception)
            {
                return [];
            }
        }

        public static Dictionary<string, string[]> GetFilesMulti(string[] paths)
        {
            try {
                Dictionary<string, string[]> fileDictionary = new Dictionary<string, string[]>();

                foreach (string path in paths)
                {
                    fileDictionary.Add(path, System.IO.Directory.GetFiles(path));
                }

                return fileDictionary;
            }
            catch(Exception)
            {
                return  new Dictionary<string, string[]>
                {
                    {"",[]}
                };
            }
        }




    }
  

}