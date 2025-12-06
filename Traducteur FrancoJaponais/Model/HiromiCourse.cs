using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Traducteur_FrancoJaponais.Model.Interface;

namespace Traducteur_FrancoJaponais.Model
{
    public class HiromiCourse : IDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Number { get; set; }

        //Gérer à la main les Fk bicôze SQL lite c 'est pérave
        //public List<HiromiPhrase> HiromiPhrases { get; set; }
        public String Link { get; set; }
    }
}
