using DataModels.Model.Interface;
using SQLite;

namespace DataModels.Model
{
    public class HiromiCourse : IDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Number { get; set; }
        public bool HorsSerie { get; set; }
        public string Titre { get; set; }

        //Gérer à la main les Fk bicôze SQL lite c 'est pérave
        //public List<HiromiPhrase> HiromiPhrases { get; set; }
        public String Link { get; set; }

        public HiromiCourse()
        {

        }
    }
}
