using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace file_integrity_checker
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceHash = CreateHash(@"HotelCalifornia.txt");
            Console.WriteLine($"Source File Hash:\n{sourceHash}\n");

            var sourceSecureHash = CreateSecureHash(@"HotelCalifornia.txt");
            Console.WriteLine($"Source File Secure Hash:\n{sourceSecureHash}\n");

            var sameHash = CreateHash(@"HotelCalifornia_Same.txt");
            Console.WriteLine($"Same File Hash:\n{sameHash}\n");

            var sameSecureHash = CreateSecureHash(@"HotelCalifornia_Same.txt");
            Console.WriteLine($"Same File Secure Hash:\n{sameSecureHash}\n");

            var diffHash = CreateHash(@"HotelCalifornia_Diff.txt");
            Console.WriteLine($"Diff File Hash:\n{diffHash}\n");

            var diffSecureHash = CreateSecureHash(@"HotelCalifornia_Diff.txt");
            Console.WriteLine($"Diff File Secure Hash:\n{diffSecureHash}\n");
            Console.ReadLine();
        }

        static string CreateHash(string filePath)
        {
            using (FileStream fs = File.OpenRead(filePath))
            using (HashAlgorithm hashAlgorithm = SHA1.Create())
            {
                byte[] hash = hashAlgorithm.ComputeHash(fs);
                StringBuilder sb = new StringBuilder();

                foreach (byte b in hash)
                    sb.Append(b.ToString("x2").ToLower());

                return sb.ToString();
            }
        }

        static string CreateSecureHash(string filePath)
        {
            using (FileStream fs = File.OpenRead(filePath))
            using (HashAlgorithm hashAlgorithm = SHA512.Create())
            {
                byte[] hash = hashAlgorithm.ComputeHash(fs);
                StringBuilder sb = new StringBuilder();

                foreach (byte b in hash)
                    sb.Append(b.ToString("x2").ToLower());

                return sb.ToString();
            }
        }
    }
}
