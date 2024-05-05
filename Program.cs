using System;
using SubstitutionCiphers.Ciphers;

namespace SubstitutionCiphers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                byte cipherType = 0;
                do
                {
                    Console.Write("Введите 1 - шифр простой замены; 2 - аффинный шифр; 3 - аффинный рекурентный шифр: ");
                    byte.TryParse(Console.ReadLine(), out cipherType);
                } while (cipherType < 1 || cipherType > 3);

                switch (cipherType)
                {
                    case 1:
                        Console.Write("Введите текст для шифрования: ");
                        var text1 = Console.ReadLine();
                        Console.Write("Введите смещение любое число (при вводе нечисла произойдёт возврат в начало): ");
                        var shift1 = 0;
                        if (int.TryParse(Console.ReadLine(), out shift1))
                        {
                            var encryptedText1 = SimpleReplacementCipher.Encrypt(text1, shift1);
                            Console.WriteLine($"Зашифрованный текст: {encryptedText1}");
                            Console.WriteLine($"Расшифрованный текст: {SimpleReplacementCipher.Decrypt(encryptedText1, shift1)}");
                        }
                        break;
                    case 2:
                        Console.Write("Введите текст для шифрования: ");
                        var text2 = Console.ReadLine();
                        Console.Write("Введите значение коэффициента a (при вводе нечисла произойдёт возврат в начало): ");
                        var a2 = 0;
                        if (!int.TryParse(Console.ReadLine(), out a2))
                        {
                            Console.WriteLine("Коэффициент a должен быть числом. Возврат в начало.");
                            break;
                        }
                        Console.Write("Введите значение коэффициента b (при вводе нечисла произойдёт возврат в начало): ");
                        var b2 = 0;
                        if (!int.TryParse(Console.ReadLine(), out b2))
                        {
                            Console.WriteLine("Коэффициент b должен быть числом. Возврат в начало.");
                            break;
                        }
                        var encryptedText2 = AffineCipher.Encrypt(text2, a2, b2);
                        Console.WriteLine($"Зашифрованный текст: {encryptedText2}");
                        Console.WriteLine($"Расшифрованный текст: {AffineCipher.Decrypt(encryptedText2, a2, b2)}");
                        break;
                    case 3:
                        Console.Write("Введите текст для шифрования: ");
                        var text3 = Console.ReadLine();
                        Console.Write("Введите значение коэффициента a (при вводе нечисла произойдёт возврат в начало): ");
                        var a3 = 0;
                        if (!int.TryParse(Console.ReadLine(), out a3))
                        {
                            Console.WriteLine("Коэффициент a должен быть числом. Возврат в начало.");
                            break;
                        }
                        Console.Write("Введите значение коэффициента b (при вводе нечисла произойдёт возврат в начало): ");
                        var b3 = 0;
                        if (!int.TryParse(Console.ReadLine(), out b3))
                        {
                            Console.WriteLine("Коэффициент b должен быть числом. Возврат в начало.");
                            break;
                        }
                        var encryptedText3 = AffineRecurrentCipher.Encrypt(text3, a3, b3);
                        Console.WriteLine($"Зашифрованный текст: {encryptedText3}");
                        Console.WriteLine($"Расшифрованный текст: {AffineRecurrentCipher.Decrypt(encryptedText3, a3, b3)}");
                        break;
                }
            } while (true);
        }
    }
}