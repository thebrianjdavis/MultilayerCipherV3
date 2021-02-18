using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MultiCipherForDocs.Ciphers
{
    public class VigenereCipher
    {
        private string charLine = TableFunctions.MakeCharLine();
        public string Encipher(string message, string key)
        {
            Dictionary<char, string> tabulaRecta = TableFunctions.MakeTable(charLine);
            string output = "";
            message = message.ToUpper();
            message = String.Concat(message.Where(c => !Char.IsWhiteSpace(c)));
            key = key.ToUpper();
            key = String.Concat(key.Where(c => !Char.IsWhiteSpace(c)));

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
                                int charPos = TableFunctions.GetCharPos(message[i], 'A');
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
            Dictionary<char, string> tabulaRecta = TableFunctions.MakeTable(charLine);
            string output = "";
            message = message.ToUpper();
            message = String.Concat(message.Where(c => !Char.IsWhiteSpace(c)));
            key = key.ToUpper();
            key = String.Concat(key.Where(c => !Char.IsWhiteSpace(c)));

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
                        int charPos = TableFunctions.GetCharPos(message[i], key[k]);
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
