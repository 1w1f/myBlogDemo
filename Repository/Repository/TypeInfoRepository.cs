using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IRepository;
using MyModel.Model;
using SqlSugar;

namespace Repository
{
    public class TypeInfoRepository :BaseRepository<TypeInfo>, ITypeInfoRepository
    {
        
    }
}
