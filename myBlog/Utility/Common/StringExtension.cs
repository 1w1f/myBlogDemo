using System;

namespace myBlogDemo.Utility.Common
{
    public static class StringExtension
    {
        public static bool IsNotNullOrEmpty(this string value){
            return !string.IsNullOrEmpty(value);
        }
    }
}
