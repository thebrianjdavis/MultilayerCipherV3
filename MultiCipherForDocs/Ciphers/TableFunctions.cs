using System;
using System.Collections.Generic;
using System.Text;

namespace MultiCipherForDocs.Ciphers
{
    public static class TableFunctions
    {
        public static string MakeCharLine()
        {
            string alphaOrigin = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return alphaOrigin;
        }
        public static string MakeExtCharLine()
        {
            string alphaOrigin = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz-_+=,./<>?;:'\"[]{}|\\!@#$%^&*() ";
            return alphaOrigin;
        }
        public static Dictionary<char, string> MakeTable(string alphaOrigin)
        {
            Dictionary<char, string> tabulaRecta = new Dictionary<char, string>();
            string alphaShift = alphaOrigin;

            for (int i = 0; i < alphaOrigin.Length; i++)
            {
                string dictStr = "";
                for (int j = 0; j < alphaShift.Length; j++)
                {
                    dictStr += alphaShift[j];
                }
                tabulaRecta.Add(alphaOrigin[i], dictStr);
                string temp = "";
                for (int k = 1; k < alphaShift.Length; k++)
                {
                    temp += alphaShift[k];
                }
                temp += alphaShift[0];
                alphaShift = temp;
            }

            return tabulaRecta;
        }
        public static int GetCharPos(char input, char keyChar)
        {
            int charPos = 0;

            Dictionary<char, string> tabulaRecta = MakeTable(MakeCharLine());
            string alphaCheck = tabulaRecta[keyChar];

            try
            {
                for (int i = 0; i < alphaCheck.Length; i++)
                {
                    if (input == alphaCheck[i])
                    {
                        charPos = i;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                MultiCipherCLI.InvalidChar();
            }
            return charPos;
        }
        public static int GetExtCharPos(char input, char keyChar)
        {
            int charPos = 0;

            Dictionary<char, string> tabulaRecta = MakeTable(MakeExtCharLine());
            string alphaCheck = tabulaRecta[keyChar];

            try
            {
                for (int i = 0; i < alphaCheck.Length; i++)
                {
                    if (input == alphaCheck[i])
                    {
                        charPos = i;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                MultiCipherCLI.InvalidChar();
            }
            return charPos;
        }
        public static string AltKeyGen(string key)
        {
            string altKey = "";
            for (int i = key.Length - 1; i >= 0; i--)
            {
                altKey += key[i];
            }
            return altKey;
        }
    }
}
