using DataModels.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Model
{
    public class Article_Db : IDataModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public String Forme { get; set; }
        public List<Sens> Sens { get; set; }


        public Article_Db()
        {
                
        }

        public Article_Db(Article rawJsonArticle)
        {
                
        }
    }
}
