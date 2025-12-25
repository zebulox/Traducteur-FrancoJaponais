using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.DisplayModels
{
    public class DicoDisplayFrenchWord
    {
        public int Id { get; set; }
        public String French { get; set; }
        public List<String> Japaneses { get; set; }
        public List<String> Tags { get; set; }
    }
}
