
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IRepository;
using MyModel.Model;
using SqlSugar;
using SqlSugar.IOC;

namespace Repository
{
    public class BaseRepository<T> : SimpleClient<T>, IRepository<T> where T : class, new()
    {
        public BaseRepository(ISqlSugarClient context = null) : base(context)
        {
            base.Context = DbScoped.Sugar;
            //创建数据库
            // base.Context.DbMaintenance.CreateDatabase();
            // base.Context.CodeFirst.InitTables(typeof(BlogNews),
            // typeof(TypeInfo),typeof(WriterInfo));
            base.Context.Aop.OnLogExecuting = (sql, pars) =>
            {

            };
        }

        public async Task<bool> CreatAsync(T t)
        {
            return await base.InsertAsync(t);
        }


        public async Task<T> FindAsync(Expression<Func<T, bool>> func)
        {
            return await base.GetSingleAsync(func);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await base.DeleteByIdAsync(id);
        }

        public virtual async Task<bool> EditAsync(T t)
        {
            return await base.UpdateAsync(t);
        }

        public virtual async Task<T> FindAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public virtual async Task<List<T>> QueryAsync()
        {
            return await base.GetListAsync();
        }

        public virtual async Task<List<T>> QueryAsync(Expression<Func<T, bool>> func)
        {
            return await base.GetListAsync(func);
        }

        public virtual async Task<List<T>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return await base.Context.Queryable<T>().ToPageListAsync(page, size, total);
        }

        public virtual async Task<List<T>> QueryAsync(Expression<Func<T, bool>> func, int page, int size, RefAsync<int> total)
        {
            
            return await base.Context.Queryable<T>().Where(func).ToPageListAsync(page, size, total);
        }
    }

}
