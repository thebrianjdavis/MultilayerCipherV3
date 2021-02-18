using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MultiCipherForDocs.Ciphers;

namespace MultiCipherForDocs
{
    public class DocumentIO
    {
        public DocumentIO()
        {
            
        }
        MultiLayerCipher mlc = new MultiLayerCipher();
        RailroadCipher rrc = new RailroadCipher();
        public bool Encipher(string fullPath, string key)
        {
            bool fileCreated = false;
            string altKey = TableFunctions.AltKeyGen(key);

            try
            {
                string fileName = Path.GetFileName(fullPath);
                string fileNameNoExt = Path.GetFileNameWithoutExtension(fileName);
                string fileExt = Path.GetExtension(fileName);

                string fileDir = fullPath.Substring(0, fullPath.Length - fileName.Length);
                string createFile = fileNameNoExt + "MLC" + fileExt;
                string createFull = Path.Combine(fileDir, createFile);

                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        using (StreamWriter sw = new StreamWriter(createFull, true))
                        {
                            string output = "";
                            output = mlc.Encipher(sr.ReadLine(), key);
                            output = rrc.Encipher(output);
                            sw.WriteLine(mlc.Encipher(output, altKey));
                        }
                    }
                }
                if (Path.IsPathFullyQualified(createFull))
                {
                    fileCreated = true;
                }
                File.Move(createFull, fullPath, true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input for file path...");
            }
            return fileCreated;
        }
        public bool Decipher(string fullPath, string key)
        {
            bool fileCreated = false;
            string altKey = TableFunctions.AltKeyGen(key);

            try
            {
                string fileName = Path.GetFileName(fullPath);
                string fileNameNoExt = Path.GetFileNameWithoutExtension(fileName);
                string fileExt = Path.GetExtension(fileName);

                string fileDir = fullPath.Substring(0, fullPath.Length - fileName.Length);
                string createFile = fileNameNoExt + "MLC" + fileExt;
                string createFull = Path.Combine(fileDir, createFile);

                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        using (StreamWriter sw = new StreamWriter(createFull, true))
                        {
                            string output = "";
                            output = mlc.Decipher(sr.ReadLine(), altKey);
                            output = rrc.Decipher(output);
                            sw.WriteLine(mlc.Decipher(output, key));
                        }
                    }
                }
                if (Path.IsPathFullyQualified(createFull))
                {
                    fileCreated = true;
                }
                File.Move(createFull, fullPath, true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input for file path...");
            }
            return fileCreated;
        }

    }
}
