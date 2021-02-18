using System;
using System.Collections.Generic;
using System.Text;

namespace MultiCipherForDocs.Ciphers
{
    public class RailroadCipher
    {
        public string Encipher(string message)
        {
            string firstHalf = "";
            string secondHalf = "";

            for (int i = 0; i < message.Length; i += 2)
            {
                firstHalf += message[i];
            }

            for (int i = 1; i < message.Length; i += 2)
            {
                secondHalf += message[i];
            }
            string output = $"{firstHalf}{secondHalf}";
            return output;
        }
        public string Decipher(string message)
        {
            int strSegmentA = 0;
            int strSegmentB = 0;
            string output = "";

            if (message.Length % 2 != 0)
            {
                strSegmentA = (message.Length / 2) + 1;
                strSegmentB = (message.Length / 2);
            }
            else
            {
                strSegmentA = (message.Length / 2);
                strSegmentB = strSegmentA;
            }

            string firstHalf = message.Substring(0, strSegmentA);
            string secondHalf = message.Substring(strSegmentA, strSegmentB);

            if (strSegmentA > strSegmentB)
            {
                secondHalf += "X";
                for (int i = 0; i < strSegmentA; i++)
                {
                    output += firstHalf[i];
                    output += secondHalf[i];
                }
                output = output.Substring(0, output.Length - 1);
            }
            else
            {
                for (int i = 0; i < strSegmentA; i++)
                {
                    output += firstHalf[i];
                    output += secondHalf[i];
                }
            }
            return output;
        }
    }
}
