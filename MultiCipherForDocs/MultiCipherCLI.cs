using System;
using System.Collections.Generic;
using System.Text;
using MultiCipherForDocs.Ciphers;
using System.IO;

namespace MultiCipherForDocs
{
    public class MultiCipherCLI
    {
        const string Command_Caesarian_Cipher = "1";
        const string Command_Vigenere_Cipher = "2";
        const string Command_Railroad_Cipher = "3";
        const string Command_MultiLayer_Cipher = "4";
        const string Command_Document_Cipher = "5";
        const string Command_Instructions = "i";
        const string Command_Quit = "q";

        private readonly CaesarianCipher caesarian = new CaesarianCipher();
        private readonly RailroadCipher railroad = new RailroadCipher();
        private readonly VigenereCipher vigenere = new VigenereCipher();
        private readonly MultiLayerCipher multilayer = new MultiLayerCipher();
        private readonly DocumentIO documentIO = new DocumentIO();

        public MultiCipherCLI()
        {

        }
        
        public void RunCLI()
        {
            PrintHeader();
            PrintInstructions();

            while(true)
            {
                PrintMenu();
                string command = Console.ReadLine();
                Console.Clear();

                switch (command.ToLower())
                {
                    case Command_Caesarian_Cipher:
                        RunCaesarian();
                        break;

                    case Command_Vigenere_Cipher:
                        RunVigenere();
                        break;

                    case Command_Railroad_Cipher:
                        RunRailroad();
                        break;

                    case Command_MultiLayer_Cipher:
                        RunMultilayer();
                        break;

                    case Command_Document_Cipher:
                        RunDocument();
                        break;

                    case Command_Instructions:
                        RunInstructions();
                        break;

                    case Command_Quit:
                        ThankYou();
                        RetToCon();
                        return;
                }
            }
        }
        private void RunCaesarian()
        {
            PrintHeader();
            string selection = EncryptOrDecrypt();
            string message = GetMessage(selection);
            int key = GetCaesarKey();
            string output = "";

            if (selection == "2")
            {
                PrintHeader();
                output = caesarian.Decipher(message, key);
                Console.WriteLine(output);
            }
            else
            {
                PrintHeader();
                output = caesarian.Encipher(message, key);
                Console.WriteLine(output);
            }
            RetToCon();
        }
        private void RunVigenere()
        {
            PrintHeader();
            string selection = EncryptOrDecrypt();
            string message = GetMessage(selection);
            string key = GetKey();
            string output = "";

            if (selection == "2")
            {
                PrintHeader();
                output = vigenere.Decipher(message, key);
                Console.WriteLine(output);
            }
            else
            {
                PrintHeader();
                output = vigenere.Encipher(message, key);
                Console.WriteLine(output);
            }
            RetToCon();
        }
        private void RunRailroad()
        {
            PrintHeader();

            string selection = EncryptOrDecrypt();
            string message = GetMessage(selection);
            string output = "";

            if (selection == "2")
            {
                PrintHeader();
                output = railroad.Decipher(message);
                Console.WriteLine(output);
            }
            else
            {
                PrintHeader();
                output = railroad.Encipher(message);
                Console.WriteLine(output);
            }
            RetToCon();
        }
        private void RunMultilayer()
        {
            PrintHeader();

            string selection = EncryptOrDecrypt();
            string message = GetMessage(selection);
            string key = GetKey();
            string altKey = TableFunctions.AltKeyGen(key);
            string output = "";

            if (selection == "2")
            {
                PrintHeader();
                output = multilayer.Decipher(message, altKey);
                output = railroad.Decipher(output);
                output = multilayer.Decipher(output, key);
                Console.WriteLine(output);
            }
            else
            {
                PrintHeader();
                output = multilayer.Encipher(message, key);
                output = railroad.Encipher(output);
                output = multilayer.Encipher(output, altKey);
                Console.WriteLine(output);
            }
            RetToCon();
        }
        private void RunDocument()
        {
            PrintHeader();

            string selection = EncryptOrDecrypt();
            string fullPath = GetFilePath();
            string key = GetKey();
            string altKey = TableFunctions.AltKeyGen(key);

            if (selection == "2")
            {
                PrintHeader();
                bool decipherSuccessful = documentIO.Decipher(fullPath, key);
                if (decipherSuccessful)
                {
                    Console.WriteLine("File decipher successful!");
                }
                else
                {
                    Console.WriteLine("File decipher was not successful, please try again!");
                }
            }
            else
            {
                PrintHeader();
                bool encipherSuccessful = documentIO.Encipher(fullPath, key);
                if (encipherSuccessful)
                {
                    Console.WriteLine("File encipher successful!");
                }
                else
                {
                    Console.WriteLine("File encipher was not successful, please try again!");
                }
            }
            RetToCon();
        }
        private void RunInstructions()
        {
            PrintHeader();
            PrintInstructions();
        }
        public static void PrintHeader()
        {
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            Console.WriteLine("%%%%%%%%%%% MultiCipher v 3.0 %%%%%%%%%%%");
            Console.WriteLine("%%%%%%%%%%%% By: Brian Davis %%%%%%%%%%%%");
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            Console.WriteLine();
        }
        public static void PrintInstructions()
        {
            Console.WriteLine("This console application can encode a");
            Console.WriteLine("sequence of characters with a cipher key");
            Console.WriteLine("of your choosing.\n");
            Console.WriteLine("All uppercase and lowercase English");
            Console.WriteLine("characters are supported in multilayer");
            Console.WriteLine("mode.");
            Console.WriteLine("\nVigenere and Caesarian Ciphers are");
            Console.WriteLine("restricted to all uppercase letters and");
            Console.WriteLine("will remove any spaces.\n");
            RetToCon();
        }
        public static void PrintMenu()
        {
            PrintHeader();
            Console.WriteLine("Please select from the following options:\n");
            Console.WriteLine("(1) Caesarian Cipher");
            Console.WriteLine("(2) Vigenere Cipher");
            Console.WriteLine("(3) Railroad Cipher");
            Console.WriteLine("(4) Multilayer Cipher");
            Console.WriteLine("(5) Document Encrypter");
            Console.WriteLine("(i) Instructions");
            Console.WriteLine("(q) Exit program");
        }
        public static string EncryptOrDecrypt()
        {
            string encodeDecode = "";
            while (true)
            {
                PrintHeader();
                Console.WriteLine("Please select from the following options:\n");
                Console.WriteLine("(1) Encode a message");
                Console.WriteLine("(2) Decode a message");
                encodeDecode = Console.ReadLine();
                Console.Clear();
                if (encodeDecode == "1" || encodeDecode == "2")
                {
                    break;
                }
                else
                {
                    Invalid();
                }
            }
            return encodeDecode;
        }
        public static void Invalid()
        {
            Console.WriteLine("Invalid input, please try again...\n");
            RetToCon();
        }
        public static void RetToCon()
        {
            Console.WriteLine("\nPlease press RETURN to continue...");
            Console.ReadLine();
            Console.Clear();
        }
        public static string GetMessage(string selection)
        {
            string inline = "";
            if (selection == "2") inline = "decode";
            else inline = "encode";

            string message = "";
            while (true)
            {
                PrintHeader();
                Console.WriteLine($"Please input your message text to {inline}:\n");
                message = Console.ReadLine();
                Console.Clear();
                if (message.Length < 1)
                {
                    Invalid();
                }
                else
                {
                    break;
                }
            }
            return message;
        }
        public static string GetKey()
        {
            string message = "";
            while (true)
            {
                PrintHeader();
                Console.WriteLine("Please input your cipher key:\n");
                message = Console.ReadLine();
                Console.Clear();
                if (message.Length < 1)
                {
                    Invalid();
                }
                else
                {
                    break;
                }
            }
            return message;
        }
        public static int GetCaesarKey()
        {
            int shiftKey = 0;
            while (true)
            {
                PrintHeader();
                Console.WriteLine("Please input a number (1-25) for a Caesarian shift:\n");
                string message = Console.ReadLine();
                shiftKey = int.Parse(message);
                Console.Clear();
                if (shiftKey > 1 || shiftKey < 25)
                {
                    break;
                }
                else
                {
                    Invalid();
                }
            }
            return shiftKey;
        }
        public static string GetFilePath()
        {
            string fullPath = "";
            while (true)
            {
                PrintHeader();
                Console.WriteLine("Please input a fully qualified file path:\n");
                fullPath = Console.ReadLine();
                Console.Clear();
                if (!Path.IsPathFullyQualified(fullPath))
                {
                    Invalid();
                }
                else
                {
                    break;
                }
            }
            return fullPath;
        }
        public static void InvalidChar()
        {
            Console.Clear();
            PrintHeader();
            Console.WriteLine("User input contained an invalid character\n");
            RetToCon();
        }
        public static void ThankYou()
        {
            Console.WriteLine("Thank");
            Console.WriteLine("Thank you");
            Console.WriteLine("Thank you for");
            Console.WriteLine("Thank you for using");
            Console.WriteLine("Thank you for using MultiCipher");
            Console.WriteLine("Thank you for using");
            Console.WriteLine("Thank you for");
            Console.WriteLine("Thank you");
            Console.WriteLine("Thank");

        }
    }
}
