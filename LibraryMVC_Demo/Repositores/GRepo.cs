using LibraryMVC_Demo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC_Demo.Repositores
{
    public class GRepo<TDContect> : IRepo where TDContect : DbContext
    {
        private readonly TDContect _td;

        public GRepo(TDContect td)
        {
            _td = td;
        }

        public async Task CreatAsync<T>(T entity) where T : class
        {
            _td.Set<T>().Add(entity);
            _ = await _td.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            _td.Set<T>().Remove(entity);
            _ = await _td.SaveChangesAsync();
        }

        public async Task<IList<T>> SelectAll<T>() where T : class
        {
            return await _td.Set<T>().ToListAsync();
        }

        public async Task<T> SelectById<T>(int Id) where T : class
        {
            return await _td.Set<T>().FindAsync(Id);
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            _td.Set<T>().Update(entity);
            _ = await _td.SaveChangesAsync();
        }
    }
}
