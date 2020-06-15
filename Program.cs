using System;
using System.Text;
using System.Security.Cryptography;
using System.Linq;
namespace tstenv1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test hash");
            FN();
        }

        public static void FN()
        {
            byte[] data = { 1, 2, 3, 0, 5, 6 };
            Guid guid = Guid.NewGuid();
            byte[] guidInBayts = Encoding.UTF8.GetBytes(guid.ToString());
            byte[] fulldata = Combine(data, guidInBayts); 
            SHA256CryptoServiceProvider sha = new SHA256CryptoServiceProvider();
            sha.ComputeHash(fulldata);
            Console.WriteLine("Hashed Data:    " + BitConverter.ToString(sha.Hash));
            System.Console.WriteLine("Guid: " + guid.ToString());
        }
        public static byte[] Combine(byte[] first, byte[] second)
        {
             
            byte[] bytes = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, bytes, 0, first.Length);
            Buffer.BlockCopy(second, 0, bytes, first.Length, second.Length);
            return bytes;
        }

    }
}
