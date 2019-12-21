using System;
using System.Security.Cryptography;

namespace HT.Framework.DotNetFx40.Encrypt.SHAEncrypt
{
    public static class SHAHelper
    {

        /// <summary>
        /// SHA1
        /// </summary>
        /// <param name="palinData">明文</param>
        /// <param name="encodingType">编码方式</param>
        /// <returns>string：密文</returns>
        public static string Sha1(string palinData, EncodingStrOrByte.EncodingType encodingType = EncodingStrOrByte.EncodingType.UTF8)
        {
            if (string.IsNullOrWhiteSpace(palinData)) return null;
            using (SHA1 sha1 = new SHA1CryptoServiceProvider())
            {
                byte[] bytes = EncodingStrOrByte.GetBytes(palinData, encodingType);
                byte[] sha1Bytes = sha1.ComputeHash(bytes);
                return Convert.ToBase64String(sha1Bytes);
            }
        }

        /// <summary>
        /// SHA256
        /// </summary>
        /// <param name="palinData">明文</param>
        /// <param name="encodingType">编码方式</param>
        /// <returns>string：密文</returns>
        public static string Sha256(string palinData, EncodingStrOrByte.EncodingType encodingType = EncodingStrOrByte.EncodingType.UTF8)
        {
            if (string.IsNullOrWhiteSpace(palinData)) return null;
            using (SHA256 sha256 = new SHA256CryptoServiceProvider())
            {
                byte[] bytes = EncodingStrOrByte.GetBytes(palinData, encodingType);
                byte[] sha256Bytes = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(sha256Bytes);
            }
        }

        /// <summary>
        /// SHA384
        /// </summary>
        /// <param name="palinData">明文</param>
        /// <param name="encodingType">编码方式</param>
        /// <returns>string：密文</returns>
        public static string Sha384(string palinData, EncodingStrOrByte.EncodingType encodingType = EncodingStrOrByte.EncodingType.UTF8)
        {
            if (string.IsNullOrWhiteSpace(palinData)) return null;
            using (SHA384 sha384 = new SHA384CryptoServiceProvider())
            {
                byte[] bytes = EncodingStrOrByte.GetBytes(palinData, encodingType);
                byte[] sha384Bytes = sha384.ComputeHash(bytes);
                return Convert.ToBase64String(sha384Bytes);
            }
        }

        /// <summary>
        /// SHA512
        /// </summary>
        /// <param name="palinData">明文</param>
        /// <param name="encodingType">编码方式</param>
        /// <returns>string：密文</returns>
        public static string Sha512(string palinData, EncodingStrOrByte.EncodingType encodingType = EncodingStrOrByte.EncodingType.UTF8)
        {
            if (string.IsNullOrWhiteSpace(palinData)) return null;
            using (SHA512 sha512 = new SHA512CryptoServiceProvider())
            {
                byte[] bytes = EncodingStrOrByte.GetBytes(palinData, encodingType);
                byte[] sha512Bytes = sha512.ComputeHash(bytes);
                return Convert.ToBase64String(sha512Bytes);
            }
        }
    }
}