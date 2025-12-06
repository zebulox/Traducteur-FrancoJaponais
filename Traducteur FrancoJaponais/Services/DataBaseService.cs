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

            //InitCoursesDataForBase();
            //InitPhrasesDataForBase();
        }

        private void InitCoursesDataForBase()
        {
            List<HiromiCourse> Cours = new List<HiromiCourse>()
            {
                new HiromiCourse() { Link = "https://www.youtube.com/watch?v=RP17L8jqK2Q&list=PLYrBUPk0ywvrBfvG8SsrKeuZEDYdWU7bk&index=2", Number = 1   , HorsSerie = false, Titre = "Salutations et Politesses"},
                new HiromiCourse() { Link = "https://www.youtube.com/watch?v=qIjYKPg4oe8&list=PLYrBUPk0ywvrBfvG8SsrKeuZEDYdWU7bk&index=3", Number = 2   , HorsSerie = false, Titre = "Politesses"},
                new HiromiCourse() { Link = "https://www.youtube.com/watch?v=l_yjiKGWVPo&list=PLYrBUPk0ywvrBfvG8SsrKeuZEDYdWU7bk&index=4", Number = 3   , HorsSerie = false, Titre = "Expression courantes #1"},
                new HiromiCourse() { Link = "https://www.youtube.com/watch?v=VGn2qDQg-1M&list=PLYrBUPk0ywvrBfvG8SsrKeuZEDYdWU7bk&index=6", Number = 4   , HorsSerie = false, Titre = "Expression courantes #2"},
                new HiromiCourse() { Link = "https://www.youtube.com/watch?v=5JtSDdBWUwM&list=PLYrBUPk0ywvrBfvG8SsrKeuZEDYdWU7bk&index=7", Number = 5   , HorsSerie = false, Titre = "Expression courantes #3"},
                new HiromiCourse() { Link = "https://www.youtube.com/watch?v=5JtSDdBWUwM&list=PLYrBUPk0ywvrBfvG8SsrKeuZEDYdWU7bk&index=8", Number = 6   , HorsSerie = false, Titre = "Encouragements, Compliments"},
                new HiromiCourse() { Link = "https://www.youtube.com/watch?v=5JtSDdBWUwM&list=PLYrBUPk0ywvrBfvG8SsrKeuZEDYdWU7bk&index=10", Number = 101 , HorsSerie = true,  Titre = "Nourriture"},
                new HiromiCourse() { Link = "https://www.youtube.com/watch?v=5JtSDdBWUwM&list=PLYrBUPk0ywvrBfvG8SsrKeuZEDYdWU7bk&index=11", Number = 7   , HorsSerie = false,  Titre = "Réconfort"},
                new HiromiCourse() { Link = "https://www.youtube.com/watch?v=5JtSDdBWUwM&list=PLYrBUPk0ywvrBfvG8SsrKeuZEDYdWU7bk&index=12", Number = 8   , HorsSerie = false,  Titre = "Interractions en magasin"},
            };
            database.InsertAllAsync(Cours);
        }

        private void InitPhrasesDataForBase()
        {
            /*Cours 1*/
            List<HiromiPhrase> Cours = new List<HiromiPhrase>()
            {
                new HiromiPhrase(){CourseNumber = 1, Japonais = "おはょう", Francais = "Ohayo",                 Explication = "Bonjour matinal"},
                new HiromiPhrase(){CourseNumber = 1, Japonais = "おはょう ございます", Francais = "Ohayo Gozaimasu",       Explication = "Bonjour matinal poli"},
                new HiromiPhrase(){CourseNumber = 1, Japonais = "こんにちは", Francais = "Konnichiha",            Explication = "Bonjour, se dit après le matin"},
                new HiromiPhrase(){CourseNumber = 1, Japonais = "こんばんは", Francais = "Konbanha",              Explication = "Bonsoir"},
                new HiromiPhrase(){CourseNumber = 1, Japonais = "おつかれさまです", Francais = "Otsukare sama desu",    Explication = "Bonjour professionnel"},
                new HiromiPhrase(){CourseNumber = 1, Japonais = "おつかれ さま でした", Francais = "Otsukare sama deshita", Explication = "forme passée de Otsukare sama desu"},

            };
            //List<HiromiPhrase> Cours = new List<HiromiPhrase>()
            //{

            //};
            database.InsertAllAsync(Cours);
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
