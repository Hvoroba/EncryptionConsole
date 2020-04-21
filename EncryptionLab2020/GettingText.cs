// GettingText.cs
// Лабораторная работа №2.
// Студент группы 485, Дмитриев Никита Дмитриевич. 2020 год

using System;
using System.IO;

namespace EncryptionLab2020
{
    class GettingText
    {
        internal static void GetTextFromConsole()
        {
            Console.WriteLine(Menu.NL + " Enter your text:");
            string text = Console.ReadLine();

            while(text.Length == 0)
            {
                Console.WriteLine(Menu.NL + " Enter at least one symbol");
                text = Console.ReadLine();
            }

            Menu.CipherSelection(text);
        }

        internal static void GetTextFromFile()
        {
            Console.WriteLine(Menu.NL + " Enter the path:");
            string path = Console.ReadLine();
            int userChoice = IsValidPath(path);

            while (userChoice == (int)FileErrorMenuCases.NewPath)
            {
                Console.WriteLine(Menu.NL + " Enter the path:");
                path = Console.ReadLine();
                userChoice = IsValidPath(path);
            }

            if (userChoice == (int)FileErrorMenuCases.Back)
            {
                Menu.MainMenu();
            }

            if (userChoice != (int)FileErrorMenuCases.Exit && userChoice != (int)FileErrorMenuCases.Back)
            {
                string text = File.ReadAllText(path);
                Menu.CipherSelection(text);
            }

        }

        static int IsValidPath(string path)
        {
            if (path.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                Console.WriteLine(" Bad input. The path is incorrect OR the file is not available.");
                return Menu.FileErrorMenu();
            }

            try
            {
                FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
                stream.Close();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Name is reserved.");
                return Menu.FileErrorMenu();
            }
            catch (IOException)
            {
                Console.WriteLine("Bad input. The path is incorrect OR the file is not available.");
                return Menu.FileErrorMenu();
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Bad input. The path is incorrect OR the file is not available.");
                return Menu.FileErrorMenu();
            }

            if (new FileInfo(path).Length != 0)
            {
                return (int)FileErrorMenuCases.ProblemSolved;
            } else
            {
                Console.WriteLine(" File is empty");
                return Menu.FileErrorMenu();
            }
        }

    }
}
