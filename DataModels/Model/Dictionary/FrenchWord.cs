using DataModels.Model.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Model.Dictionary
{
    public class FrenchWord : IDataModel
    {
        public FrenchWord() { }
        [PrimaryKey]
        public int Id { get; set; }
        public String Value { get; set; }
    }
}
