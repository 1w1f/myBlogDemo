using System.Text;
using System.Security.Cryptography;
using System;

namespace myBlogDemo.Utility.Common
{
    public class Md5Helper
    {
        public static string Md5Encrypt(string value)
        {
            var mD5 = MD5.Create();
            var encruptByteArray = mD5.ComputeHash(Encoding.UTF8.GetBytes(value));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < encruptByteArray.Length; i++)
            {
                sBuilder.Append(encruptByteArray[i].ToString("x2"));
            }
            return sBuilder.ToString().ToLower();
        }
    }
}
