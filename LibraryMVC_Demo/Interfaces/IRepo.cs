using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC_Demo.Interfaces
{
    public interface IRepo
    {
        Task<IList<T>> SelectAll<T>() where T : class;
        Task<T> SelectById<T>(int Id) where T : class;
        Task CreatAsync<T>(T entity) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
    }
}
