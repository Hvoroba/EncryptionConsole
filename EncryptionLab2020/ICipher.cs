// ICipher.cs
// Лабораторная работа №2.
// Студент группы 485, Дмитриев Никита Дмитриевич. 2020 год

namespace EncryptionLab2020
{
    public interface ICipher
    {
        string Encode(string text);

        string Decode(string text);
    }
}
