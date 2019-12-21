using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HT.Framework.DotNetFx40.Encrypt.DESEncrypt
{
    public static class DESHelper
    {
        /// <summary>
        /// DES 加密
        /// </summary>
        /// <param name="Data"> 待加密的字符串 </param>
        /// <param name="Key"> 密钥（8位） </param>
        /// <returns></returns>
        public static string DesEncrypt(string Data, string Key)
        {
            byte[] KeyBytes = Encoding.UTF8.GetBytes(Key.Substring(0, 8));
            byte[] IVBytes = { 0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF };
            byte[] DataBytes = Encoding.UTF8.GetBytes(Data);

            try
            {
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(KeyBytes, IVBytes), CryptoStreamMode.Write);
                cryptoStream.Write(DataBytes, 0, DataBytes.Length);
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(memoryStream.ToArray());
            }
            catch
            {
                 return string.Empty;
            }
        }

        /// <summary>
        /// DES 解密
        /// </summary>
        /// <param name="Data"> 待解密的字符串 </param>
        /// <param name="Key"> 密钥（8位） </param>
        /// <returns></returns>
        public static string DesDecrypt(string Data, string Key)
        {
            byte[] KeyBytes = Encoding.UTF8.GetBytes(Key.Substring(0, 8));
            byte[] IVBytes = { 0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF };
            byte[] DataBytes = new byte[Data.Length];

            try
            {
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                DataBytes = Convert.FromBase64String(Data);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(KeyBytes, IVBytes), CryptoStreamMode.Write);
                cryptoStream.Write(DataBytes, 0, DataBytes.Length);
                // 如果两次密匙不一样，这一步可能会引发异常
                cryptoStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}