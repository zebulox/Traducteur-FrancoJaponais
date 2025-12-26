using DataModels.Model.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Model.Dictionary
{
    public class Japanese : IDataModel
    {
        public Japanese()
        {

        }
        [PrimaryKey]
        public int Id { get; set; }
        public string? Value1 { get; set; }
        public string? Value2 { get; set; }
        public string? Value3 { get; set; }
    }
}
