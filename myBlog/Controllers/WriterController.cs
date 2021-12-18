using System.Runtime.Intrinsics.X86;
using System;
using System.Threading.Tasks;
using Iservice;
using Microsoft.AspNetCore.Mvc;
using myBlogDemo.Utility.ApiResult;
using myBlogDemo.Utility.Common;
using MyModel.Model;
using AutoMapper;
using MyModel.Dto;

namespace myBlogDemo.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private IWriteInfoService _IWriteInfoService;
        public WriterController(IWriteInfoService service)
        {
            _IWriteInfoService = service;
        }



        [HttpGet]
        public async Task<ApiResult> Writes()
        {
            var writers = await _IWriteInfoService.QueryAsync();
            return ApiResultHelper.Success(writers);
        }


        [HttpPost("Create")]
        public async Task<ApiResult> Create(string writerName, string password)
        {
            if (string.IsNullOrEmpty(writerName) || string.IsNullOrEmpty(password))
            {
                return ApiResultHelper.Error("用户名和密码不允许为空！");
            }
            var writer = new WriterInfo
            {
                Name = writerName,
                PassWord = Md5Helper.Md5Encrypt(password)
            };
            var result = await _IWriteInfoService.CreatAsync(writer);
            if (result)
            {
                return ApiResultHelper.Success("创建成功");
            }
            else
            {
                return ApiResultHelper.Error("创建失败");
            }
        }

        // [HttpDelete("DeleteWriter")]
        // public async Task<ApiResult> DeleteWriter(int)
        // {
        //     var result = await _IWriteInfoService.FindAsync(id);
        //     if (result == null)
        //     {
        //         return ApiResultHelper.Error("删除失败，没有匹配的数据");
        //     }
        //     else
        //     {
        //         return ApiResultHelper.Success("删除成功");
        //     }
        // }



        [HttpPut("EditWriterName")]
        public async Task<ApiResult> EditWriter(int id, string name = null, string password = null)
        {
            var result = await _IWriteInfoService.FindAsync(id);
            if (result == null)
            {
                return ApiResultHelper.Error("修改失败，没有匹配的数据");
            }
            else
            {
                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(password))
                {
                    return ApiResultHelper.Error("修改失败,参数不能为空");
                }
                else
                {
                    if (string.IsNullOrEmpty(name))
                    {
                        result.PassWord = Md5Helper.Md5Encrypt(password);
                    }
                    else if (string.IsNullOrEmpty(password))
                    {
                        result.Name = name;
                    }
                    else
                    {
                        result.PassWord = Md5Helper.Md5Encrypt(password);
                        result.Name = name;
                    }
                    var editResult = await _IWriteInfoService.EditAsync(result);
                    if (editResult)
                    {
                        return ApiResultHelper.Error("修改成功");
                    }
                    else
                    {
                        return ApiResultHelper.Error("修改失败");
                    }
                }
            }
        }

        [HttpGet("FindWriter")]
        public async Task<ApiResult> Find([FromServices]IMapper IMapper,int id)
        {
            var writer = await _IWriteInfoService.FindAsync(id);
            if (writer == null)
            {
                return ApiResultHelper.Error("无匹配数据");
            }
            else
            {
                var dto=IMapper.Map<WriterInfoDto>(writer);
                return ApiResultHelper.Success(dto);
            }
        }



    }
}
