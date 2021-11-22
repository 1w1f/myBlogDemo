using System.Threading;
using System;
using System.Threading.Tasks;
using Iservice;
using Microsoft.AspNetCore.Mvc;
using myBlogDemo.Utility.ApiResult;
using Service;
using MyModel.Model;

namespace myBlogDemo.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BlogNewsController : ControllerBase
    {
        private readonly IBlogNewsService _iBlogNewsService;

        public BlogNewsController(IBlogNewsService iBlogNewsService)
        {
            _iBlogNewsService = iBlogNewsService;
        }




        [HttpGet("BlogNews")]
        public async Task<ActionResult<ApiResult>> GetBlogNews()
        {
            var data = await _iBlogNewsService.QueryAsync();
            if (data.Count <= 0)
            {
                return ApiResultHelper.Error("没有查询到对应数据");
            }
            return ApiResultHelper.Success(data);
        }


        [HttpPost("Create")]
        public async Task<ActionResult<ApiResult>> Create(string title, string content, int typeId)
        {
            var blogNews = new BlogNews
            {
                Title = title,
                Content = content,
                LikeCount = 0,
                TypeId = typeId,
                WriterId = 1,
                Time = DateTime.Now
            };
            bool result = await _iBlogNewsService.CreatAsync(blogNews);
            if (result)
            {
                return ApiResultHelper.Success("添加成功");
            }
            else
            {
                return ApiResultHelper.Error("添加失败");
            }
        }
    }
}
