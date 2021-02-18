using System;
using System.Collections.Generic;
using System.Text;

namespace MultiCipherForDocs.Ciphers
{
    public class MultiLayerCipher
    {
        private string extCharLine = TableFunctions.MakeExtCharLine();
        public string Encipher(string message, string key)
        {
            Dictionary<char, string> tabulaRecta = TableFunctions.MakeTable(extCharLine);
            string output = "";

            try
            {
                while (output.Length < message.Length)
                {
                    for (int i = 0; i < message.Length; i++)
                    {
                        int k = i;
                        if (k > key.Length - 2)
                        {
                            k = (k % key.Length);
                        }
                        foreach (KeyValuePair<char, string> charX in tabulaRecta)
                        {
                            if (key[k] == charX.Key)
                            {
                                int charPos = TableFunctions.GetExtCharPos(message[i], 'A');
                                output += charX.Value[charPos];
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MultiCipherCLI.InvalidChar();
            }
            return output;
        }
        public string Decipher(string message, string key)
        {
            Dictionary<char, string> tabulaRecta = TableFunctions.MakeTable(extCharLine);
            string output = "";
            try
            {
                while (output.Length < message.Length)
                {
                    for (int i = 0; i < message.Length; i++)
                    {
                        int k = i;
                        if (k > key.Length - 2)
                        {
                            k = (k % key.Length);
                        }
                        int charPos = TableFunctions.GetExtCharPos(message[i], key[k]);
                        string temp = tabulaRecta['A'];
                        output += temp[charPos];
                    }
                }
            }
            catch (Exception e)
            {
                MultiCipherCLI.InvalidChar();
            }
            return output;
        }
    }
}
