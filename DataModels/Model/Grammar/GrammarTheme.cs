using DataModels.Model.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Model.Grammar
{
    public class GrammarTheme : IDataModel
    {
        public GrammarTheme()
        {
            
        }
        [PrimaryKey]
        public int Id { get; set; }

        public String Name { get; set; }
    }
}
