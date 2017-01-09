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
            Encrypt(@"C:\Users\Linko\Google Drive\SISA_Web\Documents\Cifrado\CERTM\20161016.CERTM\mvolariscom.pfx", "0s1a0t2pra$V", "M1SALAZARCONTRERAS/MAR W9CJJW MDWDGOY4 0945 306Y010A0025 347>1181  6306BY4 0036982232001290360G2001516701                          ");
            Encrypt(@"C:\Users\Linko\Google Drive\SISA_Web\Documents\Cifrado\CERTM\CERTM\mvolariscom.pfx", "0s1a0t2pra$V", "M1SALAZARCONTRERAS/MAR W9CJJW MDWDGOY4 0945 306Y010A0025 347>1181  6306BY4 0036982232001290360G2001516701                          ");

            Console.ReadLine();
        }

        /// <summary>
        /// Encrypts the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="password">The password.</param>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        private static string Encrypt(string path, string password, string text)
        {
            var encoded = string.Empty;
            var cert = new X509Certificate2();
            var byteConverter = new ASCIIEncoding();
            var collection = new X509Certificate2Collection();

            try
            {
                var data = byteConverter.GetBytes(text);
                collection.Import(path, password, X509KeyStorageFlags.PersistKeySet);
                cert = collection[0];

                using (ECDsa ecdsa = cert.GetECDsaPrivateKey())
                {
                    if (ecdsa != null)
                    {
                        encoded = Convert.ToBase64String(ecdsa.SignData(data, HashAlgorithmName.SHA256));
                    }
                    else
                    {
                        var publicKey = cert.PublicKey.Key as RSACryptoServiceProvider;
                        var encryptedBytes = new byte[0];
                        encryptedBytes = publicKey.Encrypt(data, false);
                        encoded = Convert.ToBase64String(encryptedBytes);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return encoded;
        }
    }
}
