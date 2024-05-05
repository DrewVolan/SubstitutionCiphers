namespace SubstitutionCiphers.Ciphers
{
    public static class SimpleReplacementCipher
    {
        public static string Encrypt(string text, int shift)
        {
            var encryptedText = string.Empty;
            foreach (var symbol in text)
            {
                var shifted = symbol;
                if (char.IsLetter(symbol))
                    shifted = (char)(symbol + shift);

                if (char.IsLower(symbol))
                {
                    if (shifted > 'я')
                        shifted = (char)(shifted - 32);
                    else if (shifted < 'а')
                        shifted = (char)(shifted + 32);
                }
                else if (char.IsUpper(symbol))
                {
                    if (shifted > 'Я')
                        shifted = (char)(shifted - 32);
                    else if (shifted < 'А')
                        shifted = (char)(shifted + 32);
                }

                encryptedText += shifted;
            }
            return encryptedText;
        }

        public static string Decrypt(string text, int shift)
        {
            return Encrypt(text, -shift);
        }   
    }
}