using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web.Security;
using System.Security;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
namespace JSOA.Common
{
    /// <summary>
    /// 加密类
    /// </summary>
    public class Encrypt
    {
        //密钥
        //private static string sKey = "EFD8524DF2174C17909F26A1AD18DCC1";
        private static string sKey1 = "A3F2569E6SJEAWBCJOTY45DYQWF88H1Y";
        //矢量，矢量可以为空
        private static string sIV = "qdCy6X+aKLw=";
        //private static string iv = "023e5JK89UT2/450";

        #region ECB加密、解密
        /// <summary>
        /// 加密（可用在Cookie的加密）
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string EncryptString(string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                SymmetricAlgorithm mCSP = new TripleDESCryptoServiceProvider();
                ICryptoTransform ct;
                MemoryStream ms;
                CryptoStream cs;
                byte[] byt;
                mCSP.Key = Convert.FromBase64String(sKey1);
                mCSP.IV = Convert.FromBase64String(sIV);
                //指定加密的运算模式
                mCSP.Mode = System.Security.Cryptography.CipherMode.ECB;
                //获取或设置加密算法的填充模式
                mCSP.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                ct = mCSP.CreateEncryptor(mCSP.Key, mCSP.IV);
                byt = Encoding.UTF8.GetBytes(value);
                ms = new MemoryStream();
                cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
                cs.Write(byt, 0, byt.Length);
                cs.FlushFinalBlock();
                cs.Close();
                return Convert.ToBase64String(ms.ToArray());
            }
            else
            {
                return "";
            }
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Source"></param>
        /// <returns></returns>
        public static string DecrypString(string source)
        {
            if (!String.IsNullOrEmpty(source))
            {
                try
                {
                    SymmetricAlgorithm mCSP = new TripleDESCryptoServiceProvider();
                    byte[] bytIn = Convert.FromBase64String(source);
                    MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);
                    mCSP.Mode = System.Security.Cryptography.CipherMode.ECB;
                    //获取或设置加密算法的填充模式
                    mCSP.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                    mCSP.Key = Convert.FromBase64String(sKey1);
                    mCSP.IV = Convert.FromBase64String(sIV);
                    ICryptoTransform encrypto = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV);
                    CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
                    StreamReader sr = new StreamReader(cs);
                    return sr.ReadToEnd();
                }
                catch
                {
                    return "";
                }
            }
            else
            {
                return "";

            }
        }
        #endregion



        #region MD5加密
        /// <summary>
        /// MD5加密(只用在密码加密)
        /// </summary>
        /// <param name="str">要加密的串</param>
        /// <param name="code">16 16位加密,32 32位加密</param>
        /// <returns></returns>
        public static string MD5(string str, int code)
        {
            str = str.ToLower();
            if (code == 16) //16位MD5加密（取32位加密的9~25字符） 
            {
                return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower().Substring(8, 16);
            }

            if (code == 32) //32位加密 
            {
                return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
            }

            return "00000000000000000000000000000000";
        }

        #endregion


        #region ========加密========

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Encrypts(string Text)
        {
            return Encrypts(Text, "none");
        }
        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Encrypts(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(Text);
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        #endregion

        #region ========解密========


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Decrypt(string Text)
        {
            return Decrypt(Text, "none");
        }
        /// <summary> 
        /// 解密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Decrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = Text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }

        #endregion

    }
}
