using DataModels.Model.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Model
{
    public class Article_Db : IDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; }
        public String Forme { get; set; }
        [Ignore]
        public List<Sens_DB> Sens { get; set; }


        public Article_Db()
        {
                
        }

        public Article_Db(Article rawJsonArticle)
        {
            Text = rawJsonArticle.Text;
            Forme = rawJsonArticle.Forme.Vedette + " // " + rawJsonArticle.Forme.Vedetteféminin + " ( " + rawJsonArticle.Forme.Gram + " ) ";
            
        }
    }

    public class Sens_DB : IDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String Domaine { get; set; }
        public String Registre { get; set; }
        [Ignore]
        public List<Segment_DB> Segment { get; set; }
        public String N { get; set; }
        public string Text { get; set; }
        public int IdArticle { get; set; }


        public Sens_DB()
        {

        }

        public Sens_DB(Sens rawJsonSens, int idArticle)
        {
            Domaine = rawJsonSens.Étiquettes.Domaine.ToString();
            Registre = rawJsonSens.Étiquettes.Registre.ToString();
            N = rawJsonSens.N;
            Text = rawJsonSens.Text;
            IdArticle = idArticle;
        }
    }

    public class Segment_DB : IDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String Jpn { get; set; }
        public string Fra { get; set; }
        public int IdSens { get; set; }

        public Segment_DB()
        {
            
        }

        public Segment_DB(Segment rawJsonSegment, int idSens)
        {
            Jpn = rawJsonSegment.Jpn;
            Fra = rawJsonSegment.Fra;
            IdSens = idSens;
        }
    }
}
