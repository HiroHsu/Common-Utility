

using System;
using System.Security.Cryptography;
using System.Text;

namespace Common.Utility.Cryptography
{
    public static class Crypto
    {
        /// <summary>
        /// 將一字串編碼成MD5
        /// </summary>
        /// <param name="str">字串</param>
        /// <returns>編碼後的MD5字串</returns>
        public static string MD5Hash(this string str)
        {
            var md5 = MD5.Create();//建立一個MD5
            byte[] source = Encoding.Default.GetBytes(str);//將字串轉為Byte[]
            byte[] crypto = md5.ComputeHash(source);//進行MD5加密
            StringBuilder hash = new StringBuilder();
            for (int i = 0; i < crypto.Length; i++)
            {
                hash.Append(crypto[i].ToString("x2"));//把加密後的字串從Byte[]轉為字串
            }
            return hash.ToString();

        }
    }
}
