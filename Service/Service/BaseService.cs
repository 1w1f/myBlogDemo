using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IRepository;
using Iservice;
using SqlSugar;


namespace Service
{
    public class BaseService<T> : IBaseService<T> where T : class, new()
    {
        protected IRepository<T> _repository;
        public async Task<bool> CreatAsync(T t)
        {
            return await _repository.CreatAsync(t);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id); 
        }

        public async Task<bool> EditAsync(T t)
        {
            return await _repository.EditAsync(t);
        }

        public async Task<T> FindAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> func)
        {
            return await _repository.FindAsync(func); 
        }

        public async Task<List<T>> QueryAsync()
        {
            return await _repository.QueryAsync();
        }

        public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> func)
        {
            return await _repository.QueryAsync(func);
        }

        public async Task<List<T>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return await _repository.QueryAsync(page,size,total);
        }

        public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> func, int page, int size, RefAsync<int> total)
        {
            return await _repository.QueryAsync(func,page,size,total);
        }
    }
}
