using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace myBlogDemo.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TestController : ControllerBase
    {


        [HttpGet("NoAuthorize")]
        public string NoAuthorize(){
            return "this is noAuthorize";
        }


        [HttpGet("Authorize")]
        [Authorize]
        public string Authorize()
        {
            return "this is authorize";
        }
    }
}
