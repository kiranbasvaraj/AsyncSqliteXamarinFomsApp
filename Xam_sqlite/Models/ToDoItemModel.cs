using SQLite;
using SQLiteNetExtensions.Attributes;
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

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Demo> Demos { get; set; }

    }
    public class Demo
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(ToDoItemModel))]
        public int ToDoItemModelId { get; set; }
        public DateTime DateTime { get; set; }
        public string Address { get; set; }

    }


}
