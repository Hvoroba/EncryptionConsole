// SavingResult.cs
// Лабораторная работа №2.
// Студент группы 485, Дмитриев Никита Дмитриевич. 2020 год

using System;
using System.IO;

namespace EncryptionLab2020
{
    class SavingResult
    {
        internal static void SaveResult(string resultText, string sourceText)
        {
            Console.WriteLine(Menu.NL + " Enter the path:");
            string path = Console.ReadLine();
            int userChoice = CanBeSaved(path);

            while (userChoice == (int)FileErrorMenuCases.NewPath)
            {
                Console.WriteLine(Menu.NL + " Enter the path:");
                path = Console.ReadLine();
                userChoice = CanBeSaved(path);
            }

            if (userChoice == (int)FileErrorMenuCases.Back)
            {
                Menu.SaveMenu(resultText, sourceText);
            }

            if (userChoice != (int)FileErrorMenuCases.Exit && userChoice != (int)FileErrorMenuCases.Back)
            {
                StreamWriter sw = new StreamWriter(path, false);
                sw.Write(resultText);
                sw.Close();

                Console.WriteLine(Menu.NL + " Success!");
                Menu.EndingMenu(sourceText);
            }
        }

        static int CanBeSaved(string path)
        {
            if (path.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                Console.WriteLine(" Bad input. The path is incorrect OR the file is not available. Try again:");
                return Menu.FileErrorMenu();
            }

            try
            {
                FileStream stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read);
                {
                    stream.Close();
                    if (new FileInfo(path).Length != 0)
                    {
                        int menuChoice = Menu.SecondarySaveMenu();
                        switch (menuChoice)
                        {
                            case (int)SecondarySaveMenuCases.Yes:
                                return (int)FileErrorMenuCases.ProblemSolved;
                            case (int)SecondarySaveMenuCases.No:
                                return (int)FileErrorMenuCases.NewPath;
                            case (int)SecondarySaveMenuCases.Back:
                                return (int)FileErrorMenuCases.Back;
                            case (int)SecondarySaveMenuCases.Exit:
                                return (int)FileErrorMenuCases.Exit;
                            default:
                                break;
                        }
                    }
                    return (int)FileErrorMenuCases.ProblemSolved;
                }
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

        }
    }
}
