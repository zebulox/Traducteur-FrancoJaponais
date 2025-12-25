using DataModels.Model.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Model.Dictionary
{
    public class JapaneseTag : IDataModel
    {
        public JapaneseTag()
        {

        }
        [PrimaryKey]
        public int Id { get; set; }

        public int? Jid { get; set; }

        public int? Tid { get; set; }
    }
}
