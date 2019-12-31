using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Xam_sqlite.Interfaces
{
    public interface IDBService
    {
        Task<bool> CreateAppTables();
        Task<bool> CreateTable<T>() where T : new();
        Task<bool> InsertUpdateData<T>(T data) where T : new();
        Task<bool> DeleteData<T>(T data) where T : new();
        Task<int> InsertAllAsyncWithChildren<T>(List<T> data, bool IgnoreExceptions = false);
        Task<bool> InsertReplaceAsyncWithChildren<T>(T data);
        Task<bool> UpdateAsyncWithChildren<T>(T data);
        Task<T> GetChildren<T>(T obj) where T : new();
        Task<List<T>> GetAllWithChildren<T>() where T : new();
        Task<List<T>> GetAllWithChildren<T>(Expression<Func<T, bool>> filter = null) where T : new();
        Task<bool> DeleteAll<T>() where T : new();
        Task<bool> DeleteAll<T>(Expression<Func<T, bool>> filter = null) where T : new();
        Task ClearAllTables();
        Task<T> GetWithChildren<T>(object key) where T : new();
    }
}
