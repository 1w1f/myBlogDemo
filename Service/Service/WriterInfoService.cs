using System;
using IRepository;
using Iservice;
using MyModel.Model;

namespace Service
{
    public class WriterInfoService:BaseService<WriterInfo>,IWriteInfoService
    {
        private readonly IWriteInfoRepository _writerInfoRepository;
        public WriterInfoService(IWriteInfoRepository iWriteInfoRepository)
        {
            base._repository = iWriteInfoRepository;
            _writerInfoRepository=iWriteInfoRepository;
        }
    }
}
