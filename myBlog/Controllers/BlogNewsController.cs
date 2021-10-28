using System;
using System.Threading.Tasks;
using Iservice;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> GetBlogNews()
        {
            var data=await _iBlogNewsService.QueryAsync();
            return  Ok(data);
        }
    }
}
