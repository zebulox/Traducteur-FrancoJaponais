using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Traducteur_FrancoJaponais.Model.Interface;

namespace Traducteur_FrancoJaponais.Model
{
    public class WordModel : IDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public String Kana { get; set; } = String.Empty;
        public String Japonais { get; set; } = String.Empty;
        public String Romanji { get; set; } = String.Empty;
        public String Francais { get; set; } = String.Empty;
        public String Detail { get; set; } = String.Empty;

        public WordModel()
        {
                
        }
    }
}
