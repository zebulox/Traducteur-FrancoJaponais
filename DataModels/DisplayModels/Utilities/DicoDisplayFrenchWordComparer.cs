using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.DisplayModels.Utilities
{
    public class DicoDisplayFrenchWordComparer : IComparer<DicoDisplayFrenchWord>
    {
        public int Compare(DicoDisplayFrenchWord? x, DicoDisplayFrenchWord? y)
        {
            if (x == null && y == null) return 0;
            else return x.French.CompareTo(y.French);
        }
    }
}
