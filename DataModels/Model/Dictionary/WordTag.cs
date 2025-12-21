using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Model.Dictionary
{
    public class WordTag
    {
        public WordTag() { }
        public int Id { get; set; }

        public int? WId { get; set; }

        public int? TId { get; set; }
    }
}
