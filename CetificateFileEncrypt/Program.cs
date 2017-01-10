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
            Encrypt(@"C:\Users\Linko\Downloads\20151103.CERTM\CERTM\mvolariscom.pfx", "0s1a0t2pra$V", "M2JUAREZ/BENITO        S4VS4C ORDMEXY4 0935 324Y020D0001 147>1181 M5324BY4 000000000000029036073737373701                          S4VS4C MEXGDLY4 0744 324Y029C0001 12B29036073737373700                          ");

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
                        var result = ecdsa.SignData(data, HashAlgorithmName.SHA256);
                        var sign = Convert.ToBase64String(result);
                        encoded = text + "^1" + sign.Length.ToString("X") + sign;

                        var verify = ecdsa.VerifyData(data, result, HashAlgorithmName.SHA256);
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
