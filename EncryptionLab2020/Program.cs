// Program.cs
// Лабораторная работа №2.
// Студент группы 485, Дмитриев Никита Дмитриевич. 2020 год

using System;


namespace EncryptionLab2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Hello, wanderer. This surely usefull program encrypts and decrypts text with atbash and ROT13.");

            bool keepGoing = true;

            while (keepGoing)
            {
                keepGoing = Menu.MainMenu();
            }
        }
    }
}
