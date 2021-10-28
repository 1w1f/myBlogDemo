using System;
using IRepository;
using Iservice;
using MyModel.Model;

namespace Service
{
    public class TypeInfoService:BaseService<TypeInfo>,ITypeInfoService
    {
        private readonly ITypeInfoRepository _typeInfoRepository;
        public TypeInfoService(ITypeInfoRepository iTypeInfoRepository)
        {
            base._repository = iTypeInfoRepository;
            _typeInfoRepository=iTypeInfoRepository;
        }
    }
}
