// TextCheck.cs
// Лабораторная работа №2.
// Студент группы 485, Дмитриев Никита Дмитриевич. 2020 год

namespace EncryptionLab2020
{
    class TextCheck
    {
        internal static int WhatLanguage(char ch)
        {
            int charDec = (int)char.ToUpper(ch);

            if (charDec >= (int)'A' && charDec <= (int)'Z')
            {
                return (int)Languages.English;
            }
            else if (charDec >= (int)'А' && charDec <= (int)'Я')
            {
                return (int)Languages.Russian;
            }
            else
            {
                return (int)Languages.Unknown;
            }
        }

        internal static char ProperCaseChar(string text, int index, int code)
        {
            char ch = (char)code;

            if (!char.IsUpper(text[index]))
            {
                ch = char.ToLower(ch);
            }

            return ch;
        }

    }
}
