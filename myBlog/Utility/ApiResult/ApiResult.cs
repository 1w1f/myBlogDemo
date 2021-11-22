using System;

namespace myBlogDemo.Utility.ApiResult
{
    public class ApiResult
    {
        public int Code { get; set; }
        public string  Msg { get; set; }
        public Object Data { get; set; }
        public int Total { get; set; }
    }
}
