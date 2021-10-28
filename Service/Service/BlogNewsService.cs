using System;
using IRepository;
using Iservice;
using MyModel.Model;

namespace Service
{
    public class BlogNewsService : BaseService<BlogNews>, IBlogNewsService
    {
        private readonly IBlogNewsRepository _iBlogNewsRepository;
        public BlogNewsService(IBlogNewsRepository iBlogNewsRepository)
        {
            base._repository = iBlogNewsRepository;
            _iBlogNewsRepository=iBlogNewsRepository;
        }
    }
}
