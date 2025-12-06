using SQLite;
using Traducteur_FrancoJaponais.Model;
using Traducteur_FrancoJaponais.Model.Interface;
using Traducteur_FrancoJaponais.Services.Interface;

namespace Traducteur_FrancoJaponais.Services
{
    public class DataBaseService : IDataBaseService
    {
        SQLiteAsyncConnection database;

        public DataBaseService()
        {
            if (database is not null)
                return;

            database = new SQLiteAsyncConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            InitDataBaseTables();
        }

        private void InitDataBaseTables()
        {
            database.CreateTableAsync<WordModel>();
            database.CreateTableAsync<HiromiPhrase>();
            database.CreateTableAsync<HiromiCourse>();
        }

        public SQLiteAsyncConnection Getdatabase()
        {
            return database;
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
