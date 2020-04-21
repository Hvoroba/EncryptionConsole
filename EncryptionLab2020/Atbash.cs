// Atbash.cs
// Лабораторная работа №2.
// Студент группы 485, Дмитриев Никита Дмитриевич. 2020 год

using System;

namespace EncryptionLab2020
{
    public class Atbash : ICipher
    {
        public string Decode(string text)
        {
            string decryptedText = "";
            string upperText = text.ToUpper();
            int code;

            for (int i = 0; i < text.Length; i++)
            {
                switch (TextCheck.WhatLanguage(text[i]))
                {
                    case (int)Languages.Russian:
                        code = (int)'Я' - ((int)Languages.RusAlphabetLength - 1) - upperText[i] + (int)'Я';
                        decryptedText += TextCheck.ProperCaseChar(text, i, code);
                        break;
                    case (int)Languages.English:
                        code = (int)'Z' - ((int)Languages.EngAlphabetLength - 1) - upperText[i] + (int)'Z';
                        decryptedText += TextCheck.ProperCaseChar(text, i, code);
                        break;
                    case (int)Languages.Unknown:
                        decryptedText += text[i];
                        break;
                    default:
                        break;
                }
            }


            Console.WriteLine(Menu.NL + " Your text:" + Menu.NL + text);
            Console.WriteLine(Menu.NL + " Decrypted text:" + Menu.NL + decryptedText);

            return decryptedText;
        }

        public string Encode(string text) 
        {
            string encryptedText = "";
            string upperText = text.ToUpper();
            int code;

            for (int i = 0; i < text.Length; i++)
            {
                switch (TextCheck.WhatLanguage(text[i]))
                {
                    case (int)Languages.Russian:
                        code = (int)'А' + ((int)Languages.RusAlphabetLength - 1) - upperText[i] + (int)'А';
                        encryptedText += TextCheck.ProperCaseChar(text, i, code);
                        break;
                    case (int)Languages.English:
                        code = (int)'A' + ((int)Languages.EngAlphabetLength - 1) - upperText[i] + (int)'A';
                        encryptedText += TextCheck.ProperCaseChar(text, i, code);
                        break;
                    case (int)Languages.Unknown:
                        encryptedText += text[i];
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(Menu.NL + " Your text:" + Menu.NL + text);
            Console.WriteLine(Menu.NL + " Encrypted text:" + Menu.NL + encryptedText);

            return encryptedText;
        }
    }
}
