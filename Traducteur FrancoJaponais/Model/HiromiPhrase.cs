using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Traducteur_FrancoJaponais.Model.Interface;

namespace Traducteur_FrancoJaponais.Model
{
    public class HiromiPhrase : IDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int CourseNumber { get; set; }
        public String Japonais { get; set; }
        public String Francais { get; set; }
        public String Explication { get; set; }

        public HiromiPhrase()
        {
                
        }
    }
}
