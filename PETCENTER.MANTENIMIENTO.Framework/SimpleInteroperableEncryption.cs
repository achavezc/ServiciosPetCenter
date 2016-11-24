using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.Framework
{
    public class SimpleInteroperableEncryption
    {

        private string salt { get; set; }

        private byte[] passWord = Constantes.key; //"p@$$W0rDC0RP0R4C10NS3rv1c10sGR"; 

        public SimpleInteroperableEncryption(string ClavePublica)
        {
            this.salt = ClavePublica;
        }

        public string Encrypt(string raw)
        {
            if (String.IsNullOrEmpty(this.salt))
                throw new Exception("SALT debe tener un valor");
            using (var csp = new AesCryptoServiceProvider())
            {
                ICryptoTransform e = GetCryptoTransform(csp, true);
                byte[] inputBuffer = Encoding.UTF8.GetBytes(raw);
                byte[] output = e.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);

                string encrypted = Convert.ToBase64String(output);

                return encrypted;
            }
        }

        public string Decrypt(string encrypted)
        {
            if (String.IsNullOrEmpty(this.salt))
                throw new Exception("SALT debe tener un valor");
            using (var csp = new AesCryptoServiceProvider())
            {
                var d = GetCryptoTransform(csp, false);
                byte[] output = Convert.FromBase64String(encrypted);
                byte[] decryptedOutput = d.TransformFinalBlock(output, 0, output.Length);

                string decypted = Encoding.UTF8.GetString(decryptedOutput);
                return decypted;
            }
        }

        private ICryptoTransform GetCryptoTransform(AesCryptoServiceProvider csp, bool encrypting)
        {
            csp.Mode = CipherMode.CBC;
            csp.Padding = PaddingMode.PKCS7;


            //a random Init. Vector. just for testing
            String iv = "e675f725e675f725";
            int iteraciones = 65536;
            byte[] pw = passWord;//Encoding.UTF8.GetBytes(passWord);
            var spec = new Rfc2898DeriveBytes(pw, Encoding.UTF8.GetBytes(salt), iteraciones);
            byte[] key = spec.GetBytes(16);


            csp.IV = Encoding.UTF8.GetBytes(iv);
            csp.Key = key;
            if (encrypting)
            {
                return csp.CreateEncryptor();
            }
            return csp.CreateDecryptor();
        }

    }

    internal static class Constantes
    {
        internal static byte[] key = new Byte[] { 112, 64, 36, 36, 87, 48, 114, 68, 67, 48, 82, 80, 48, 82, 52, 67, 49, 48, 78, 83, 51, 114, 118, 49, 99, 49, 48, 115, 71, 82 };//"p@$$W0rDC0RP0R4C10NS3rv1c10sGR";
    }

}
