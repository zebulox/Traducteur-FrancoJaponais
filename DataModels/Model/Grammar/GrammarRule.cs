using DataModels.Model.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Model.Grammar
{
    public class GrammarRule : IDataModel
    {
        public GrammarRule()
        {
                
        }
        [PrimaryKey]
        public int Id { get; set; }

        public int GrammarThemeId { get; set; }

        public String Rule { get; set; }
    }
}
