using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using SqlSugar;

namespace IRepository
{
    public interface IRepository<T> where T:class,new()
    {
        Task<bool> CreatAsync(T t);
        Task<bool> DeleteAsync(int id);
        Task<bool> EditAsync(T t);
        Task<T> FindAsync(int id);
        Task<List<T>> QueryAsync();
        //自定义查找
        Task<List<T>> QueryAsync(Expression<Func<T,bool>> func);
        //分页查询
        Task<List<T>> QueryAsync(int page,int size,RefAsync<int> total);
        //自定义分页查询
        Task<List<T>> QueryAsync(Expression<Func<T,bool>> func,int page,int size,RefAsync<int> total);
    }
}
