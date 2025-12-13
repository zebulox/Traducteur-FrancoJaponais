using DataModels.Model;
using SQLite;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Traducteur_FrancoJaponais.Services.DataBase.Interface;

namespace Traducteur_FrancoJaponais.Services.DataBase
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

            database.CreateTableAsync<HiromiPhrase>();
            database.CreateTableAsync<HiromiCourse>();
        }

        public SQLiteAsyncConnection Getdatabase()
        {
            return database;
        }

        public async void backupCoursesOnFileSystem()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            //Win => C:\Users\Hadrien\AppData\Local\User Name\grimont.hadrien.traducteurfrancojaponais\Data
            //Android => /data/user/0/grimont.hadrien.traducteurfrancojaponais/files
            String docsDirectory = FileSystem.AppDataDirectory;
            string HiromiCourseFileName = "HiromiCourse.json";
            string HiromiPhrasesFileName = "HiromiPhrases.json";

            var courses = database.Table<HiromiCourse>().ToListAsync().Result;
            String Json = JsonSerializer.Serialize<List<HiromiCourse>>(courses, options);
            if (File.Exists(Path.Combine(docsDirectory, HiromiCourseFileName)))
                File.Delete(Path.Combine(docsDirectory, HiromiCourseFileName));
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docsDirectory, HiromiCourseFileName)))
            {
                await outputFile.WriteAsync(Json);
            }

            var phrases = database.Table<HiromiPhrase>().ToListAsync().Result;
            Json = JsonSerializer.Serialize<List<HiromiPhrase>>(phrases, options);
            if (File.Exists(Path.Combine(docsDirectory, HiromiPhrasesFileName)))
                File.Delete(Path.Combine(docsDirectory, HiromiPhrasesFileName));
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docsDirectory, HiromiPhrasesFileName)))
            {
                await outputFile.WriteAsync(Json);
            }
        }

        public void ReinitCourses()
        {
            throw new NotImplementedException();
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
