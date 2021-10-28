using System;
using MyModel.Model;

namespace IRepository
{
    public interface IWriteInfoRepository:IRepository<WriterInfo>
    {
        void write();
    }
}
