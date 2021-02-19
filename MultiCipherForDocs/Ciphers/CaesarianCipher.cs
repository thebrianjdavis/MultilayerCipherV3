using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MultiCipherForDocs.Ciphers
{
    public class CaesarianCipher
    {
        private string charLine = TableFunctions.MakeCharLine();
        public string Encipher(string message, int key)
        {
            Dictionary<char, string> tabulaRecta = TableFunctions.MakeTable(charLine);
            string output = "";
            message = message.ToUpper();
            message = String.Concat(message.Where(c => !Char.IsWhiteSpace(c)));


            try
            {
                while (output.Length < message.Length)
                {
                    for (int i = 0; i < message.Length; i++)
                    {
                        foreach (KeyValuePair<char, string> charX in tabulaRecta)
                        {
                            if (charLine[key] == charX.Key)
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
        public string Decipher(string message, int key)
        {
            Dictionary<char, string> tabulaRecta = TableFunctions.MakeTable(charLine);
            string output = "";
            message = message.ToUpper();
            message = String.Concat(message.Where(c => !Char.IsWhiteSpace(c)));
            
            try
            {
                while (output.Length < message.Length)
                {
                    for (int i = 0; i < message.Length; i++)
                    {
                        int charPos = TableFunctions.GetCharPos(message[i], charLine[key]);
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
