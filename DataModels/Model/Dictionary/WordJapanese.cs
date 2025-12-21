using DataModels.Model.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Model.Dictionary
{
    public class WordJapanese : IDataModel
    {
        public WordJapanese() { }
        [PrimaryKey]
        public int Id { get; set; }

        public int? WId { get; set; }

        public int? JId { get; set; }
    }
}
