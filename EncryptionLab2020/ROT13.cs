// ROT13.cs
// Лабораторная работа №2.
// Студент группы 485, Дмитриев Никита Дмитриевич. 2020 год

using System;

namespace EncryptionLab2020
{
    public class ROT13 : ICipher
    {
        public string Decode(string text)
        {
            string decryptedText = "";
            string upperText = text.ToUpper();
            int code;

            for (int i = 0; i < text.Length; i++)
            {
                switch(TextCheck.WhatLanguage(text[i]))
                {
                    case (int)Languages.Russian:
                        code = GetRightCodeToDecrypt(upperText[i], 'А', 'Я');
                        decryptedText += TextCheck.ProperCaseChar(text, i, code);
                        break;
                    case (int)Languages.English:
                        code = GetRightCodeToDecrypt(upperText[i], 'A', 'Z');
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
                        code = GetRightCodeToEncrypt(upperText[i], 'А', 'Я');
                        encryptedText += TextCheck.ProperCaseChar(text, i, code);
                        break;
                    case (int)Languages.English:
                        code = GetRightCodeToEncrypt(upperText[i], 'A', 'Z');
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

        private int GetRightCodeToEncrypt(char symbol, char firstSymb, char lastSymb)
        {
            int code; 

            if(symbol + 13 > lastSymb)
            {
                code = firstSymb - 1 + (symbol + 13 - lastSymb);
            } else
            {
                code = symbol + 13;
            }

            return code;
        }

        private int GetRightCodeToDecrypt(char symbol, char firstSymb, char lastSymb)
        {
            int code;

            if (symbol - 13 < firstSymb)
            {
                code = lastSymb + 1 + (symbol - firstSymb - 13);
            }
            else
            {
                code = symbol - 13;
            }

            return code;
        }

    }
}
