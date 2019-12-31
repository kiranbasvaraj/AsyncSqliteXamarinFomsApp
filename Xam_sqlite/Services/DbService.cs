using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xam_sqlite.Interfaces;
using Xam_sqlite.Models;
using Xamarin.Forms;

namespace Xam_sqlite.Services
{
    public sealed class DbService : IDBService
    {
        readonly SQLiteAsyncConnection connection;
        public static DbService Instance { get; private set; } = new DbService();

        public DbService()
        {
            if (connection == null)
            {

                connection = DependencyService.Get<ISqlConnection>().GetConnection();
            }
           
        }
        public async Task<int> InsertAllAsyncWithChildren<T>(List<T> data, bool IgnoreExceptions = false)
        {
            try
            {
                if (IgnoreExceptions == false)
                {
                    await connection.InsertOrReplaceAllWithChildrenAsync(data, true);
                    return data.Count;
                }
                else
                {
                    int count = 0;
                    foreach (var item in data.ToList())
                    {
                        try
                        {
                            await connection.InsertOrReplaceWithChildrenAsync(item, true);
                            count++;
                        }
                        catch (SQLiteException ex)
                        {
                            Debug.WriteLine(ex.ToString());
                            continue;
                        }
                    }
                    return count;
                }
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
        }

        public async Task<bool> InsertReplaceAsyncWithChildren<T>(T data)
        {
            try
            {
                await connection.InsertOrReplaceWithChildrenAsync(data, true);
                return true;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateAsyncWithChildren<T>(T data)
        {
            try
            {
                await connection.UpdateWithChildrenAsync(data);
                return true;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetChildren<T>(T obj) where T : new()
        {
            try
            {
                await connection.GetChildrenAsync<T>(obj, true);
                return obj;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetWithChildren<T>(object key) where T : new()
        {
            try
            {
                var item = await connection.GetWithChildrenAsync<T>(key, true);
                return item;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
        }

        public async Task<List<T>> GetAllWithChildren<T>() where T : new()
        {
            try
            {
                var list = await connection.GetAllWithChildrenAsync<T>(null, true);
                return list;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
        }

        public async Task<List<T>> GetAllWithChildren<T>(Expression<Func<T, bool>> filter = null) where T : new()
        {
            try
            {
                var list = await connection.GetAllWithChildrenAsync(filter, true);
                return list;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CreateTable<T>() where T : new()
        {
            try
            {
                await connection.CreateTableAsync<T>();
                return true;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
        }

        public async Task<bool> InsertUpdateData<T>(T data) where T : new()
        {
            try
            {
                if (await connection.InsertAsync(data) != 0)
                    await connection.UpdateAsync(data);
                return true;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteData<T>(T data) where T : new()
        {
            try
            {
                if (await connection.DeleteAsync(data) == 0)
                {
                    return true;
                }
                return false;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAll<T>() where T : new()
        {
            try
            {
                await connection.DropTableAsync<T>();
                await connection.CreateTableAsync<T>();
                return true;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAll<T>(Expression<Func<T, bool>> filter = null) where T : new()
        {
            try
            {

                if (filter != null)
                {
                    var items = await GetAllWithChildren(filter);
                    await connection.DeleteAllAsync(items, true);
                    return true;
                }
                else
                    return await DeleteAll<T>();
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CreateAppTables()
        {
            try
            {
                await CreateTable<ToDoItemModel>();
             
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task ClearAllTables()
        {
            try
            {
                await DeleteAll<ToDoItemModel>();
                //await DeleteAll<StatusTable>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
