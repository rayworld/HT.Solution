using System;
using System.Security.Cryptography;
using System.Text;

namespace HT.Framework.DotNetFx40.Encrypt
{
    public static class RSAEncryptHelper
    {
        /// <summary>
        /// 生成 RSA 公钥和私钥
        /// </summary>
        /// <param name="publicKey"> 公钥 </param>
        /// <param name="privateKey"> 私钥 </param>
        public static void GenerateRsaKeys(out string publicKey, out string privateKey)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                publicKey = rsa.ToXmlString(false);
                privateKey = rsa.ToXmlString(true);
            }
        }

        /// <summary>
        /// RSA 加密
        /// </summary>
        /// <param name="publickey"> 公钥 </param>
        /// <param name="content"> 待加密的内容 </param>
        /// <returns> 经过加密的字符串 </returns>
        public static string RsaEncrypt(string publickey, string content)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publickey);
            var cipherbytes = rsa.Encrypt(Encoding.UTF8.GetBytes(content), false);

            return Convert.ToBase64String(cipherbytes);
        }

        /// <summary>
        /// RSA 解密
        /// </summary>
        /// <param name="privatekey"> 私钥 </param>
        /// <param name="content"> 待解密的内容 </param>
        /// <returns> 解密后的字符串 </returns>
        public static string RsaDecrypt(string privatekey, string content)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privatekey);
            var cipherbytes = rsa.Decrypt(Convert.FromBase64String(content), false);

            return Encoding.UTF8.GetString(cipherbytes);
        }

    }
}
