using DataModels.Model.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Model.Dictionary
{
    public class Word : IDataModel
    {
        public Word() { }
        [PrimaryKey]
        public int Id { get; set; }
        public string ResearchString { get; set; }
        //public List<JapanseWord> JapanseForm { get; set; }
        //public List<FrenchWord> FrenchForm { get; set; }
        //public List<Tag> Tags { get; set; }
        //public List<int> TagsIds { get; set; }
    }
}
