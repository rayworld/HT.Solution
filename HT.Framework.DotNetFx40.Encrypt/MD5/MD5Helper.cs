
using System;
using System.Text;
using System.Security.Cryptography;

namespace HT.Framework.DotNetFx40.Encrypt.MD5Encrypt
{
    /// <summary>
    /// MD5加密
    /// MD5全称是message-digest algorithm 5，单向的加密，无法根据密文推导出明文。
    /// 应用：签名，文件校验
    /// </summary>
    public static class MD5Helper
    {
        #region 枚举参数
        /// <summary>
        /// 是否转化大小写
        /// </summary>
        public enum IsUpper { ToUpper, ToLower };
        /// <summary>
        /// 密文长度
        /// </summary>
        public enum EncryptLength { I16, I32 };
        #endregion

        #region 加密方法
        /// <summary>
                /// MD5加密技术-【ToBase64|24】
                /// </summary>
                /// <param name="palinData">明文</param>
                /// <param name="encodingType">编码方式</param>
                /// <returns>string：密文</returns>
        public static string EncryptToBase64(string palinData, EncodingStrOrByte.EncodingType encodingType = EncodingStrOrByte.EncodingType.UTF8, IsUpper isUpper = IsUpper.ToLower)
        {
            if (string.IsNullOrWhiteSpace(palinData)) return null;
            MD5 md5 = new MD5CryptoServiceProvider(); //实例化一个md5对像
            byte[] bytes = EncodingStrOrByte.GetBytes(palinData, encodingType); //将要加密的字符串转换为指定编码的字节数组
            byte[] hashVal = md5.ComputeHash(bytes);//将字符串加密后也转换为字符数组
            string encryptData = string.Empty; //密文
            switch (isUpper)
            {
                //将加密后的字节数组转换为base64编码加密字符串
                case IsUpper.ToUpper:
                    encryptData = Convert.ToBase64String(hashVal).ToUpper();
                    break;
                case IsUpper.ToLower:
                    encryptData = Convert.ToBase64String(hashVal).ToLower();
                    break;
            }
            return encryptData;
        }

        /// <summary>
                /// MD5加密技术-【16|32】
                /// </summary>
                /// <param name="palinData">明文</param>
                /// <param name="encodingType">编码方式</param>
                /// <param name="encryptLength">密文长度</param>
                /// <param name="isUpper">是否转化大小写</param>
                /// <returns>string：密文</returns>
        public static string Encrypt(string palinData, EncodingStrOrByte.EncodingType encodingType = EncodingStrOrByte.EncodingType.UTF8, EncryptLength encryptLength = EncryptLength.I32, IsUpper isUpper = IsUpper.ToLower)
        {
            if (string.IsNullOrWhiteSpace(palinData)) return null;
            MD5 md5 = MD5.Create();//实例化一个md5对像
            byte[] bytes = EncodingStrOrByte.GetBytes(palinData, encodingType); //将要加密的字符串转换为指定编码的字节数组
            byte[] hashVal = md5.ComputeHash(bytes);//将字符串加密后也转换为字符数组
            StringBuilder sb = new StringBuilder();
            switch (encryptLength)
            {
                case EncryptLength.I16:
                    for (int i = 4; i < 12; i++)
                    {
                        sb.Append(hashVal[i].ToString("x2")); //16进制小写字符串，说明（x：小写字符串，X：大写字符串）
                    }
                    break;
                case EncryptLength.I32:
                    for (int i = 0; i < 16; i++)
                    {
                        sb.Append(hashVal[i].ToString("x2"));
                    }
                    break;
            }

            string encryptData = string.Empty; //密文
            switch (isUpper)
            {
                case IsUpper.ToUpper:
                    encryptData = sb.ToString().ToUpper();
                    break;
                case IsUpper.ToLower:
                    encryptData = sb.ToString().ToLower();
                    break;
            }
            return encryptData;
        }
        #endregion
    }
}