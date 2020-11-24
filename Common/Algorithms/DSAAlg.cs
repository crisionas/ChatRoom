using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Common.Algorithms
{
    public static class DSAAlg
    {
        public static string connectionKey { get; set; }
        public static string Hash(string text)
        {
            try
            {
                byte[] Hash = Sha1Hash(text);
                DSACryptoServiceProvider dsa = new DSACryptoServiceProvider();

                DSASignatureFormatter dSASignatureFormatter = new DSASignatureFormatter(dsa);

                dSASignatureFormatter.SetHashAlgorithm("SHA1");
                byte[] SignedHash = dSASignatureFormatter.CreateSignature(Hash);
                string sign = Convert.ToBase64String(SignedHash);
                DSASignatureDeformatter dSASignatureDeformatter = new DSASignatureDeformatter(dsa);
                if (dSASignatureDeformatter.VerifySignature(Hash, SignedHash))
                {
                    return sign;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error! During DSA Hash siganture generation.");
            }
        }

        public static byte[] Sha1Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
                return hash;
            }
        }

    }
}
