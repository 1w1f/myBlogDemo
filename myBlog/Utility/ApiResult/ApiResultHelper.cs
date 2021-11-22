using System;
using SqlSugar;

namespace myBlogDemo.Utility.ApiResult
{
    public static class ApiResultHelper
    {
        public static ApiResult Success(Object data)
        {
            return new ApiResult
            {
                Code = 200,
                Data = data,
                Msg = "请求成功",
                Total = 0,
            };
        }

        public static ApiResult Success(object data, RefAsync<int> total)
        {
            return new ApiResult
            {
                Code = 200,
                Data = data,
                Msg = "请求成功",
                Total = total,
            };
        }

        public static ApiResult Error(string msg)
        {

            return new ApiResult
            {
                Code = 200,
                Data = null,
                Msg = msg,
                Total = 0
            };
        }
    }
}
