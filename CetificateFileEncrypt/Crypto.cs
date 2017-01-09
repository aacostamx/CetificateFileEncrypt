using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CetificateFileEncrypt
{
    static public class Crypto {    

    public static string Encrypt(string textToEncrypt) {
        string certPath = @"C:\Users\Linko\Google Drive\SISA_Web\Documents\Cifrado\CERTM\20161016.CERTM\mvolariscom.pfx";
        string certPass = "0s1a0t2pra$V";

        // Create a collection object and populate it using the PFX file
        X509Certificate2Collection collection = new X509Certificate2Collection();
        collection.Import(certPath, certPass, X509KeyStorageFlags.PersistKeySet);

        X509Certificate2 myCert = new X509Certificate2();
        foreach (X509Certificate2 cert in collection)
        {
            Console.WriteLine("Subject is: '{0}'", cert.Subject);
            Console.WriteLine("Issuer is:  '{0}'", cert.Issuer);
            myCert = cert;
            // Import the certificate into an X509Store object
        }

        ASCIIEncoding byteConverter = new ASCIIEncoding();
        byte[] encodedBytes = byteConverter.GetBytes("M1SALAZARCONTRERAS/MAR W9CJJW MDWDGOY4 0945 306Y010A0025 347>1181  6306BY4 0036982232001290360G2001516701                          ");

        RSACryptoServiceProvider rsa = myCert.PublicKey.Key as RSACryptoServiceProvider;
        byte[] encryptedBytes;
        encryptedBytes = rsa.Encrypt(encodedBytes, false);

        string encodedString = Convert.ToBase64String(encryptedBytes);

        return encodedString;
    }

   

   } //End of class Crypto
}
