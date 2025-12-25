using System;
using System.Collections.Generic;
using System.Text;

namespace Traducteur_FrancoJaponais.Constants
{
    public static class Constants
    {
        public const string DatabaseFilename = "TraducteurFrJap.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        /*Ressources*/
        public const string FrenchJsonFile = "French.json";
        public const string JapaneseJsonFile = "Japanese.json";
        public const string TagJsonFile = "Tag.json";
        public const string FrenchJapaneseJsonFile = "FrenchJapanese.json";
        public const string JapaneseTagJsonFile = "JapaneseTag.json";

    }
}
