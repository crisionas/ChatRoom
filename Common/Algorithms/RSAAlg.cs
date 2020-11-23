using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Common.Algorithms
{
    public static class RSAAlg
    {
        static UnicodeEncoding ByteConverter = new UnicodeEncoding();


        //static public string Encryption(string InputText)
        //{ 
        //    byte[] Data;
        //    bool DoOAEPPadding = false;
        //    try
        //    {
        //        Data = Encoding.UTF8.GetBytes(InputText);

        //        byte[] encryptedData;
        //        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
        //        {
        //            RSA.ImportParameters(RSAKey.ExportParameters(false));
        //            encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
        //        }
        //        return Convert.ToBase64String(encryptedData);
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //static public string Decryption(string inputString)
        //{

        //    bool DoOAEPPadding = false;
        //    byte[] Data= Convert.FromBase64String(inputString);
        //    try
        //    {
        //        byte[] decryptedData;
        //        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
        //        {
        //            RSA.ImportParameters(RSAKey.ExportParameters(true));
        //            decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
        //        }
        //        return Convert.ToBase64String(decryptedData);
        //    }
        //    catch(Exception ex)
        //    {
        //        return null;
        //    }
        //}

        public static string Encryption(string inputString)
        {
            var privateKey = "<RSAKeyValue><Modulus>pKXxYax+fqPIgnQx6+tdToW+fJT9gJuJCBvm0glUNFSLxsdJxlpa2OYSaqpC5DKoZjZUYzMNv+d5TpEap3cfvvYuZU6C4+9RRZuCmnrnsXEqv871Qz25KZIQiVD4fW0bmKqZQCo0zUzUtRSIi/qHFIePamwmWBft+39jKklXRXVTAuTN3ghJG4h8XBRt1pYjQa6oXKV2mM7LX3SFht8D6Ju1A5cGaVYg335RjGXJpdBEpIoVscbOZb1u/yVxZMiVxomXY0OLwOAv3isM5dX7+XnPunn/NEBTMXSIG1zgKZeHlbGqo52/oETW4y/CTHNMudEjIuEUFy3e6wGUGMiTKQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"; 
                byte[] Data = ByteConverter.GetBytes(inputString);
            bool DoOAEPPadding = true;
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.FromXmlString(privateKey);
                    encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }
                return ByteConverter.GetString(encryptedData);
            }
            catch (CryptographicException e)
            {
                return null;
            }
        }

        public static string Decryption(string inputString)
        {
            var publicKey = "<RSAKeyValue><Modulus>pKXxYax+fqPIgnQx6+tdToW+fJT9gJuJCBvm0glUNFSLxsdJxlpa2OYSaqpC5DKoZjZUYzMNv+d5TpEap3cfvvYuZU6C4+9RRZuCmnrnsXEqv871Qz25KZIQiVD4fW0bmKqZQCo0zUzUtRSIi/qHFIePamwmWBft+39jKklXRXVTAuTN3ghJG4h8XBRt1pYjQa6oXKV2mM7LX3SFht8D6Ju1A5cGaVYg335RjGXJpdBEpIoVscbOZb1u/yVxZMiVxomXY0OLwOAv3isM5dX7+XnPunn/NEBTMXSIG1zgKZeHlbGqo52/oETW4y/CTHNMudEjIuEUFy3e6wGUGMiTKQ==</Modulus><Exponent>AQAB</Exponent><P>xlyc2wMty8rIZ4HDBBFxU4KZra2Rc4ihVK3uzgIa4w9QaL7xGO6flcieSqd0osHwFIwEzxEB8kFlEgKzebYG9NPS+waI7g9JWEtKnvxK+dplpRXKkRFVU4DdJlrQe3RczbsuL2H/za4+apFJpi0e68lAJQ5oY1P21TVjckAy4D8=</P><Q>1H2BZgPY6SpTpCSewTQRg41tJEqqetM9zLkAZKMlLvmB4zq/Ah6hECJf/A7JbuZXdPXwKYdAB9v3+6ZxJ5Kw5IlDAdq/KTzN5ZgWRDsrekxCq0Phe5zNpwjjAGlevROWRWjdFi/jV6XcL5sflmunGN3N4k/uwYznSoy5YJaGMpc=</Q><DP>skOuz4CW2ovd+G98ZB6M2wEGvTe7/LlwS1qYv1jS8vXjTI80uzRQBNsrrmm5fz+NU9nVxIVDW4R7oWj+BEabD9GBzQi9bDwerRPU9vZDJzGnoWnpBuAt74JivMJmlFwpvtYWFo0ax6xs+XaiWo44OKw/Uk4VcBaYQFnfimC5mB8=</DP><DQ>LiuXEjODziYERoYueIx3wb3ZGSmgIVAE/Za1HyjTy4ErV9RL7In7NSZC9OHBovcpyaAmrt9UamDBYUypCZA2H3IzvRNqtesgUeLZ87lnmQs48T2uoM1RYhnsOQqsKyk2XZ6La2a8Xy8KyM1L78M0a5LGSYZUunmDSA+LuBD818E=</DQ><InverseQ>BmjbVTp4DG7yMXM1QRGGqvxHlzvUIaRwn08s09g3LGu6lftwxwKnNbBZzt8eZJlqRC9cSyTHYibxJ09+M4H5/i/iaMyUnbtVqQOwvBFaepJi/Rq08RqKyi0oCkKaXx5SOEll3RGuLrbTHOgxrmTTd5ZOYc65rXUFSphx3ErO4Ew=</InverseQ><D>e7huP3T8wHCWFOD3Ok3sGTsKvla+fsthFwTQV3fHHGODfOT3nOL8bQvFPv2dshgWzmd41enhJRjs4IrMupYa9sXKazmpxVlpeqK2axp7y6w78VG0nshcwM4POv/rGWTJXdiju8F7V+Gp3EAHsxeYNWb/73pA/eVNYLSCcZ4WxAuGkK1R26ZGCvFlaENNw2X61T1HLsDWLOPyltqoQv3Kxtxz34rzxIgnkl48xlumOA9sfzoJWcmkMpapzZRizRQOYDcMHSw0gCUXH9qVo4AJcfMWgkl/OiQHIE2872NRGXeYQGZGgCH2G9GJOdbHVRKam+6ciP0VEXyvKi1qwxce2Q==</D></RSAKeyValue>";
                byte[] Data = ByteConverter.GetBytes(inputString);
            bool DoOAEPPadding = false;
            try
            {
                
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.FromXmlString(publicKey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                }
                return ByteConverter.GetString(decryptedData);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
