using System;
using System.Collections.Generic;
using System.Text;
using Traducteur_FrancoJaponais.Constants;

namespace Traducteur_FrancoJaponais.Services.Translation
{
    public static class LatinToHiraganaConverter
    {
        public static String ConvertLatinToHiragana(String latin)
        {
            if (latin.Length == 0)
            {
                return String.Empty;
            }

            string workingString = latin;
            char[] voyelles = new char[] { 'a', 'e', 'i', 'o', 'u', 'n', ' ' };
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < workingString.Length - 1; i++)
            {
                if (workingString[i] == workingString[i + 1] && !voyelles.Contains(workingString[i]))
                {
                    sb.Append('つ');
                }
                else
                {
                    sb.Append(workingString[i]);
                }
            }
            sb.Append(workingString[workingString.Length - 1]);
            workingString = sb.ToString();
            foreach (var substring in Hiragana._Dictionary)
            {
                workingString = workingString.Replace(substring.Key, substring.Value);
            }
             return workingString;
        }

        public static String ConvertLatinToKatakana(String latin)
        {
            if (latin.Length == 0)
            {
                return String.Empty;
            }

            string workingString = latin;
            char[] voyelles = new char[] { 'a', 'e', 'i', 'o', 'u', 'n', ' ' };
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < workingString.Length - 1; i++)
            {
                if (workingString[i] == workingString[i + 1] && !voyelles.Contains(workingString[i]))
                {
                    sb.Append('ツ');
                }
                else
                {
                    sb.Append(workingString[i]);
                }
            }
            sb.Append(workingString[workingString.Length - 1]);
            workingString = sb.ToString();
            foreach (var substring in Katakana._Dictionary)
            {
                workingString = workingString.Replace(substring.Key, substring.Value);
            }
            return workingString;
        }
    }
}
