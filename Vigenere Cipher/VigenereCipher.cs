using System;
using System.Text;

namespace Task1.Vigenere_Cipher
{
    public class VigenereCipher
    {
        private string key = "crypto";
        private const int small = 97;
        private const int big = 65;
        private bool isBig;
        private int whiteSpaces = 0;
        public string CryptText(string text)
        {
            var cryptText = "";
            var keyLength = key.Length;
            for (var i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    cryptText += text[i];
                    whiteSpaces++;
                }
                else
                {
                    var v = (NormalizeCharToInt(key[(i-whiteSpaces) % keyLength]) + NormalizeCharToInt(text[i])) % 26;
                    cryptText += NormalizeIntToChar(v);
                }
            }
            return cryptText;
        }

        private int NormalizeCharToInt(char c)
        {
            isBig = c < 'a';
            return c >= 'a' ? c - small : c - big;
        }
        private char NormalizeIntToChar(int c)
        {
            return isBig ? (char) (c + big) : (char) (c + small);
        }
    }
}