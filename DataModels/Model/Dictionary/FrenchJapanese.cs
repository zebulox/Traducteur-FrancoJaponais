using DataModels.Model.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Model.Dictionary
{
    public class FrenchJapanese : IDataModel
    {
        public FrenchJapanese()
        {

        }
        [PrimaryKey]
        public int Id { get; set; }

        public int? Jid { get; set; }

        public int? Fid { get; set; }
    }
}
