using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.X509;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CetificateFileEncrypt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ReadPFXwithBouncyCastle();

            Console.ReadLine();
        }

        /// <summary>
        /// Reads the pf xwith bouncy castle.
        /// </summary>
        private static void ReadPFXwithBouncyCastle()
        {
            var path = @"C:\Users\Linko\Google Drive\SISA_Web\Documents\Cifrado\CERTM\CERTM\mvolariscom.pfx";
            var password = "0s1a0t2pra$V";

            //var collection = new X509Certificate2Collection();

            //collection.Import(path, password, X509KeyStorageFlags.PersistKeySet);

            //var certificate = collection[0];

            //var publicKey = certificate.PublicKey.Key as RSACryptoServiceProvider;

            //var plaintextMessage = Encoding.UTF8.GetBytes("Hola mundo");

            //var encryptedData = publicKey.Encrypt(plaintextMessage, false);

        }
    }
}
