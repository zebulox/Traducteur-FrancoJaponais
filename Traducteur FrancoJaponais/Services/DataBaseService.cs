using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Traducteur_FrancoJaponais.Model;
using Traducteur_FrancoJaponais.Model.Interface;
using static SQLite.SQLite3;

namespace Traducteur_FrancoJaponais.Services
{
    public class DataBaseService : IDataBaseService
    {
        SQLiteAsyncConnection database;

        public async Task Init()
        {
            if (database is not null)
                return;

            database = new SQLiteAsyncConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            var result = await database.CreateTableAsync<WordModel>();
            result = await database.CreateTableAsync<HiromiPhrase>();
            result = await database.CreateTableAsync<HiromiCourse>();


            WordModel testInsert = new WordModel() { Francais = "complice, partenaire, associé", Detail = "", Japonais = "合い", Kana = "あい", Romanji = "ai" };
            HiromiPhrase phrase = new HiromiPhrase() { Francais = "une seconde", Japonais = "ちょつと まつて", CourseNumber = 1 };
            HiromiCourse cour = new HiromiCourse() { Link = "link", Number = 1};
            int affectedrows = TestInsert(testInsert).Result;
            affectedrows = TestInsert(phrase).Result;
            affectedrows = TestInsert(cour).Result;
            //var test = TestGet().Result;

        }
        private Task<int> TestInsert(IDataModel data)
        {
            return database.InsertAsync(data);
        }

        private Task<List<WordModel>> TestGet()
        {
            return database.Table<WordModel>().ToListAsync();
        }
    }

    /*
     * ex usages
    public int AddNewUser(User user)
    {
        int result = conn.Insert(user);
        return result;
    }
    public List<User> GetAllUsers()
    {
        List<User> users = conn.Table<User>().ToList();
        return users;
    }
     */
}
