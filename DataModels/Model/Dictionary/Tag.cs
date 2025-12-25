using DataModels.Model.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Model.Dictionary
{
    public class Tag : IDataModel
    {
        public Tag()
        {

        }
        [PrimaryKey]
        public int Id { get; set; }
        public string? Value { get; set; }
    }
}
