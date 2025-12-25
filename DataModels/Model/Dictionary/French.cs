using DataModels.Model.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Model.Dictionary
{
    public class French : IDataModel
    {
        public French()
        {

        }
        [PrimaryKey]
        public int Id { get; set; }
        public string? Value { get; set; }
    }
}
