using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Threading;
using System;
using System.Threading.Tasks;
using Iservice;
using Microsoft.AspNetCore.Mvc;
using myBlogDemo.Utility.ApiResult;
using Service;
using MyModel.Model;
using Microsoft.AspNetCore.Authorization;
using SqlSugar;
using AutoMapper;
using MyModel.Dto;
using Microsoft.Extensions.Logging;

namespace myBlogDemo.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogNewsController : ControllerBase
    {
        private readonly IBlogNewsService _iBlogNewsService;
        private readonly ILogger<BlogNewsController> _logger;
        public BlogNewsController(ILogger<BlogNewsController> logger, IBlogNewsService iBlogNewsService)
        {
            _iBlogNewsService = iBlogNewsService;
            _logger = logger;
        }

        [HttpGet("BlogNews")]
        public async Task<ActionResult<ApiResult>> GetBlogNews()
        {
            var userId = this.User.FindFirst("Id");
            var id = Convert.ToInt32(userId.Value);
            var data = await _iBlogNewsService.QueryAsync(item => item.WriterId == id);
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
                WriterId = Convert.ToInt32(this.User.FindFirst("Id").Value),
                Time = DateTime.Now
            };
            bool result = await _iBlogNewsService.CreatAsync(blogNews);
            if (result)
            {
                return ApiResultHelper.Success(blogNews);
            }
            else
            {
                return ApiResultHelper.Error("添加失败");
            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            bool result = await _iBlogNewsService.DeleteAsync(id);
            if (result)
            {
                return ApiResultHelper.Success(id);
            }
            else
            {
                return ApiResultHelper.Error("删除失败");
            }
        }

        [HttpPut("Edit")]
        public async Task<ActionResult<ApiResult>> Edit(int id, string title, string content, int typeId)
        {
            var blogNews = await _iBlogNewsService.FindAsync(id);
            if (blogNews == null) return ApiResultHelper.Error("没有找到数据对象");
            blogNews.Title = title;
            blogNews.Content = content;
            blogNews.TypeId = typeId;
            bool result = await _iBlogNewsService.EditAsync(blogNews);
            if (!result) return ApiResultHelper.Error("添加失败");
            return ApiResultHelper.Success(result);
        }

        [HttpGet("BlogNewsPage")]
        public async Task<ActionResult<ApiResult>> GetsBlogNews([FromServices] IMapper iMapper, int page, int size)
        {
            RefAsync<int> total = 0;
            var result = await _iBlogNewsService.QueryAsync(item => item.WriterId == Convert.ToInt32(this.User.FindFirst("Id").Value), page, size, total);
            var dtoList = new List<BlogNewsDto>();
            result.ForEach(item =>
            {
                dtoList.Add(iMapper.Map<BlogNewsDto>(item));
            });
            return ApiResultHelper.Success(dtoList);
        }
    }
}
