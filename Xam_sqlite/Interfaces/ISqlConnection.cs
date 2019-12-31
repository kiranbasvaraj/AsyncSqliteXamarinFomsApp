using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xam_sqlite.Interfaces
{
    public interface ISqlConnection
    {
        SQLiteAsyncConnection GetConnection();
    }
}
