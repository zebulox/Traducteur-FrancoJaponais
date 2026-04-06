using DataModels.Model.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Model.Grammar
{
    public class GrammarVocabulary : IDataModel
    {
        public GrammarVocabulary()
        {
            
        }

        [PrimaryKey]
        public int Id { get; set; }
        public int GrammarThemeId { get; set; }
        public string Japanese { get; set; }
        public string French { get; set; }
    }
}
