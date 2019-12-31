using SQLite;
using System;
using System.IO;
using Xam_sqlite.Droid.DependencyServices;
using Xam_sqlite.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(DroidSqlConnection))]
namespace Xam_sqlite.Droid.DependencyServices
{
    public class DroidSqlConnection : ISqlConnection
    {

        static SQLiteAsyncConnection connect;

        public SQLiteAsyncConnection GetConnection()
        {
            try
            {
                var filename = "test.db3";

                var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var path = Path.Combine(documentsPath, filename);

                if (connect != null)
                {
                    return connect;
                }
                CreateConnection(path);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not Initialize Database", ex);
            }

            return connect;
        }

        private void CreateConnection(string path)
        {
            connect = new SQLiteAsyncConnection(path);
        }
    }
}