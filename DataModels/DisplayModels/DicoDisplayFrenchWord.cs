using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.DisplayModels
{
    public class DicoDisplayFrenchWord
    {
        public int Id { get; set; }
        public String ResearchString { get; set; }
        public String French { get; set; }
        public List<String> Japanese { get; set; }
        public List<String> Tags { get; set; }
    }
}
