using SQLite;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Traducteur_FrancoJaponais.Model;
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

        public void InitDataOnBase()
        {
            InitCoursesDataForBase();
            InitPhrasesDataForBase();
        }

        private void InitCoursesDataForBase()
        {
            var courses = database.Table<HiromiCourse>().ToListAsync().Result;
            foreach (var cour in courses)
            {
                int ret = database.DeleteAsync<HiromiCourse>(cour.Id).GetAwaiter().GetResult();
            }

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
                new HiromiCourse() { Link = "https://www.youtube.com/watch?v=5JtSDdBWUwM&list=PLYrBUPk0ywvrBfvG8SsrKeuZEDYdWU7bk&index=13", Number = 102   , HorsSerie = true,  Titre = "Prononciation du R en Japonais"},
            };
            database.InsertAllAsync(Cours);
        }

        private void InitPhrasesDataForBase()
        {

            var courses = database.Table<HiromiPhrase>().ToListAsync().Result;
            foreach (var cour in courses)
            {
                int ret = database.DeleteAsync<HiromiPhrase>(cour.Id).GetAwaiter().GetResult();
            }
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
            database.InsertAllAsync(Cours);

            List<HiromiPhrase> Cours2 = new List<HiromiPhrase>()
            {
                new HiromiPhrase(){CourseNumber = 2, Japonais = "すみません", Francais = "Sumimasen", Explication = "Excusez-moi, léger, sert aussi à attirer l'attention"},
                new HiromiPhrase(){CourseNumber = 2, Japonais = "ごめんなさい", Francais = "Gomennasai", Explication = "Excuses plus sérieuses"},
                new HiromiPhrase(){CourseNumber = 2, Japonais = "たすかります", Francais = "Tasukarimasu", Explication = "Remerciements, lit. ça m'a aidé / vous m'avez aidé"},
                new HiromiPhrase(){CourseNumber = 2, Japonais = "たすかります ありがとう", Francais = "Tasukarimasu Arigatou", Explication = "Remerciements, lit. ça m'a aidé / vous m'avez aidé forme poli"},
                new HiromiPhrase(){CourseNumber = 2, Japonais = "どうしましたか", Francais = "Doushimashitaka", Explication = "Comment puis je vous aider?"},
            };
            database.InsertAllAsync(Cours2);

            List<HiromiPhrase> Cours3 = new List<HiromiPhrase>()
            {
                new HiromiPhrase(){CourseNumber = 3, Japonais = "すごい", Francais = "Sugoi", Explication = "Super!, Génial!, Wahou!"},
                new HiromiPhrase(){CourseNumber = 3, Japonais = "すごい ですね", Francais = "Sugoi Desune", Explication = "Super!, Génial!, Wahou! forme poli"},
                new HiromiPhrase(){CourseNumber = 3, Japonais = "なるほど", Francais = "Naruhodo", Explication = "Je vois, ça fait sens. Utiliser pour marquer l'accord avec l'interlocuteur"},
                new HiromiPhrase(){CourseNumber = 3, Japonais = "たしかに", Francais = "Tashikani", Explication = "Marquer l'accord avec l'interlocuteur, forme familière"},
            };
            database.InsertAllAsync(Cours3);

            List<HiromiPhrase> Cours4 = new List<HiromiPhrase>()
            {
                new HiromiPhrase(){CourseNumber = 4, Japonais = "たのしい", Francais = "Tanoshii", Explication = "On s'amuse !"},
                new HiromiPhrase(){CourseNumber = 4, Japonais = "たのしいね", Francais = "Tanoshii ne", Explication = "On s'amuse !"},
                new HiromiPhrase(){CourseNumber = 4, Japonais = "たのしい ですね", Francais = "Tanoshii desune", Explication = "On s'amuse !. Forme poli"},
                new HiromiPhrase(){CourseNumber = 4, Japonais = "ょかつた です", Francais = "Yokatta desu", Explication = "C 'était bon/bien. Je suis hereux"},
                new HiromiPhrase(){CourseNumber = 4, Japonais = "ちょつと まつて ください", Francais = "Chotto matte kudasai", Explication = "Un moment s'il vous plait"},
                new HiromiPhrase(){CourseNumber = 4, Japonais = "ちょつと", Francais = "Chotto", Explication = "Un peu"},
                new HiromiPhrase(){CourseNumber = 4, Japonais = "まつて", Francais = "Matte", Explication = "Forme imperative du verbe attendre"},
                new HiromiPhrase(){CourseNumber = 4, Japonais = "だいじょぶ", Francais = "Daijobu", Explication = "Es ce que tu va bien ?"},
                new HiromiPhrase(){CourseNumber = 4, Japonais = "だいじょぶ ですか", Francais = "Daijobu Desuka", Explication = "Es ce que vous allez bien ?"},
            };
            database.InsertAllAsync(Cours4);

            List<HiromiPhrase> Cours5 = new List<HiromiPhrase>()
            {
                new HiromiPhrase(){CourseNumber = 5, Japonais = "うれしい", Francais = "Ureshii", Explication = "Ca me fait plaisir. Réponse à une attention ou un cadeau"},
                new HiromiPhrase(){CourseNumber = 5, Japonais = "うれしいな", Francais = "Ureshiina", Explication = "Ca me fait plaisir. Forme introspective"},
                new HiromiPhrase(){CourseNumber = 5, Japonais = "うれしいね", Francais = "Ureshiine", Explication = "Ca fait plaisir? Forme interrogative"},
                new HiromiPhrase(){CourseNumber = 5, Japonais = "うれしいょ", Francais = "Ureshiiyo", Explication = "Ca fait plaisir. Forme familière"},
                new HiromiPhrase(){CourseNumber = 5, Japonais = "うれしい です", Francais = "Ureshii desu", Explication = "Ca fait plaisir. Forme poli"},
                new HiromiPhrase(){CourseNumber = 5, Japonais = "おきおつけて", Francais = "Okiotsukete", Explication = "Aurevoir. Sois prudent. Prends soins de toi."},
                new HiromiPhrase(){CourseNumber = 5, Japonais = "きおつけてね", Francais = "kiotsuketene", Explication = "Aurevoir. forme familière"},
                new HiromiPhrase(){CourseNumber = 5, Japonais = "ゆつくりで だいじょぶだょ", Francais = "Yukkuride Daijobudayo", Explication = "Prends ton temps, tout va bien."},
                new HiromiPhrase(){CourseNumber = 5, Japonais = "ゆつくりで いいょ", Francais = "Yukkuride iiyo", Explication = "Prends ton temps, tout va bien. Autre forme"},
                new HiromiPhrase(){CourseNumber = 5, Japonais = "ゆつくり", Francais = "Yukkuri", Explication = "Lentement, doucement"},
            };
            database.InsertAllAsync(Cours5);

            List<HiromiPhrase> Cours6 = new List<HiromiPhrase>()
            {
                new HiromiPhrase(){CourseNumber = 6, Japonais = "すてきですね", Francais = "Sutekidesune", Explication = "Tu es ravissant(e)"},
                new HiromiPhrase(){CourseNumber = 6, Japonais = "すてきだね", Francais = "Sutekidane", Explication = "Appréciation de l'apparence, d'un travail"},
                new HiromiPhrase(){CourseNumber = 6, Japonais = "すてきだょ", Francais = "Sutekidayo", Explication = "Appréciation de l'apparence forme familière"},
                new HiromiPhrase(){CourseNumber = 6, Japonais = "すてき", Francais = "Suteki", Explication = "Bon, beau, fantastique ..."},
                new HiromiPhrase(){CourseNumber = 6, Japonais = "ょくがん ばつたね", Francais = "Yokugan battane", Explication = "Tu as fait de ton mieux. Encouragements familier"},
                new HiromiPhrase(){CourseNumber = 6, Japonais = "ょく", Francais = "Yoku", Explication = "Très"},
                new HiromiPhrase(){CourseNumber = 6, Japonais = "おつかれ さま です", Francais = "Otsukare sama desu", Explication = "Encouragements professionnel, soutenu"},
                new HiromiPhrase(){CourseNumber = 6, Japonais = "すばらしいです", Francais = "Subarashiidesu", Explication = "Encouragements soutenu"},
                new HiromiPhrase(){CourseNumber = 6, Japonais = "すばらしい かつたです", Francais = "Subarashii kattadesu", Explication = "Encouragements soutenu, forme passée"},
                new HiromiPhrase(){CourseNumber = 6, Japonais = "あなたなら だいじょぶ", Francais = "Anatanara daijobu", Explication = "Je crois en toi. Tout ira bien. Anata => toi, nara marque l'emphase sur le sujet"},
            };
            database.InsertAllAsync(Cours6);

            List<HiromiPhrase> CoursHs1 = new List<HiromiPhrase>()
            {
                new HiromiPhrase(){CourseNumber = 101, Japonais = "いただきます", Francais = "Itadakimasu", Explication = "Bon appétit. Joindre les mains en prière en le disant"},
                new HiromiPhrase(){CourseNumber = 101, Japonais = "ごちそさま でした", Francais = "Gochisosama deshita", Explication = "Formule de fin de repas. Joindre les mains en prière en le disant"},
                new HiromiPhrase(){CourseNumber = 101, Japonais = "からあげ", Francais = "Karaage", Explication = "Poulet frit"},
                new HiromiPhrase(){CourseNumber = 101, Japonais = "たまごやき", Francais = "Tamagoyaki", Explication = "Omelette"},
                new HiromiPhrase(){CourseNumber = 101, Japonais = "にら", Francais = "Nira", Explication = "Ciboulette chinoise"},
                new HiromiPhrase(){CourseNumber = 101, Japonais = "きんぴら", Francais = "Kinpira", Explication = "Salade de carottes et de racines de bandanes sauté"},
                new HiromiPhrase(){CourseNumber = 101, Japonais = "ずつきいに", Francais = "Zukkiini", Explication = "Courgette"},
                new HiromiPhrase(){CourseNumber = 101, Japonais = "ぶろつこりい", Francais = "Burokkorii", Explication = "Brocoli"},
                new HiromiPhrase(){CourseNumber = 101, Japonais = "おにぎり", Francais = "Onigiri", Explication = "Boule de riz"},
            };
            database.InsertAllAsync(CoursHs1);

            List<HiromiPhrase> Cours7 = new List<HiromiPhrase>()
            {
                new HiromiPhrase(){CourseNumber = 7, Japonais = "むり しないでね", Francais = "Muri shinaidene", Explication = "Ne te surmène pas"},
                new HiromiPhrase(){CourseNumber = 7, Japonais = "むり しないで ください", Francais = "Muri shinaide kudasai", Explication = "Ne te surmène pas s'il te plait. Plus poli"},
                new HiromiPhrase(){CourseNumber = 7, Japonais = "ゆつくり やすんでね", Francais = "Yukkuri yasundene", Explication = "Reposes toi bien."},
                new HiromiPhrase(){CourseNumber = 7, Japonais = "ゆつくり やすんで ください", Francais = "Yukkuri yasunde kudasai", Explication = "Reposes toi s 'il te plait. Forme poli"},
                new HiromiPhrase(){CourseNumber = 7, Japonais = "はなして くれて ありがとう", Francais = "hanashite kurete arigatou", Explication = "Merci de m'avoir parlé, de me l'avoir dit"},
            };
            database.InsertAllAsync(Cours7);

            List<HiromiPhrase> Cours8 = new List<HiromiPhrase>()
            {
                new HiromiPhrase(){CourseNumber = 8, Japonais = "これ", Francais = "Kore", Explication = "Ceci (pour parler d'une chose proche physiquement)"},
                new HiromiPhrase(){CourseNumber = 8, Japonais = "それ", Francais = "Sore", Explication = "Cela (pour parler d'une chose plus éloigné physiquement)"},
                new HiromiPhrase(){CourseNumber = 8, Japonais = "これ ください", Francais = "Kore kudasai", Explication = "Je prendrais cela s'il vous plait."},
                new HiromiPhrase(){CourseNumber = 8, Japonais = "それ ください", Francais = "Sore kudasai", Explication = "Je prendrais ceci s'il vous plait."},
                new HiromiPhrase(){CourseNumber = 8, Japonais = "いくら ですか", Francais = "Ikura desuka", Explication = "Combien ça coute?"},
                new HiromiPhrase(){CourseNumber = 8, Japonais = "これ いくら ですか", Francais = "Kore ikura desuka", Explication = "Combien coute ceci?"},
                new HiromiPhrase(){CourseNumber = 8, Japonais = "おすすめ は ありますか", Francais = "Osusume ha arimasuka", Explication = "Avez-vous des recommandations?"},
                new HiromiPhrase(){CourseNumber = 8, Japonais = "ほかに", Francais = "Hokani", Explication = "d'autre(s)"},
                new HiromiPhrase(){CourseNumber = 8, Japonais = "ほかに おすすめ は ありますか", Francais = "Hokani osusume ha arimasuka", Explication = "Avez-vous d'autre(s) recommandations?"},
                new HiromiPhrase(){CourseNumber = 8, Japonais = "も", Francais = "mo", Explication = "Aussi"},
                new HiromiPhrase(){CourseNumber = 8, Japonais = "これも ください", Francais = "koremo kudasai", Explication = "Je prendrai aussi cela s'il vous plait."},
            };
            database.InsertAllAsync(Cours8);

            List<HiromiPhrase> CoursHs2 = new List<HiromiPhrase>()
            {
                new HiromiPhrase(){CourseNumber = 102, Japonais = "らめん", Francais = "Ramen", Explication = "Ramen"},
                new HiromiPhrase(){CourseNumber = 102, Japonais = "りんご", Francais = "Ringo", Explication = "Pomme"},
                new HiromiPhrase(){CourseNumber = 102, Japonais = "るび", Francais = "Rubi", Explication = "Rubis"},
                new HiromiPhrase(){CourseNumber = 102, Japonais = "れもん", Francais = "Remon", Explication = "Citron"},
                new HiromiPhrase(){CourseNumber = 102, Japonais = "ろうそく", Francais = "Rousoku", Explication = "Bougie"}
            };
            database.InsertAllAsync(CoursHs2);

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
