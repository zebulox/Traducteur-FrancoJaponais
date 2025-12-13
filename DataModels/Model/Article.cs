using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DataModels.Model
{
    /// <summary>
    /// Utilisé pour générer le dico dans la DB à partir du Json
    /// </summary>

    public class Forme
    {
        public string Vedette { get; set; }
        public string Vedetteféminin { get; set; }
        public string Gram { get; set; }
    }

    public class Étiquettes
    {
        public object Domaine { get; set; }
        public object Registre { get; set; }
    }

    public class Segment
    {
        public String Jpn { get; set; }
        public string Fra { get; set; }
    }

    public class Segments
    {
        public List<Segment> Segment { get; set; }
    }

    public class Sens
    {
        public Étiquettes Étiquettes { get; set; }
        public Segments Segments { get; set; }
        public String N { get; set; }
        public string Text { get; set; }
    }

    public class Sémantique
    {
        public List<Sens> Sens { get; set; }
    }

    public class Article
    {
        public Forme Forme { get; set; }
        public Sémantique Sémantique { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
    }
}
