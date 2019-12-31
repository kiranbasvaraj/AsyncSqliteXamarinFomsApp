using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xam_sqlite.Models
{
    public class ToDoItemModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }

    }
}
