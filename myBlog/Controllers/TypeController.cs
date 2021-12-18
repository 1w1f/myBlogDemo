using System.Linq.Expressions;
using System.Net;

using System;
using System.Threading.Tasks;
using Iservice;
using Microsoft.AspNetCore.Mvc;
using myBlogDemo.Utility.ApiResult;
using MyModel.Model;
using myBlogDemo.Utility.Common;

namespace myBlogDemo.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private ITypeInfoService _iTypeInfoService;
        public TypeController(ITypeInfoService typeService)
        {
            _iTypeInfoService = typeService;
        }

        [HttpPost("Create")]
        public async Task<ApiResult> CreateType(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                return ApiResultHelper.Error("文章类型名不允许为空");
            }
            else
            {

                var result = await _iTypeInfoService.CreatAsync(new TypeInfo
                {
                    Name = typeName,
                }
                );
                if (result)
                {
                    return ApiResultHelper.Success("添加成功");
                }
                return ApiResultHelper.Error("添加失败");
            }
        }

        [HttpGet("GetBlogType")]
        public async Task<ApiResult> GetAllType()
        {
            var result = await _iTypeInfoService.QueryAsync();
            if (result == null)
            {
                return ApiResultHelper.Error("查询失败");
            }
            return ApiResultHelper.Success(result);
        }



        [HttpPut("Edit")]
        public async Task<ApiResult> Edit(int id, string newName)
        {
            var exist = await _iTypeInfoService.FindAsync(id);
            if (exist == null)
            {
                return ApiResultHelper.Error("不存在对应修改的对象");
            }
            var typeInfo = new TypeInfo
            {
                Id = exist.Id,
                Name = newName,
            };
            var result = await _iTypeInfoService.EditAsync(typeInfo);
            if (result)
            {
                return ApiResultHelper.Success("修改成功");
            }
            else
            {
                return ApiResultHelper.Error("修改失败");
            }
        }

        [HttpDelete("DeleteBlogType")]
        public async Task<ApiResult> DeleteBlogType(int id)
        {
            var exist = await _iTypeInfoService.FindAsync(id);
            if (exist == null)
            {
                return ApiResultHelper.Error("无法删除不存在的数据");
            }
            else
            {
                var result = await _iTypeInfoService.DeleteAsync(exist.Id);
                if (result)
                {
                    return ApiResultHelper.Success("删除成功");
                }
                else
                {
                    return ApiResultHelper.Error("删除失败");
                }
            }
        }

    }
}
