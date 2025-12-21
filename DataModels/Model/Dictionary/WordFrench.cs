using DataModels.Model.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Model.Dictionary
{
    public class WordFrench : IDataModel
    {
        public WordFrench() { }
        [PrimaryKey]
        public int Id { get; set; }

        public int? WId { get; set; }

        public int? FId { get; set; }
    }
}
