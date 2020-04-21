// Menu.cs
// Лабораторная работа №2.
// Студент группы 485, Дмитриев Никита Дмитриевич. 2020 год

using System;


namespace EncryptionLab2020
{
    internal enum MainMenuCases
    {
        FromConsole = 1,
        FromFile,
        Exit
    }

    internal enum CipherSelectionCases
    {
        AtbashEncrypt = 1,
        AtbashDecrypt,
        ROT13Enctypt,
        ROT13Decrypt
    }

    internal enum FileErrorMenuCases
    {
        NewPath = 1,
        Back,
        Exit,
        ProblemSolved
    }

    internal enum SaveMenuCases
    {
        SaveResult = 1,
        UseSecondCipher,
        Restart,
        Exit
    }

    internal enum SecondarySaveMenuCases
    {
        Yes = 1,
        No,
        Back,
        Exit
    }

    internal enum EndingMenuCases
    {
        Back = 1,
        Restart,
        Exit
    }

    internal enum Languages
    {
        English = 1,
        Russian,
        Unknown,
        EngAlphabetLength = 26,
        RusAlphabetLength = 32
    }

    class Menu
    {
        internal static string NL = Environment.NewLine;

        internal static bool MainMenu()
        {
            Console.WriteLine(NL + " 1. Enter text from console");
            Console.WriteLine(" 2. Enter text from the file");
            Console.WriteLine(" 3. Exit");

            string str = Console.ReadLine();
            Int32.TryParse(str, out int menuChoice);

            while (menuChoice < (int)MainMenuCases.FromConsole || menuChoice > (int)MainMenuCases.Exit)
            {
                Console.WriteLine(" Bad input. Only from 1 to 3");
                str = Console.ReadLine();
                Int32.TryParse(str, out menuChoice);
            }

            switch (menuChoice)
            {
                case (int)MainMenuCases.FromConsole:
                    GettingText.GetTextFromConsole();
                    break;
                case (int)MainMenuCases.FromFile:
                    GettingText.GetTextFromFile();
                    break;
                case (int)MainMenuCases.Exit:
                    return false;
                default:
                    return false;
            }
            return false;
        }

        internal static void CipherSelection(string text)
        {
            Console.WriteLine(NL + " 1. Encrypt text with Atbash");
            Console.WriteLine(" 2. Decrypt text with Atbash");
            Console.WriteLine(" 3. Encrypt text with ROT13");
            Console.WriteLine(" 4. Decrypt text with ROT13");

            string str = Console.ReadLine();
            Int32.TryParse(str, out int menuChoice);

            while (menuChoice < (int)CipherSelectionCases.AtbashEncrypt || menuChoice > (int)CipherSelectionCases.ROT13Decrypt)
            {
                Console.WriteLine(" Bad input. Only from 1 to 4");
                str = Console.ReadLine();
                Int32.TryParse(str, out menuChoice);
            }

            ICipher atbashCipher = new Atbash();
            ICipher ROT13Cipher = new ROT13();
            string resultText;

            switch (menuChoice)
            {
                case (int)CipherSelectionCases.AtbashEncrypt:
                    resultText = atbashCipher.Encode(text);
                    SaveMenu(resultText, text);
                    break;
                case (int)CipherSelectionCases.AtbashDecrypt:
                    resultText = atbashCipher.Decode(text);
                    SaveMenu(resultText, text);
                    break;
                case (int)CipherSelectionCases.ROT13Enctypt:
                    resultText = ROT13Cipher.Encode(text);
                    SaveMenu(resultText, text);
                    break;
                case (int)CipherSelectionCases.ROT13Decrypt:
                    resultText = ROT13Cipher.Decode(text);
                    SaveMenu(resultText, text);
                    break;
                default:
                    break;
            }
        }

        internal static int FileErrorMenu()
        {
            Console.WriteLine(NL + " 1. Enter new path");
            Console.WriteLine(" 2. Back");
            Console.WriteLine(" 3. Exit");

            string str = Console.ReadLine();
            Int32.TryParse(str, out int menuChoice);

            while (menuChoice < (int)FileErrorMenuCases.NewPath || menuChoice > (int)FileErrorMenuCases.Exit)
            {
                Console.WriteLine(" Bad input. Only from 1 to 3");
                str = Console.ReadLine();
                Int32.TryParse(str, out menuChoice);
            }

            return menuChoice;
        }

        internal static void SaveMenu(string reusltText, string sourceText)
        {
            Console.WriteLine(NL + " 1. Save result into the file");
            Console.WriteLine(" 2. Use second cipher");
            Console.WriteLine(" 3. Restart the program");
            Console.WriteLine(" 4. Exit");

            string str = Console.ReadLine();
            Int32.TryParse(str, out int menuChoice);

            while (menuChoice < (int)SaveMenuCases.SaveResult || menuChoice > (int)SaveMenuCases.Exit)
            {
                Console.WriteLine(" Bad input. Only from 1 to 4");
                str = Console.ReadLine();
                Int32.TryParse(str, out menuChoice);
            }

            switch (menuChoice)
            {
                case (int)SaveMenuCases.SaveResult:
                    SavingResult.SaveResult(reusltText, sourceText);
                    break;
                case (int)SaveMenuCases.UseSecondCipher:
                    CipherSelection(sourceText);
                    break;
                case (int)SaveMenuCases.Restart:
                    MainMenu();
                    break;
                case (int)SaveMenuCases.Exit:
                    break;
                default:
                    break;
            }
        }

        internal static int SecondarySaveMenu()
        {
            Console.WriteLine(NL + " The file isn't empty. Overwrite it?");
            Console.WriteLine(" 1. Yes");
            Console.WriteLine(" 2. No");
            Console.WriteLine(" 3. Back");
            Console.WriteLine(" 4. Exit");

            string str = Console.ReadLine();
            Int32.TryParse(str, out int menuChoice);

            while (menuChoice < (int)SecondarySaveMenuCases.Yes || menuChoice > (int)SecondarySaveMenuCases.Exit)
            {
                Console.WriteLine(" Bad input. Only from 1 to 4");
                str = Console.ReadLine();
                Int32.TryParse(str, out menuChoice);
            }

            return menuChoice;
        }

        internal static void EndingMenu(string sourceText)
        {
            Console.WriteLine(NL + " 1. Back");
            Console.WriteLine(" 2. Restart the program");
            Console.WriteLine(" 3. Exit");

            string str = Console.ReadLine();
            Int32.TryParse(str, out int menuChoice);

            while (menuChoice < (int)EndingMenuCases.Back || menuChoice > (int)EndingMenuCases.Exit)
            {
                Console.WriteLine(" Bad input. Only from 1 to 3");
                str = Console.ReadLine();
                Int32.TryParse(str, out menuChoice);
            }

            switch(menuChoice)
            {
                case (int)EndingMenuCases.Back:
                    CipherSelection(sourceText);
                    break;
                case (int)EndingMenuCases.Restart:
                    MainMenu();
                    break;
                case (int)EndingMenuCases.Exit:
                    break;
            }
        }
    }
}
