using System;

namespace SubstitutionCiphers.Ciphers
{
    public static class AffineCipher
    {
        private static int Gcd(int a, int b)
        {
            while (b != 0)
            {
                var temp = a;
                a = b;
                b = temp % b;
            }
            return a;
        }

        private static int? ModInverse(int a, int m)
        {
            for (var i = 1; i < m; i++)
            {
                if ((a * i) % m == 1)
                    return i;
            }
            return null;
        }

        public static string Encrypt(string text, int a, int b)
        {
            var encryptedText = "";
            foreach (var symbol in text)
            {
                if (char.IsLetter(symbol))
                {
                    if (char.IsUpper(symbol))
                    {
                        var encryptedChar = (char)((a * (symbol - 'А') + b) % 32 + 'А');
                        encryptedText += encryptedChar;
                    }
                    else if (char.IsLower(symbol))
                    {
                        var encryptedChar = (char)((a * (symbol - 'а') + b) % 32 + 'а');
                        encryptedText += encryptedChar;
                    }
                }
                else
                    encryptedText += symbol;
            }
            return encryptedText;
        }

        public static string Decrypt(string text, int a, int b)
        {
            var inverseA = ModInverse(a, 32);
            if (inverseA == null)
            {
                Console.WriteLine("Невозможно выполнить расшифровку: коэффициент 'a' не имеет обратного элемента по модулю 32.");
                return null;
            }

            var decryptedText = string.Empty;
            foreach (var symbol in text)
            {
                if (char.IsLetter(symbol))
                {
                    if (char.IsUpper(symbol))
                    {
                        var decryptedChar = (char)((inverseA * (symbol + 'А' - b)) % 32 + 'А');
                        decryptedText += decryptedChar;
                    }
                    else if (char.IsLower(symbol))
                    {
                        var decryptedChar = (char)((inverseA * (symbol + 'а' - b)) % 32 + 'а');
                        decryptedText += decryptedChar;
                    }
                }
                else
                    decryptedText += symbol;
            }
            return decryptedText;
        }
    }
}