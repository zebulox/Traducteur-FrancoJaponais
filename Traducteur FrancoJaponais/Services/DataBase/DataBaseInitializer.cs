using DataModels.Model;
using DataModels.Model.Dictionary;
using DataModels.Model.Grammar;
using SQLite;
using System.Diagnostics;
using System.Text.Json;
using Traducteur_FrancoJaponais.Services.DataBase.Interface;

namespace Traducteur_FrancoJaponais.Services.DataBase
{
    public class DataBaseInitializer : IDataBaseInitializer
    {
        private SQLiteAsyncConnection database;

        public DataBaseInitializer(SQLiteAsyncConnection db)
        {
            database = db;
        }



        public async Task<bool> InitDataBaseTables()
        {
            await database.DropTableAsync<HiromiPhrase>();
            await database.CreateTableAsync<HiromiPhrase>();

            await database.DropTableAsync<HiromiCourse>();
            await database.CreateTableAsync<HiromiCourse>();

            await database.DropTableAsync<French>();
            await database.CreateTableAsync<French>();

            await database.DropTableAsync<Japanese>();
            await database.CreateTableAsync<Japanese>();

            await database.DropTableAsync<Tag>();
            await database.CreateTableAsync<Tag>();

            await database.DropTableAsync<FrenchJapanese>();
            await database.CreateTableAsync<FrenchJapanese>();

            await database.DropTableAsync<JapaneseTag>();
            await database.CreateTableAsync<JapaneseTag>();

            await database.DropTableAsync<GrammarTheme>();
            await database.CreateTableAsync<GrammarTheme>();

            await database.DropTableAsync<GrammarRule>();
            await database.CreateTableAsync<GrammarRule>();

            await database.DropTableAsync<GrammarVocabulary>();
            await database.CreateTableAsync<GrammarVocabulary>();
            return true;
        }
        public async Task<bool> InitCourData()
        {

            if (database != null)
            {
                await InitCoursesDataForBase();
                await InitPhrasesDataForBase();
                return true;
            }
            return false;
        }

        private async Task InitCoursesDataForBase()
        {
            var courses = database.Table<HiromiCourse>().ToListAsync().Result;
            foreach (var cour in courses)
            {
                int ret = await database.DeleteAsync<HiromiCourse>(cour.Id);
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
                new HiromiCourse() { Link = "https://www.youtube.com/watch?v=5JtSDdBWUwM&list=PLYrBUPk0ywvrBfvG8SsrKeuZEDYdWU7bk&index=13", Number = 9   , HorsSerie = false,  Titre = "Encouragements"},
                new HiromiCourse() { Link = "https://www.youtube.com/watch?v=5JtSDdBWUwM&list=PLYrBUPk0ywvrBfvG8SsrKeuZEDYdWU7bk&index=13", Number = 10   , HorsSerie = false,  Titre = "Présentation"},
                new HiromiCourse() { Link = "https://www.youtube.com/watch?v=5JtSDdBWUwM&list=PLYrBUPk0ywvrBfvG8SsrKeuZEDYdWU7bk&index=13", Number = 11   , HorsSerie = false,  Titre = "Légumes"},
                new HiromiCourse() { Link = "https://www.youtube.com/watch?v=5JtSDdBWUwM&list=PLYrBUPk0ywvrBfvG8SsrKeuZEDYdWU7bk&index=13", Number = 12   , HorsSerie = false,  Titre = "Chiffres"},
                new HiromiCourse() { Link = "https://www.youtube.com/watch?v=5JtSDdBWUwM&list=PLYrBUPk0ywvrBfvG8SsrKeuZEDYdWU7bk&index=13", Number = 103   , HorsSerie = true,  Titre = "Bento box 2"},
                new HiromiCourse() { Link = "https://www.youtube.com/watch?v=5JtSDdBWUwM&list=PLYrBUPk0ywvrBfvG8SsrKeuZEDYdWU7bk&index=13", Number = 104   , HorsSerie = true,  Titre = "Soupe Miso"},
            };
            await database.InsertAllAsync(Cours);
        }

        private async Task InitPhrasesDataForBase()
        {

            var courses = database.Table<HiromiPhrase>().ToListAsync().Result;
            foreach (var cour in courses)
            {
                int ret = await database.DeleteAsync<HiromiPhrase>(cour.Id);
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
            await database.InsertAllAsync(Cours);

            List<HiromiPhrase> Cours2 = new List<HiromiPhrase>()
            {
                new HiromiPhrase(){CourseNumber = 2, Japonais = "すみません", Francais = "Sumimasen", Explication = "Excusez-moi, léger, sert aussi à attirer l'attention"},
                new HiromiPhrase(){CourseNumber = 2, Japonais = "ごめんなさい", Francais = "Gomennasai", Explication = "Excuses plus sérieuses"},
                new HiromiPhrase(){CourseNumber = 2, Japonais = "たすかります", Francais = "Tasukarimasu", Explication = "Remerciements, lit. ça m'a aidé / vous m'avez aidé"},
                new HiromiPhrase(){CourseNumber = 2, Japonais = "たすかります ありがとう", Francais = "Tasukarimasu Arigatou", Explication = "Remerciements, lit. ça m'a aidé / vous m'avez aidé forme poli"},
                new HiromiPhrase(){CourseNumber = 2, Japonais = "どうしましたか", Francais = "Doushimashitaka", Explication = "Comment puis je vous aider?"},
            };
            await database.InsertAllAsync(Cours2);

            List<HiromiPhrase> Cours3 = new List<HiromiPhrase>()
            {
                new HiromiPhrase(){CourseNumber = 3, Japonais = "すごい", Francais = "Sugoi", Explication = "Super!, Génial!, Wahou!"},
                new HiromiPhrase(){CourseNumber = 3, Japonais = "すごい ですね", Francais = "Sugoi Desune", Explication = "Super!, Génial!, Wahou! forme poli"},
                new HiromiPhrase(){CourseNumber = 3, Japonais = "なるほど", Francais = "Naruhodo", Explication = "Je vois, ça fait sens. Utiliser pour marquer l'accord avec l'interlocuteur"},
                new HiromiPhrase(){CourseNumber = 3, Japonais = "たしかに", Francais = "Tashikani", Explication = "Marquer l'accord avec l'interlocuteur, forme familière"},
            };
            await database.InsertAllAsync(Cours3);

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
            await database.InsertAllAsync(Cours4);

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
            await database.InsertAllAsync(Cours5);

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
            await database.InsertAllAsync(Cours6);

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
            await database.InsertAllAsync(CoursHs1);

            List<HiromiPhrase> Cours7 = new List<HiromiPhrase>()
            {
                new HiromiPhrase(){CourseNumber = 7, Japonais = "むり しないでね", Francais = "Muri shinaidene", Explication = "Ne te surmène pas"},
                new HiromiPhrase(){CourseNumber = 7, Japonais = "むり しないで ください", Francais = "Muri shinaide kudasai", Explication = "Ne te surmène pas s'il te plait. Plus poli"},
                new HiromiPhrase(){CourseNumber = 7, Japonais = "ゆつくり やすんでね", Francais = "Yukkuri yasundene", Explication = "Reposes toi bien."},
                new HiromiPhrase(){CourseNumber = 7, Japonais = "ゆつくり やすんで ください", Francais = "Yukkuri yasunde kudasai", Explication = "Reposes toi s 'il te plait. Forme poli"},
                new HiromiPhrase(){CourseNumber = 7, Japonais = "はなして くれて ありがとう", Francais = "hanashite kurete arigatou", Explication = "Merci de m'avoir parlé, de me l'avoir dit"},
            };
            await database.InsertAllAsync(Cours7);

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
            await database.InsertAllAsync(Cours8);

            List<HiromiPhrase> CoursHs2 = new List<HiromiPhrase>()
            {
                new HiromiPhrase(){CourseNumber = 102, Japonais = "らめん", Francais = "Ramen", Explication = "Ramen"},
                new HiromiPhrase(){CourseNumber = 102, Japonais = "りんご", Francais = "Ringo", Explication = "Pomme"},
                new HiromiPhrase(){CourseNumber = 102, Japonais = "るび", Francais = "Rubi", Explication = "Rubis"},
                new HiromiPhrase(){CourseNumber = 102, Japonais = "れもん", Francais = "Remon", Explication = "Citron"},
                new HiromiPhrase(){CourseNumber = 102, Japonais = "ろうそく", Francais = "Rousoku", Explication = "Bougie"}
            };
            await database.InsertAllAsync(CoursHs2);

            List<HiromiPhrase> Cours9 = new List<HiromiPhrase>()
            {
                new HiromiPhrase(){CourseNumber = 9, Japonais = "おめでとう", Francais = "Omedeto", Explication = "Félicitations"},
                new HiromiPhrase(){CourseNumber = 9, Japonais = "おめでとう ございます", Francais = "Omedeto gozaimasu", Explication = "Félicitations (poli)"},
                new HiromiPhrase(){CourseNumber = 9, Japonais = "がんばつて", Francais = "Ganbatte", Explication = "Je crois en toi, fais de ton mieux"},
                new HiromiPhrase(){CourseNumber = 9, Japonais = "がんばつて ください", Francais = "Ganbatte Kudasai", Explication = "Je crois en toi, fais de ton mieux (poli)"},
                new HiromiPhrase(){CourseNumber = 9, Japonais = "ょかつた", Francais = "Yokatta", Explication = "Utilisé pour dire qu'on est content pour l'interlocuteur"},
                new HiromiPhrase(){CourseNumber = 9, Japonais = "ょかつたね", Francais = "Yokatta ne", Explication = "Utilisé pour dire qu'on est content pour l'interlocuteur"},
                new HiromiPhrase(){CourseNumber = 9, Japonais = "ね", Francais = "ne", Explication = "N'est ce pas?, Empathie partage de sentiments, peut être utilisé seul pour répondre"},
                new HiromiPhrase(){CourseNumber = 9, Japonais = "ょくやつたね", Francais = "Yokuyattane", Explication = "Bon travail"},
                new HiromiPhrase(){CourseNumber = 9, Japonais = "いたかつたね", Francais = "Itakattane", Explication = "Tu as du te faire mal ?"},
                new HiromiPhrase(){CourseNumber = 9, Japonais = "たのしい かつたね", Francais = "Tanoshii kattane", Explication = "C 'était fun?"},
                new HiromiPhrase(){CourseNumber = 9, Japonais = "うれしいね", Francais = "Ureshii ne", Explication = "Tu est content/heureux?"},
                new HiromiPhrase(){CourseNumber = 9, Japonais = "ほそい", Francais = "Hosoi", Explication = "fin, mince (épaisseur)"},
                new HiromiPhrase(){CourseNumber = 9, Japonais = "みかん", Francais = "Mikan", Explication = "une orange"},
            };
            await database.InsertAllAsync(Cours9);

            List<HiromiPhrase> Cours10 = new List<HiromiPhrase>()
            {
                new HiromiPhrase(){CourseNumber = 10, Japonais = "はじめ まして", Francais = "Hajime mashite", Explication = "Ravi de faire votre connaissance"},
                new HiromiPhrase(){CourseNumber = 10, Japonais = "ょろしく おねがい します", Francais = "Yoroshiku onegai shimasu", Explication = "J'ai hâte de travailler avec vous (Pro.), Cordialement (Pro.), C 'est un plaisir de faire votre connaissance."},
                new HiromiPhrase(){CourseNumber = 10, Japonais = "ょろしくね", Francais = "Yoroshikune", Explication = "Demander une faveure (casu.)"},
            };
            await database.InsertAllAsync(Cours10);

            List<HiromiPhrase> Cours11 = new List<HiromiPhrase>()
            {
                new HiromiPhrase(){CourseNumber = 11, Japonais = "れたす", Francais = "Retasu", Explication = "Laitue"},
                new HiromiPhrase(){CourseNumber = 11, Japonais = "ちんげんさい", Francais = "Chingensai", Explication = "Choux chinois"},
                new HiromiPhrase(){CourseNumber = 11, Japonais = "なす", Francais = "Nasu", Explication = "Aubergine"},
                new HiromiPhrase(){CourseNumber = 11, Japonais = "だいこん", Francais = "Daikon", Explication = "Radis blanc"},
                new HiromiPhrase(){CourseNumber = 11, Japonais = "おくら", Francais = "Okura", Explication = "Gombo"},
                new HiromiPhrase(){CourseNumber = 11, Japonais = "まいたけ", Francais = "Maitake", Explication = "Champignon Maitake"},
                new HiromiPhrase(){CourseNumber = 11, Japonais = "にんじん", Francais = "Ninjin", Explication = "Carrotes"},
                new HiromiPhrase(){CourseNumber = 11, Japonais = "たまねぎ", Francais = "Tamanegi", Explication = "Oignon"},
                new HiromiPhrase(){CourseNumber = 11, Japonais = "えだまめ", Francais = "Edamame", Explication = "Haricots sur branches (Soja)"},
                new HiromiPhrase(){CourseNumber = 11, Japonais = "もも", Francais = "Momo", Explication = "Pêche"},
                new HiromiPhrase(){CourseNumber = 11, Japonais = "とまと", Francais = "Tomato", Explication = "Tomate"},
                new HiromiPhrase(){CourseNumber = 11, Japonais = "とまと は すきですか", Francais = "Tomato wa sukidesuka", Explication = "Tu aimes les tomate?"},
            };
            await database.InsertAllAsync(Cours11);

            List<HiromiPhrase> Cours12 = new List<HiromiPhrase>()
            {
                new HiromiPhrase(){CourseNumber = 12, Japonais = "ぜろ", Francais = "Zero", Explication = "Zero"},
                new HiromiPhrase(){CourseNumber = 12, Japonais = "いち", Francais = "Ichi", Explication = "un"},
                new HiromiPhrase(){CourseNumber = 12, Japonais = "に", Francais = "Ni", Explication = "deux"},
                new HiromiPhrase(){CourseNumber = 12, Japonais = "さん", Francais = "San", Explication = "trois"},
                new HiromiPhrase(){CourseNumber = 12, Japonais = "ょん / し", Francais = "Yon / shi", Explication = "quatre"},
                new HiromiPhrase(){CourseNumber = 12, Japonais = "ご", Francais = "Go", Explication = "cinq"},
                new HiromiPhrase(){CourseNumber = 12, Japonais = "ろく", Francais = "Roku", Explication = "six"},
                new HiromiPhrase(){CourseNumber = 12, Japonais = "なな / しち", Francais = "Nana / Shichi", Explication = "sept"},
                new HiromiPhrase(){CourseNumber = 12, Japonais = "はち", Francais = "Hachi", Explication = "huit"},
                new HiromiPhrase(){CourseNumber = 12, Japonais = "きゆ", Francais = "Kyu", Explication = "neuf"},
                new HiromiPhrase(){CourseNumber = 12, Japonais = "じゆ", Francais = "Ju", Explication = "dix"},
                new HiromiPhrase(){CourseNumber = 12, Japonais = "ひやく", Francais = "hyaku", Explication = "cent"},
                new HiromiPhrase(){CourseNumber = 12, Japonais = "わたし は さんじゆなな さい です", Francais = "Watashi wa sanjunana sai desu", Explication = "J'ai 37 ans"},
                new HiromiPhrase(){CourseNumber = 12, Japonais = "かのじょ", Francais = "Kanojo", Explication = "Elle"},
                new HiromiPhrase(){CourseNumber = 12, Japonais = "おばちやん", Francais = "Oba - chan", Explication = "Grand mère"},
            };
            await database.InsertAllAsync(Cours12);

            List<HiromiPhrase> CoursHs3 = new List<HiromiPhrase>()
            {
                new HiromiPhrase(){CourseNumber = 103, Japonais = "はんばぐ", Francais = "Hanbagu", Explication = "Steak à hamburger"},
                new HiromiPhrase(){CourseNumber = 103, Japonais = "たまごやき", Francais = "Tamagoyaki", Explication = "Omelette"},
                new HiromiPhrase(){CourseNumber = 103, Japonais = "たまご", Francais = "Tamago", Explication = "Oeuf"},
                new HiromiPhrase(){CourseNumber = 103, Japonais = "やき", Francais = "Yaki", Explication = "Cuisiné"},
                new HiromiPhrase(){CourseNumber = 103, Japonais = "ごまあえ", Francais = "Gomaae", Explication = "Salade au sésame"},
                new HiromiPhrase(){CourseNumber = 103, Japonais = "こまつな", Francais = "Komatsuna", Explication = "Epinard"},
                new HiromiPhrase(){CourseNumber = 103, Japonais = "おあげ", Francais = "Oage", Explication = "Tofu frit"},
                new HiromiPhrase(){CourseNumber = 103, Japonais = "あぶらげ", Francais = "Aburage", Explication = "Qqch de frit"},
                new HiromiPhrase(){CourseNumber = 103, Japonais = "あげ", Francais = "Age", Explication = "huile"},
                new HiromiPhrase(){CourseNumber = 103, Japonais = "あぶら", Francais = "Abura", Explication = "huile"},
                new HiromiPhrase(){CourseNumber = 103, Japonais = "ぐらたん", Francais = "Guratan", Explication = "Gratin"},
            };
            await database.InsertAllAsync(CoursHs3);

            List<HiromiPhrase> CoursHs4 = new List<HiromiPhrase>()
            {
                new HiromiPhrase(){CourseNumber = 104, Japonais = "みそ しる", Francais = "Miso shiru", Explication = "Soupe miso"},
                new HiromiPhrase(){CourseNumber = 104, Japonais = "だし", Francais = "Dashi", Explication = "Bouillon japonnais"},
                new HiromiPhrase(){CourseNumber = 104, Japonais = "わかめ", Francais = "Wakame", Explication = "Algue wakame"},
                new HiromiPhrase(){CourseNumber = 104, Japonais = "おあげ", Francais = "Oage", Explication = "Fines tranche de tofu frit"},
                new HiromiPhrase(){CourseNumber = 104, Japonais = "とふ", Francais = "Tofu", Explication = "Tofu"},
                new HiromiPhrase(){CourseNumber = 104, Japonais = "おはし", Francais = "Ohashi", Explication = "Baguettes"},
                new HiromiPhrase(){CourseNumber = 104, Japonais = "おわん", Francais = "Owan", Explication = "Bol à soupe"},
                new HiromiPhrase(){CourseNumber = 104, Japonais = "おいし", Francais = "Oishi", Explication = "Délicieux"},
            };
            await database.InsertAllAsync(CoursHs4);

        }

        public async Task<bool> InitDicoData()
        {
            await InitFrenchData();
            await InitJapaneseData();
            await InitTagData();
            await InitFrenchJapaneseAssocData();
            await InitJapaneseTagAssocData();
            return true;
        }

        public async Task<bool> InitFrenchData()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync(Constants.Constants.FrenchJsonFile);
            using var reader = new StreamReader(stream);
            var contents = reader.ReadToEnd();
            var words = JsonSerializer.Deserialize<List<French>>(contents);

            List<French> bulkInsert = new List<French>();
            while (words.Count > 0)
            {
                Debug.WriteLine($"{words.Count}");
                bulkInsert = words.Take(1000).ToList();
                await database.InsertAllAsync(bulkInsert);
                words.RemoveRange(0, bulkInsert.Count);
            }
            return true;
        }

        public async Task<bool> InitJapaneseData()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync(Constants.Constants.JapaneseJsonFile);
            using var reader = new StreamReader(stream);
            var contents = reader.ReadToEnd();
            var words = JsonSerializer.Deserialize<List<Japanese>>(contents);

            List<Japanese> bulkInsert = new List<Japanese>();
            while (words.Count > 0)
            {
                Debug.WriteLine($"{words.Count}");
                bulkInsert = words.Take(1000).ToList();
                await database.InsertAllAsync(bulkInsert);
                words.RemoveRange(0, bulkInsert.Count);
            }
            return true;
        }

        public async Task<bool> InitTagData()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync(Constants.Constants.TagJsonFile);
            using var reader = new StreamReader(stream);
            var contents = reader.ReadToEnd();
            var words = JsonSerializer.Deserialize<List<Tag>>(contents);

            List<Tag> bulkInsert = new List<Tag>();
            while (words.Count > 0)
            {
                Debug.WriteLine($"{words.Count}");
                bulkInsert = words.Take(1000).ToList();
                await database.InsertAllAsync(bulkInsert);
                words.RemoveRange(0, bulkInsert.Count);
            }
            return true;
        }

        public async Task<bool> InitFrenchJapaneseAssocData()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync(Constants.Constants.FrenchJapaneseJsonFile);
            using var reader = new StreamReader(stream);
            var contents = reader.ReadToEnd();
            var words = JsonSerializer.Deserialize<List<FrenchJapanese>>(contents);

            List<FrenchJapanese> bulkInsert = new List<FrenchJapanese>();
            while (words.Count > 0)
            {
                Debug.WriteLine($"{words.Count}");
                bulkInsert = words.Take(1000).ToList();
                await database.InsertAllAsync(bulkInsert);
                words.RemoveRange(0, bulkInsert.Count);
            }
            return true;
        }

        public async Task<bool> InitJapaneseTagAssocData()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync(Constants.Constants.JapaneseTagJsonFile);
            using var reader = new StreamReader(stream);
            var contents = reader.ReadToEnd();
            var words = JsonSerializer.Deserialize<List<JapaneseTag>>(contents);

            List<JapaneseTag> bulkInsert = new List<JapaneseTag>();
            while (words.Count > 0)
            {
                Debug.WriteLine($"{words.Count}");
                bulkInsert = words.Take(1000).ToList();
                await database.InsertAllAsync(bulkInsert);
                words.RemoveRange(0, bulkInsert.Count);
            }
            return true;
        }

        public async Task<bool> InitGrammarRules()
        {
            var themes = database.Table<GrammarTheme>().ToListAsync().Result;
            foreach (var theme in themes)
            {
                int ret = await database.DeleteAsync<GrammarTheme>(theme.Id);
            }

            var mots = database.Table<GrammarVocabulary>().ToListAsync().Result;
            foreach (var mot in mots)
            {
                int ret = await database.DeleteAsync<GrammarVocabulary>(mot.Id);
            }

            var rules = database.Table<GrammarRule>().ToListAsync().Result;
            foreach (var rule in rules)
            {
                int ret = await database.DeleteAsync<GrammarRule>(rule.Id);
            }

            List<GrammarTheme> Cours = new List<GrammarTheme>()
            {
                new GrammarTheme() { Id = 1, Name = "I Les Verbes"},
                new GrammarTheme() { Id = 2, Name = "II L'emploi des particules"},
                new GrammarTheme() { Id = 3, Name = "III L'emploi des particules (2)"},
                new GrammarTheme() { Id = 4, Name = "IV Les mots de temps"},
                new GrammarTheme() { Id = 5, Name = "V La particule の"},
                new GrammarTheme() { Id = 6, Name = "VI Les termes de parenté - la forme passée des verbes"},
                new GrammarTheme() { Id = 7, Name = "VII Les démonstratifs"},
                new GrammarTheme() { Id = 8, Name = "VIII Le mot だ - les particules は et も"},
                new GrammarTheme() { Id = 9, Name = "IX Les adjectifs en -i"},
                new GrammarTheme() { Id = 10, Name = "X Les adjectifs invariables"},
                new GrammarTheme() { Id = 11, Name = "XI Verbes intransitifs/transitifs - forme en て et いる"},
                new GrammarTheme() { Id = 12, Name = "XII Le système numéral"},
                new GrammarTheme() { Id = 13, Name = "XIII Le système numéral (2)"},
                new GrammarTheme() { Id = 14, Name = "XIV Les mots de temps chiffrés"},
                new GrammarTheme() { Id = 15, Name = "XV Les mots interrogatifs"},
                new GrammarTheme() { Id = 16, Name = "XVI Les mots indéfinis en か, でも - un peu plus sur も"},
                new GrammarTheme() { Id = 17, Name = "XVII Les verbes à la forme en て + auxiliaires"},
                new GrammarTheme() { Id = 18, Name = "XVIII La proposition déterminante"},
            };
            await database.InsertAllAsync(Cours);

            await InsertGrammarVocabulary();
            await InsertGrammarRules();


            return true;
        }

        private async Task<bool> InsertGrammarVocabulary()
        {
            List<GrammarVocabulary> Cour1 = new List<GrammarVocabulary>()
            {
                new GrammarVocabulary() { Id = 1, GrammarThemeId = 1, French = "Manger", Japanese = "たべる"},
                new GrammarVocabulary() { Id = 2, GrammarThemeId = 1, French = "Boir", Japanese = "のむ"},
                new GrammarVocabulary() { Id = 3, GrammarThemeId = 1, French = "Ecrire", Japanese = "かく"},
                new GrammarVocabulary() { Id = 4, GrammarThemeId = 1, French = "Aller", Japanese = "いく"},
                new GrammarVocabulary() { Id = 5, GrammarThemeId = 1, French = "Se reposer", Japanese = "やすむ"},
                new GrammarVocabulary() { Id = 6, GrammarThemeId = 1, French = "Regarder", Japanese = "みる"},
                new GrammarVocabulary() { Id = 7, GrammarThemeId = 1, French = "Nager", Japanese = "おょぐ"},
                new GrammarVocabulary() { Id = 8, GrammarThemeId = 1, French = "Parler", Japanese = "はなす"},
                new GrammarVocabulary() { Id = 9, GrammarThemeId = 1, French = "Sortir", Japanese = "でかける"},
                new GrammarVocabulary() { Id = 10, GrammarThemeId = 1, French = "Mettre", Japanese = "いれる"},
                new GrammarVocabulary() { Id = 11, GrammarThemeId = 1, French = "Transformer", Japanese = "かえる"},
                new GrammarVocabulary() { Id = 12, GrammarThemeId = 1, French = "Revenir", Japanese = "かえる"},
                new GrammarVocabulary() { Id = 13, GrammarThemeId = 1, French = "Acheter", Japanese = "かう"},
                new GrammarVocabulary() { Id = 14, GrammarThemeId = 1, French = "Dire", Japanese = "いう"},
                new GrammarVocabulary() { Id = 15, GrammarThemeId = 1, French = "Chanter", Japanese = "うたう"},
                new GrammarVocabulary() { Id = 16, GrammarThemeId = 1, French = "Payer", Japanese = "はらう"},
                new GrammarVocabulary() { Id = 17, GrammarThemeId = 1, French = "Laver", Japanese = "あらう"},
                new GrammarVocabulary() { Id = 18, GrammarThemeId = 1, French = "Attendre", Japanese = "まつ"},
            };
            await database.InsertAllAsync(Cour1);

            List<GrammarVocabulary> Cour2 = new List<GrammarVocabulary>()
            {
                new GrammarVocabulary() { Id = 19, GrammarThemeId = 2, French = "Lire", Japanese = "ょむ"},
                new GrammarVocabulary() { Id = 20, GrammarThemeId = 2, French = "Pizza", Japanese = "ピザ"},
                new GrammarVocabulary() { Id = 21, GrammarThemeId = 2, French = "Sushi", Japanese = "おすし"},
                new GrammarVocabulary() { Id = 22, GrammarThemeId = 2, French = "Cinéma, Film", Japanese = "えいが"},
                new GrammarVocabulary() { Id = 23, GrammarThemeId = 2, French = "Télévision", Japanese = "テレビ"},
                new GrammarVocabulary() { Id = 24, GrammarThemeId = 2, French = "Eau", Japanese = "みず"},
                new GrammarVocabulary() { Id = 25, GrammarThemeId = 2, French = "Café", Japanese = "コーヒー"},
                new GrammarVocabulary() { Id = 26, GrammarThemeId = 2, French = "Livre", Japanese = "ほん"},
                new GrammarVocabulary() { Id = 27, GrammarThemeId = 2, French = "Journal", Japanese = "しんぶん"},
                new GrammarVocabulary() { Id = 28, GrammarThemeId = 2, French = "Jouer", Japanese = "あそぶ"},
                new GrammarVocabulary() { Id = 29, GrammarThemeId = 2, French = "Jardin", Japanese = "にわ"},
                new GrammarVocabulary() { Id = 30, GrammarThemeId = 2, French = "Maison", Japanese = "いえ"},
                new GrammarVocabulary() { Id = 31, GrammarThemeId = 2, French = "Gare, Station de métro", Japanese = "えき"},
                new GrammarVocabulary() { Id = 32, GrammarThemeId = 2, French = "Bus", Japanese = "バス"},
                new GrammarVocabulary() { Id = 33, GrammarThemeId = 2, French = "Arrêt de bus", Japanese = "バスてい"},
                new GrammarVocabulary() { Id = 34, GrammarThemeId = 2, French = "Train", Japanese = "でんしや"},
                new GrammarVocabulary() { Id = 35, GrammarThemeId = 2, French = "Ami, Camarade", Japanese = "ともだち"},
                new GrammarVocabulary() { Id = 36, GrammarThemeId = 2, French = "Etre animé", Japanese = "いる"},
                new GrammarVocabulary() { Id = 37, GrammarThemeId = 2, French = "Etre inanimé", Japanese = "ある"},
                new GrammarVocabulary() { Id = 38, GrammarThemeId = 2, French = "Etagère, Bibliothèque", Japanese = "ほんだな"},
                new GrammarVocabulary() { Id = 39, GrammarThemeId = 2, French = "Montagne", Japanese = "やま"},
                new GrammarVocabulary() { Id = 40, GrammarThemeId = 2, French = "Oiseau", Japanese = "とり"},
                new GrammarVocabulary() { Id = 41, GrammarThemeId = 2, French = "Elephant", Japanese = "ぞう"},
                new GrammarVocabulary() { Id = 42, GrammarThemeId = 2, French = "Chat", Japanese = "ねこ"},
                new GrammarVocabulary() { Id = 43, GrammarThemeId = 2, French = "Enfant", Japanese = "こども"},
                new GrammarVocabulary() { Id = 44, GrammarThemeId = 2, French = "Ciel", Japanese = "そら"},
                new GrammarVocabulary() { Id = 45, GrammarThemeId = 2, French = "Neige", Japanese = "ゆき"},
                new GrammarVocabulary() { Id = 46, GrammarThemeId = 2, French = "Pièce, chambre", Japanese = "へや"},
                new GrammarVocabulary() { Id = 47, GrammarThemeId = 2, French = "Fleur", Japanese = "はな"},
                new GrammarVocabulary() { Id = 48, GrammarThemeId = 2, French = "Bruit, son", Japanese = "おと"},
                new GrammarVocabulary() { Id = 49, GrammarThemeId = 2, French = "Musique", Japanese = "おんがく"},
                new GrammarVocabulary() { Id = 50, GrammarThemeId = 2, French = "Chant, chanson", Japanese = "うた"},
                new GrammarVocabulary() { Id = 51, GrammarThemeId = 2, French = "Entendre", Japanese = "きこえる"},
                new GrammarVocabulary() { Id = 52, GrammarThemeId = 2, French = "Voir", Japanese = "みえる"},
                new GrammarVocabulary() { Id = 53, GrammarThemeId = 2, French = "Comprendre", Japanese = "わかる"},
                new GrammarVocabulary() { Id = 54, GrammarThemeId = 2, French = "Pouvoir", Japanese = "できる"},
                new GrammarVocabulary() { Id = 55, GrammarThemeId = 2, French = "Piano", Japanese = "ピアノ"},
                new GrammarVocabulary() { Id = 56, GrammarThemeId = 2, French = "Football", Japanese = "ソツカー"},
                new GrammarVocabulary() { Id = 57, GrammarThemeId = 2, French = "Conduite d'un véhicule", Japanese = "うんてん"},
                new GrammarVocabulary() { Id = 58, GrammarThemeId = 2, French = "Langue anglaise", Japanese = "えいご"},
                new GrammarVocabulary() { Id = 59, GrammarThemeId = 2, French = "Adresse postale", Japanese = "じゆうしょ"},
                new GrammarVocabulary() { Id = 60, GrammarThemeId = 2, French = "Rue, route, chemin", Japanese = "みち"},
                new GrammarVocabulary() { Id = 61, GrammarThemeId = 2, French = "Kanji", Japanese = "かんじ"},
                new GrammarVocabulary() { Id = 62, GrammarThemeId = 2, French = "Stylo bille", Japanese = "ボールペン"},
                new GrammarVocabulary() { Id = 63, GrammarThemeId = 2, French = "Crayon", Japanese = "えんぴつ"},
                new GrammarVocabulary() { Id = 64, GrammarThemeId = 2, French = "Oeil", Japanese = "め"},
                new GrammarVocabulary() { Id = 65, GrammarThemeId = 2, French = "Baguette", Japanese = "はし"},
                new GrammarVocabulary() { Id = 66, GrammarThemeId = 2, French = "Langue japonaise", Japanese = "にほんご"},
            };
            await database.InsertAllAsync(Cour2);


            List<GrammarVocabulary> Cour3 = new List<GrammarVocabulary>()
            {
                new GrammarVocabulary() { Id = 67, GrammarThemeId = 3, French = "Rentrer", Japanese = "かえる"},
                new GrammarVocabulary() { Id = 68, GrammarThemeId = 3, French = "Entrer", Japanese = "はいる"},
                new GrammarVocabulary() { Id = 69, GrammarThemeId = 3, French = "Monter dans un véhicule", Japanese = "のる"},
                new GrammarVocabulary() { Id = 70, GrammarThemeId = 3, French = "Maison", Japanese = "うち"},
                new GrammarVocabulary() { Id = 71, GrammarThemeId = 3, French = "Mer", Japanese = "うみ"},
                new GrammarVocabulary() { Id = 72, GrammarThemeId = 3, French = "Restaurant", Japanese = "レストラン"},
                new GrammarVocabulary() { Id = 73, GrammarThemeId = 3, French = "Japon", Japanese = "にほん"},
                new GrammarVocabulary() { Id = 74, GrammarThemeId = 3, French = "France", Japanese = "フランス"},
                new GrammarVocabulary() { Id = 75, GrammarThemeId = 3, French = "Librairie", Japanese = "ほにや"},
                new GrammarVocabulary() { Id = 76, GrammarThemeId = 3, French = "Supermarché", Japanese = "スーパー"},
                new GrammarVocabulary() { Id = 77, GrammarThemeId = 3, French = "Banque", Japanese = "ぎんごう"},
                new GrammarVocabulary() { Id = 78, GrammarThemeId = 3, French = "Vélo", Japanese = "じてんしや"},
                new GrammarVocabulary() { Id = 79, GrammarThemeId = 3, French = "Voiture", Japanese = "くるま - じどしや"},
                new GrammarVocabulary() { Id = 80, GrammarThemeId = 3, French = "Taxi", Japanese = "タクシー"},
                new GrammarVocabulary() { Id = 81, GrammarThemeId = 3, French = "Magasin", Japanese = "みせ"},
                new GrammarVocabulary() { Id = 82, GrammarThemeId = 3, French = "Passer", Japanese = "とおる"},
                new GrammarVocabulary() { Id = 83, GrammarThemeId = 3, French = "Une femme", Japanese = "ほんなのひと"},
                new GrammarVocabulary() { Id = 84, GrammarThemeId = 3, French = "Un homme", Japanese = "おとこのひと"},
                new GrammarVocabulary() { Id = 85, GrammarThemeId = 3, French = "Descendre d'un véhicule", Japanese = "おりる"},
                new GrammarVocabulary() { Id = 86, GrammarThemeId = 3, French = "Café", Japanese = "カフエ"},
                new GrammarVocabulary() { Id = 87, GrammarThemeId = 3, French = "Magasin de fleur", Japanese = "はなや"},
            };
            await database.InsertAllAsync(Cour3);

            List<GrammarVocabulary> Cour4 = new List<GrammarVocabulary>()
            {
                new GrammarVocabulary() { Id = 88, GrammarThemeId = 4, French = "Lundi", Japanese = "げつょうび"},
                new GrammarVocabulary() { Id = 89, GrammarThemeId = 4, French = "Mardi", Japanese = "かょうび"},
                new GrammarVocabulary() { Id = 90, GrammarThemeId = 4, French = "Mercredi", Japanese = "すいょうび"},
                new GrammarVocabulary() { Id = 91, GrammarThemeId = 4, French = "Jeudi", Japanese = "もくょうび"},
                new GrammarVocabulary() { Id = 92, GrammarThemeId = 4, French = "Vendredi", Japanese = "きんょうび"},
                new GrammarVocabulary() { Id = 93, GrammarThemeId = 4, French = "Samedi", Japanese = "どょうび"},
                new GrammarVocabulary() { Id = 94, GrammarThemeId = 4, French = "dimanche", Japanese = "にちょうび"},
                new GrammarVocabulary() { Id = 95, GrammarThemeId = 4, French = "Tennis", Japanese = "テニス"},
                new GrammarVocabulary() { Id = 96, GrammarThemeId = 4, French = "Golf", Japanese = "ゴルフ"},
                new GrammarVocabulary() { Id = 97, GrammarThemeId = 4, French = "Jogging", Japanese = "ジヨギング"},
                new GrammarVocabulary() { Id = 98, GrammarThemeId = 4, French = "Rugby", Japanese = "ラグビー"},
                new GrammarVocabulary() { Id = 99, GrammarThemeId = 4, French = "Achat, courses", Japanese = "かいもの"},
                new GrammarVocabulary() { Id = 100, GrammarThemeId = 4, French = "Faire", Japanese = "する"},
                new GrammarVocabulary() { Id = 101, GrammarThemeId = 4, French = "Aujourd'hui", Japanese = "きょう"},
                new GrammarVocabulary() { Id = 102, GrammarThemeId = 4, French = "Demain", Japanese = "あした"},
                new GrammarVocabulary() { Id = 103, GrammarThemeId = 4, French = "Cette semaine", Japanese = "こんしゆう"},
                new GrammarVocabulary() { Id = 104, GrammarThemeId = 4, French = "La semaine prochaine", Japanese = "らいしゆう"},
                new GrammarVocabulary() { Id = 105, GrammarThemeId = 4, French = "Ce mois", Japanese = "こんげつ"},
                new GrammarVocabulary() { Id = 106, GrammarThemeId = 4, French = "La mois prochain", Japanese = "らいげつ"},
                new GrammarVocabulary() { Id = 107, GrammarThemeId = 4, French = "Cette année", Japanese = "ことし"},
                new GrammarVocabulary() { Id = 108, GrammarThemeId = 4, French = "L'année prochaine", Japanese = "らいねん"},
                new GrammarVocabulary() { Id = 109, GrammarThemeId = 4, French = "Quand", Japanese = "いつ"},
            };
            await database.InsertAllAsync(Cour4);

            List<GrammarVocabulary> Cour5 = new List<GrammarVocabulary>()
            {
                new GrammarVocabulary() { Id = 110, GrammarThemeId = 5, French = "Montre", Japanese = "とけい"},
                new GrammarVocabulary() { Id = 111, GrammarThemeId = 5, French = "Cartable, sac", Japanese = "かばん"},
                new GrammarVocabulary() { Id = 112, GrammarThemeId = 5, French = "Téléphone portable", Japanese = "けいたいでんわ"},
                new GrammarVocabulary() { Id = 113, GrammarThemeId = 5, French = "Je", Japanese = "わたし"},
                new GrammarVocabulary() { Id = 114, GrammarThemeId = 5, French = "Mr / Mme", Japanese = "さん"},
                new GrammarVocabulary() { Id = 115, GrammarThemeId = 5, French = "Professeur", Japanese = "せんせい"},
                new GrammarVocabulary() { Id = 116, GrammarThemeId = 5, French = "Angleterre", Japanese = "イギリス"},
                new GrammarVocabulary() { Id = 117, GrammarThemeId = 5, French = "Allemagne", Japanese = "ドイシ"},
                new GrammarVocabulary() { Id = 118, GrammarThemeId = 5, French = "Italie", Japanese = "イタリア"},
                new GrammarVocabulary() { Id = 119, GrammarThemeId = 5, French = "Espagne", Japanese = "スパイン"},
                new GrammarVocabulary() { Id = 120, GrammarThemeId = 5, French = "Suisse", Japanese = "スイス"},
                new GrammarVocabulary() { Id = 121, GrammarThemeId = 5, French = "Belgique", Japanese = "ベルギー"},
                new GrammarVocabulary() { Id = 122, GrammarThemeId = 5, French = "Fromage", Japanese = "チーズ"},
                new GrammarVocabulary() { Id = 123, GrammarThemeId = 5, French = "Whisky", Japanese = "ウイスキー"},
                new GrammarVocabulary() { Id = 124, GrammarThemeId = 5, French = "Jambon", Japanese = "ハム"},
                new GrammarVocabulary() { Id = 125, GrammarThemeId = 5, French = "Chocolat", Japanese = "チヨコレート"},
                new GrammarVocabulary() { Id = 126, GrammarThemeId = 5, French = "Or", Japanese = "きん"},
                new GrammarVocabulary() { Id = 127, GrammarThemeId = 5, French = "Argent", Japanese = "ぎん"},
                new GrammarVocabulary() { Id = 128, GrammarThemeId = 5, French = "Plastique", Japanese = "プラスチシク"},
                new GrammarVocabulary() { Id = 129, GrammarThemeId = 5, French = "Bois", Japanese = "き"},
                new GrammarVocabulary() { Id = 130, GrammarThemeId = 5, French = "Cuir, peau", Japanese = "かわ"},
                new GrammarVocabulary() { Id = 131, GrammarThemeId = 5, French = "Boite", Japanese = "にこ"},
                new GrammarVocabulary() { Id = 132, GrammarThemeId = 5, French = "Bague, anneau", Japanese = "ゆびわ"},
                new GrammarVocabulary() { Id = 133, GrammarThemeId = 5, French = "Jouet", Japanese = "おもちや"},
                new GrammarVocabulary() { Id = 134, GrammarThemeId = 5, French = "L'histoire", Japanese = "れきし"},
                new GrammarVocabulary() { Id = 135, GrammarThemeId = 5, French = "L'économie", Japanese = "けいざい"},
                new GrammarVocabulary() { Id = 136, GrammarThemeId = 5, French = "La littérature", Japanese = "ぶんがく"},
                new GrammarVocabulary() { Id = 137, GrammarThemeId = 5, French = "Les arts", Japanese = "びじゆつ"},
                new GrammarVocabulary() { Id = 138, GrammarThemeId = 5, French = "Revue", Japanese = "ざつし"},
                new GrammarVocabulary() { Id = 139, GrammarThemeId = 5, French = "Ce matin", Japanese = "けさ"},
                new GrammarVocabulary() { Id = 140, GrammarThemeId = 5, French = "Ce soir", Japanese = "こんばん"},
                new GrammarVocabulary() { Id = 141, GrammarThemeId = 5, French = "Matin", Japanese = "あさ"},
                new GrammarVocabulary() { Id = 142, GrammarThemeId = 5, French = "Soir", Japanese = "ばん"},
                new GrammarVocabulary() { Id = 143, GrammarThemeId = 5, French = "Nuit", Japanese = "ょる"},
                new GrammarVocabulary() { Id = 144, GrammarThemeId = 5, French = "Midi", Japanese = "ひる"},
                new GrammarVocabulary() { Id = 145, GrammarThemeId = 5, French = "Le dessus", Japanese = "うえ"},
                new GrammarVocabulary() { Id = 146, GrammarThemeId = 5, French = "Le dessous", Japanese = "した"},
                new GrammarVocabulary() { Id = 147, GrammarThemeId = 5, French = "Le dedans", Japanese = "なか"},
                new GrammarVocabulary() { Id = 148, GrammarThemeId = 5, French = "Le devant", Japanese = "まえ"},
                new GrammarVocabulary() { Id = 149, GrammarThemeId = 5, French = "L'arrière", Japanese = "うしろ"},
                new GrammarVocabulary() { Id = 150, GrammarThemeId = 5, French = "La droite", Japanese = "みぎ"},
                new GrammarVocabulary() { Id = 151, GrammarThemeId = 5, French = "La gauche", Japanese = "ひだり"},
                new GrammarVocabulary() { Id = 152, GrammarThemeId = 5, French = "Tiroir", Japanese = "ひきだし"},
                new GrammarVocabulary() { Id = 153, GrammarThemeId = 5, French = "Table, bureau", Japanese = "つくえ"},
                new GrammarVocabulary() { Id = 154, GrammarThemeId = 5, French = "Mettre dans", Japanese = "いれる"},
                new GrammarVocabulary() { Id = 155, GrammarThemeId = 5, French = "Sortir (qqch)", Japanese = "だす"},
                new GrammarVocabulary() { Id = 156, GrammarThemeId = 5, French = "Tourner", Japanese = "まがる"},
                new GrammarVocabulary() { Id = 157, GrammarThemeId = 5, French = "Goût", Japanese = "あじ"},
                new GrammarVocabulary() { Id = 158, GrammarThemeId = 5, French = "Bambou", Japanese = "たけ"},
                new GrammarVocabulary() { Id = 159, GrammarThemeId = 5, French = "Photo", Japanese = "しやしん"},
                new GrammarVocabulary() { Id = 160, GrammarThemeId = 5, French = "Prendre", Japanese = "とる"},
            };
            await database.InsertAllAsync(Cour5);


            List<GrammarVocabulary> Cour6 = new List<GrammarVocabulary>()
            {
                new GrammarVocabulary() { Id = 161, GrammarThemeId = 6, French = "Ma mère", Japanese = "はは"},
                new GrammarVocabulary() { Id = 162, GrammarThemeId = 6, French = "Mon père", Japanese = "ちち"},
                new GrammarVocabulary() { Id = 163, GrammarThemeId = 6, French = "Ma soeur aînée", Japanese = "あね"},
                new GrammarVocabulary() { Id = 164, GrammarThemeId = 6, French = "Mon frère aîné", Japanese = "あに"},
                new GrammarVocabulary() { Id = 165, GrammarThemeId = 6, French = "Ma soeur cadette", Japanese = "いもうと"},
                new GrammarVocabulary() { Id = 166, GrammarThemeId = 6, French = "Mon frère cadet", Japanese = "おとうと"},
                new GrammarVocabulary() { Id = 167, GrammarThemeId = 6, French = "Votre mère", Japanese = "おかあさん"},
                new GrammarVocabulary() { Id = 168, GrammarThemeId = 6, French = "Votre père", Japanese = "おとうさん"},
                new GrammarVocabulary() { Id = 169, GrammarThemeId = 6, French = "Votre soeur ainée", Japanese = "おねえさん"},
                new GrammarVocabulary() { Id = 170, GrammarThemeId = 6, French = "Votre frère ainé", Japanese = "おにいさん"},
                new GrammarVocabulary() { Id = 171, GrammarThemeId = 6, French = "Votre soeur cadette", Japanese = "いもうとさん"},
                new GrammarVocabulary() { Id = 172, GrammarThemeId = 6, French = "Votre frère cadet", Japanese = "おとうとさん"},
                new GrammarVocabulary() { Id = 173, GrammarThemeId = 6, French = "Ma grand mère", Japanese = "そぼ"},
                new GrammarVocabulary() { Id = 174, GrammarThemeId = 6, French = "Mon grand père", Japanese = "そふ"},
                new GrammarVocabulary() { Id = 175, GrammarThemeId = 6, French = "Ma tante", Japanese = "おば"},
                new GrammarVocabulary() { Id = 176, GrammarThemeId = 6, French = "Mon oncle", Japanese = "おじ"},
                new GrammarVocabulary() { Id = 177, GrammarThemeId = 6, French = "Votre grand mère", Japanese = "おばあさん"},
                new GrammarVocabulary() { Id = 178, GrammarThemeId = 6, French = "Votre grand père", Japanese = "おじいさん"},
                new GrammarVocabulary() { Id = 179, GrammarThemeId = 6, French = "Votre tante", Japanese = "おばさん"},
                new GrammarVocabulary() { Id = 180, GrammarThemeId = 6, French = "Votre oncle", Japanese = "おじさん"},
                new GrammarVocabulary() { Id = 181, GrammarThemeId = 6, French = "Ma femme", Japanese = "つま かない"},
                new GrammarVocabulary() { Id = 182, GrammarThemeId = 6, French = "Mon mari", Japanese = "しゆじん"},
                new GrammarVocabulary() { Id = 183, GrammarThemeId = 6, French = "Ma fille", Japanese = "むすめ"},
                new GrammarVocabulary() { Id = 184, GrammarThemeId = 6, French = "Mon fils", Japanese = "むすこ"},
                new GrammarVocabulary() { Id = 185, GrammarThemeId = 6, French = "Votre femme", Japanese = "おくさん"},
                new GrammarVocabulary() { Id = 186, GrammarThemeId = 6, French = "Votre mari", Japanese = "ごしゆじん"},
                new GrammarVocabulary() { Id = 187, GrammarThemeId = 6, French = "Votre fille", Japanese = "むすめさん"},
                new GrammarVocabulary() { Id = 188, GrammarThemeId = 6, French = "Votre fils", Japanese = "むすこさん"},
                new GrammarVocabulary() { Id = 189, GrammarThemeId = 6, French = "Cadeau", Japanese = "プレゼント"},
                new GrammarVocabulary() { Id = 190, GrammarThemeId = 6, French = "Mail", Japanese = "メール"},
                new GrammarVocabulary() { Id = 191, GrammarThemeId = 6, French = "Carte postale", Japanese = "はがき"},
                new GrammarVocabulary() { Id = 192, GrammarThemeId = 6, French = "Hier", Japanese = "きのう"},
                new GrammarVocabulary() { Id = 193, GrammarThemeId = 6, French = "La semaine dernière", Japanese = "せんしゆう"},
                new GrammarVocabulary() { Id = 194, GrammarThemeId = 6, French = "Le mois dernier", Japanese = "せんげつ"},
                new GrammarVocabulary() { Id = 195, GrammarThemeId = 6, French = "L'année dernière", Japanese = "きょねん"},
                new GrammarVocabulary() { Id = 196, GrammarThemeId = 6, French = "Téléphone", Japanese = "でんわ"},
                new GrammarVocabulary() { Id = 197, GrammarThemeId = 6, French = "Téléphoner", Japanese = "でんわ する"},
                new GrammarVocabulary() { Id = 198, GrammarThemeId = 6, French = "Inviter", Japanese = "まねく"},
                new GrammarVocabulary() { Id = 199, GrammarThemeId = 6, French = "Se dépécher", Japanese = "いそぐ"},
                new GrammarVocabulary() { Id = 200, GrammarThemeId = 6, French = "Appeler", Japanese = "ょぶ"},
                new GrammarVocabulary() { Id = 201, GrammarThemeId = 6, French = "Envoyer", Japanese = "おくる"},
            };
            await database.InsertAllAsync(Cour6);

            List<GrammarVocabulary> Cour7 = new List<GrammarVocabulary>()
            {
                new GrammarVocabulary() { Id = 202, GrammarThemeId = 7, French = "Toujours", Japanese = "いつも"},
                new GrammarVocabulary() { Id = 203, GrammarThemeId = 7, French = "Pain", Japanese = "パン"},
                new GrammarVocabulary() { Id = 204, GrammarThemeId = 7, French = "Boulangerie", Japanese = "パンや"},
                new GrammarVocabulary() { Id = 205, GrammarThemeId = 7, French = "Etudier", Japanese = "べんきょう する"},
                new GrammarVocabulary() { Id = 206, GrammarThemeId = 7, French = "Bâtiment", Japanese = "たてもの"},
                new GrammarVocabulary() { Id = 207, GrammarThemeId = 7, French = "Souvent, bien", Japanese = "ょく"},
                new GrammarVocabulary() { Id = 208, GrammarThemeId = 7, French = "Un peu", Japanese = "ちょつと"},
                new GrammarVocabulary() { Id = 209, GrammarThemeId = 7, French = "Dessin, tableau", Japanese = "え"},
                new GrammarVocabulary() { Id = 210, GrammarThemeId = 7, French = "Jardin public, parc", Japanese = "こうえん"},
            };
            await database.InsertAllAsync(Cour7);

            List<GrammarVocabulary> Cour8 = new List<GrammarVocabulary>()
            {
                new GrammarVocabulary() { Id = 211, GrammarThemeId = 8, French = "Etudiant", Japanese = "がくせい"},
                new GrammarVocabulary() { Id = 212, GrammarThemeId = 8, French = "Médecin", Japanese = "いしや"},
                new GrammarVocabulary() { Id = 213, GrammarThemeId = 8, French = "Employé de banque", Japanese = "ぎんこういん"},
                new GrammarVocabulary() { Id = 214, GrammarThemeId = 8, French = "Base-ball", Japanese = "やきゆう"},
                new GrammarVocabulary() { Id = 215, GrammarThemeId = 8, French = "Tous les matins", Japanese = "まいあさ"},
                new GrammarVocabulary() { Id = 216, GrammarThemeId = 8, French = "Maison", Japanese = "いえ"},
                new GrammarVocabulary() { Id = 217, GrammarThemeId = 8, French = "Premier Ministre", Japanese = "しゆしょう"},
                new GrammarVocabulary() { Id = 218, GrammarThemeId = 8, French = "Chine", Japanese = "ちゆうごく"},
                new GrammarVocabulary() { Id = 219, GrammarThemeId = 8, French = "Afrique", Japanese = "アフリカ"},
                new GrammarVocabulary() { Id = 220, GrammarThemeId = 8, French = "Ecosse", Japanese = "スコツトランド"},
                new GrammarVocabulary() { Id = 221, GrammarThemeId = 8, French = "Animal", Japanese = "どうぶつ"},
                new GrammarVocabulary() { Id = 222, GrammarThemeId = 8, French = "Lion", Japanese = "ライオン"},
                new GrammarVocabulary() { Id = 223, GrammarThemeId = 8, French = "Capitale d'un pays", Japanese = "しゆと"},
                new GrammarVocabulary() { Id = 224, GrammarThemeId = 8, French = "Spaghetti", Japanese = "スパゲツテイ"},
                new GrammarVocabulary() { Id = 225, GrammarThemeId = 8, French = "Cerisier", Japanese = "さくら"},
                new GrammarVocabulary() { Id = 226, GrammarThemeId = 8, French = "Fleurir", Japanese = "さく"},
                new GrammarVocabulary() { Id = 227, GrammarThemeId = 8, French = "La terre", Japanese = "ちきゆう"},
                new GrammarVocabulary() { Id = 228, GrammarThemeId = 8, French = "Avril", Japanese = "しがつ"},
                new GrammarVocabulary() { Id = 229, GrammarThemeId = 8, French = "Planète", Japanese = "わくせい"},
                new GrammarVocabulary() { Id = 230, GrammarThemeId = 8, French = "Boisson", Japanese = "のみもの"},
                new GrammarVocabulary() { Id = 231, GrammarThemeId = 8, French = "Sources chaudes", Japanese = "おんせん"},
                new GrammarVocabulary() { Id = 232, GrammarThemeId = 8, French = "Beaucoup", Japanese = "たくさん"},
                new GrammarVocabulary() { Id = 233, GrammarThemeId = 8, French = "Vite, tôt", Japanese = "はやく"},
                new GrammarVocabulary() { Id = 234, GrammarThemeId = 8, French = "Se lever", Japanese = "おきる"},
                new GrammarVocabulary() { Id = 235, GrammarThemeId = 8, French = "Petit déjeuner", Japanese = "あさごはん"},
                new GrammarVocabulary() { Id = 236, GrammarThemeId = 8, French = "Jus de fruit", Japanese = "ジュース"},
                new GrammarVocabulary() { Id = 237, GrammarThemeId = 8, French = "Confiture", Japanese = "ジャム"},
                new GrammarVocabulary() { Id = 238, GrammarThemeId = 8, French = "Miel", Japanese = "はちみつ"},
                new GrammarVocabulary() { Id = 239, GrammarThemeId = 8, French = "Croissant", Japanese = "クロワツサン"},
                new GrammarVocabulary() { Id = 240, GrammarThemeId = 8, French = "Infos (TV radio)", Japanese = "ニユス"},
                new GrammarVocabulary() { Id = 241, GrammarThemeId = 8, French = "Série TV", Japanese = "ドラマ"},
            };
            await database.InsertAllAsync(Cour8);

            List<GrammarVocabulary> Cour9 = new List<GrammarVocabulary>()
            {
                new GrammarVocabulary() { Id = 242, GrammarThemeId = 9, French = "Avoir / être froid", Japanese = "さむい"},
                new GrammarVocabulary() { Id = 243, GrammarThemeId = 9, French = "Etre cher / haut", Japanese = "たかい"},
                new GrammarVocabulary() { Id = 244, GrammarThemeId = 9, French = "Avoir bon goût", Japanese = "おいしい"},
                new GrammarVocabulary() { Id = 245, GrammarThemeId = 9, French = "Etre loin", Japanese = "とおい"},
                new GrammarVocabulary() { Id = 246, GrammarThemeId = 9, French = "Etre neuf / nouveau", Japanese = "あたらしい"},
                new GrammarVocabulary() { Id = 247, GrammarThemeId = 9, French = "Etre agréable / joyeux", Japanese = "たのしい"},
                new GrammarVocabulary() { Id = 248, GrammarThemeId = 9, French = "Etre grand", Japanese = "おおきい"},
                new GrammarVocabulary() { Id = 249, GrammarThemeId = 9, French = "Etre petit", Japanese = "ちいさい"},
                new GrammarVocabulary() { Id = 250, GrammarThemeId = 9, French = "Etre difficile", Japanese = "むずかしい"},
                new GrammarVocabulary() { Id = 251, GrammarThemeId = 9, French = "Etre intéréssant", Japanese = "おむしろい"},
                new GrammarVocabulary() { Id = 252, GrammarThemeId = 9, French = "Etre vieux / ancient", Japanese = "ふるい"},
                new GrammarVocabulary() { Id = 253, GrammarThemeId = 9, French = "Etre rouge", Japanese = "あかい"},
                new GrammarVocabulary() { Id = 254, GrammarThemeId = 9, French = "Etre sombre", Japanese = "くらい"},
                new GrammarVocabulary() { Id = 255, GrammarThemeId = 9, French = "Etre Magnifique", Japanese = "すばらしい"},
                new GrammarVocabulary() { Id = 256, GrammarThemeId = 9, French = "Examen / concours", Japanese = "しけん"},
                new GrammarVocabulary() { Id = 257, GrammarThemeId = 9, French = "Problème / sujet d'exam", Japanese = "もんだい"},
                new GrammarVocabulary() { Id = 258, GrammarThemeId = 9, French = "Etre bon marché", Japanese = "やすい"},
                new GrammarVocabulary() { Id = 259, GrammarThemeId = 9, French = "Etre noir", Japanese = "くろい"},
                new GrammarVocabulary() { Id = 260, GrammarThemeId = 9, French = "Homme (être humain)", Japanese = "ひと"},
                new GrammarVocabulary() { Id = 261, GrammarThemeId = 9, French = "Etre bien", Japanese = "いい"},
            };
            await database.InsertAllAsync(Cour9);

            List<GrammarVocabulary> Cour10 = new List<GrammarVocabulary>()
            {
                new GrammarVocabulary() { Id = 262, GrammarThemeId = 10, French = "Beau", Japanese = "きれい"},
                new GrammarVocabulary() { Id = 263, GrammarThemeId = 10, French = "Célèbre", Japanese = "ゆうめい"},
                new GrammarVocabulary() { Id = 264, GrammarThemeId = 10, French = "Pratique", Japanese = "べんり"},
                new GrammarVocabulary() { Id = 265, GrammarThemeId = 10, French = "Solide", Japanese = "jょうぶ"},
                new GrammarVocabulary() { Id = 266, GrammarThemeId = 10, French = "Gentil, aimable", Japanese = "しんせつ"},
                new GrammarVocabulary() { Id = 267, GrammarThemeId = 10, French = "Ville", Japanese = "まち"},
                new GrammarVocabulary() { Id = 268, GrammarThemeId = 10, French = "Appartement", Japanese = "アパート"},
                new GrammarVocabulary() { Id = 269, GrammarThemeId = 10, French = "En bonne santé, en forme", Japanese = "げんき"},
                new GrammarVocabulary() { Id = 270, GrammarThemeId = 10, French = "Mignon, chic", Japanese = "すてき"},
                new GrammarVocabulary() { Id = 271, GrammarThemeId = 10, French = "Pull", Japanese = "セーター"},
                new GrammarVocabulary() { Id = 272, GrammarThemeId = 10, French = "Chaussure", Japanese = "くつ"},
                new GrammarVocabulary() { Id = 273, GrammarThemeId = 10, French = "Ski", Japanese = "スキー"},
                new GrammarVocabulary() { Id = 274, GrammarThemeId = 10, French = "Voyage", Japanese = "りょこう"},
                new GrammarVocabulary() { Id = 275, GrammarThemeId = 10, French = "La cuisine", Japanese = "りょうり"},
                new GrammarVocabulary() { Id = 276, GrammarThemeId = 10, French = "Les maths", Japanese = "すうがく"},
                new GrammarVocabulary() { Id = 277, GrammarThemeId = 10, French = "Devenir", Japanese = "なる"},
                new GrammarVocabulary() { Id = 278, GrammarThemeId = 10, French = "Aimer", Japanese = "すき / だいすき"},
                new GrammarVocabulary() { Id = 279, GrammarThemeId = 10, French = "Pas aimer", Japanese = "きらい / だいきらい"},
                new GrammarVocabulary() { Id = 280, GrammarThemeId = 10, French = "Vouloir (je voudrais / j'aimerai avoir) Expr. le désir", Japanese = "ほしい"},
                new GrammarVocabulary() { Id = 281, GrammarThemeId = 10, French = "Adroit, fort", Japanese = "じょうず"},
                new GrammarVocabulary() { Id = 282, GrammarThemeId = 10, French = "Maladroit, nul", Japanese = "へた"},
            };
            await database.InsertAllAsync(Cour10);

            List<GrammarVocabulary> Cour11 = new List<GrammarVocabulary>()
            {
                new GrammarVocabulary() { Id = 283, GrammarThemeId = 11, French = "Etre réparé, guéri", Japanese = "なおる"},
                new GrammarVocabulary() { Id = 284, GrammarThemeId = 11, French = "Sortir, quitter un lieu", Japanese = "でる"},
                new GrammarVocabulary() { Id = 285, GrammarThemeId = 11, French = "Se lever", Japanese = "おきる"},
                new GrammarVocabulary() { Id = 286, GrammarThemeId = 11, French = "Rester", Japanese = "のこる"},
                new GrammarVocabulary() { Id = 287, GrammarThemeId = 11, French = "Réparer, guérir", Japanese = "なおす"},
                new GrammarVocabulary() { Id = 288, GrammarThemeId = 11, French = "Sortir (de sa poche ...)", Japanese = "だす"},
                new GrammarVocabulary() { Id = 289, GrammarThemeId = 11, French = "Relever, réveiller", Japanese = "おこす"},
                new GrammarVocabulary() { Id = 290, GrammarThemeId = 11, French = "Laisser", Japanese = "のこす"},
                new GrammarVocabulary() { Id = 291, GrammarThemeId = 11, French = "Quelque chose commence", Japanese = "はじまる"},
                new GrammarVocabulary() { Id = 292, GrammarThemeId = 11, French = "S'arreter", Japanese = "とまる"},
                new GrammarVocabulary() { Id = 293, GrammarThemeId = 11, French = "Faire l'object d'une décision", Japanese = "きまる"},
                new GrammarVocabulary() { Id = 294, GrammarThemeId = 11, French = "Cours", Japanese = "じゆうぎょう"},
                new GrammarVocabulary() { Id = 295, GrammarThemeId = 11, French = "Commencer quelque chose", Japanese = "はじめる"},
                new GrammarVocabulary() { Id = 296, GrammarThemeId = 11, French = "Arrêter", Japanese = "とめる"},
                new GrammarVocabulary() { Id = 297, GrammarThemeId = 11, French = "Décider", Japanese = "きめる"},
                new GrammarVocabulary() { Id = 298, GrammarThemeId = 11, French = "Mariage", Japanese = "けつこん"},
                new GrammarVocabulary() { Id = 299, GrammarThemeId = 11, French = "Maintenant, en ce moment", Japanese = "いま"},
                new GrammarVocabulary() { Id = 300, GrammarThemeId = 11, French = "Habiter", Japanese = "すむ"},
                new GrammarVocabulary() { Id = 301, GrammarThemeId = 11, French = "Tous les jours", Japanese = "まいにち"},
                new GrammarVocabulary() { Id = 302, GrammarThemeId = 11, French = "Travailler, être employé", Japanese = "はたらく"},
                new GrammarVocabulary() { Id = 303, GrammarThemeId = 11, French = "Tous les soirs", Japanese = "まいばん"},
                new GrammarVocabulary() { Id = 304, GrammarThemeId = 11, French = "Lunettes", Japanese = "めがね"},
                new GrammarVocabulary() { Id = 305, GrammarThemeId = 11, French = "T-shirt (tshiyatsu)", Japanese = "tシヤツ"},
                new GrammarVocabulary() { Id = 306, GrammarThemeId = 11, French = "Jean", Japanese = "ジーンズ"},
                new GrammarVocabulary() { Id = 307, GrammarThemeId = 11, French = "Mettre des lunettes", Japanese = " (めがね を) かける"},
                new GrammarVocabulary() { Id = 308, GrammarThemeId = 11, French = "Enfiler (un vêtement)", Japanese = "きる"},
                new GrammarVocabulary() { Id = 309, GrammarThemeId = 11, French = "Enfiler (par les pieds)", Japanese = "はく"},
                new GrammarVocabulary() { Id = 310, GrammarThemeId = 11, French = "Entreprise", Japanese = "かいしや"},
                new GrammarVocabulary() { Id = 311, GrammarThemeId = 11, French = "Caisse (reji)", Japanese = "レジ"},
            };
            await database.InsertAllAsync(Cour11);

            List<GrammarVocabulary> Cour12 = new List<GrammarVocabulary>()
            {
                new GrammarVocabulary() { Id = 312, GrammarThemeId = 12, French = "Un", Japanese = "いち (一)"},
                new GrammarVocabulary() { Id = 313, GrammarThemeId = 12, French = "Deux", Japanese = "に (二)"},
                new GrammarVocabulary() { Id = 314, GrammarThemeId = 12, French = "Trois", Japanese = "さん (三)"},
                new GrammarVocabulary() { Id = 315, GrammarThemeId = 12, French = "Quatre", Japanese = "ょん (し) (四)"},
                new GrammarVocabulary() { Id = 316, GrammarThemeId = 12, French = "Cinq", Japanese = "ご (五)"},
                new GrammarVocabulary() { Id = 317, GrammarThemeId = 12, French = "Six", Japanese = "ろく (六)"},
                new GrammarVocabulary() { Id = 318, GrammarThemeId = 12, French = "Sept", Japanese = "なな (しち) (七)"},
                new GrammarVocabulary() { Id = 319, GrammarThemeId = 12, French = "Huit", Japanese = "はち (八)"},
                new GrammarVocabulary() { Id = 320, GrammarThemeId = 12, French = "Neuf", Japanese = "きゆう (く) (九)"},
                new GrammarVocabulary() { Id = 321, GrammarThemeId = 12, French = "Dix", Japanese = "じゆう (十)"},
                new GrammarVocabulary() { Id = 322, GrammarThemeId = 12, French = "Cent", Japanese = "ひやく (百)"},
                new GrammarVocabulary() { Id = 323, GrammarThemeId = 12, French = "Mille", Japanese = "せん (千)"},
                new GrammarVocabulary() { Id = 324, GrammarThemeId = 12, French = "Dix Mille", Japanese = "まん (万)"},
                new GrammarVocabulary() { Id = 325, GrammarThemeId = 12, French = "Additionner", Japanese = "たす"},
                new GrammarVocabulary() { Id = 326, GrammarThemeId = 12, French = "Soustraire", Japanese = "ひく"},
                new GrammarVocabulary() { Id = 327, GrammarThemeId = 12, French = "Multiplier", Japanese = "かける"},
                new GrammarVocabulary() { Id = 328, GrammarThemeId = 12, French = "Diviser", Japanese = "わる"},
                new GrammarVocabulary() { Id = 329, GrammarThemeId = 12, French = "Yen", Japanese = "えん"},
                new GrammarVocabulary() { Id = 330, GrammarThemeId = 12, French = "Euro (yuro)", Japanese = "ユーロ"},
                new GrammarVocabulary() { Id = 331, GrammarThemeId = 12, French = "Dollar (doru)", Japanese = "ドル"},
                new GrammarVocabulary() { Id = 332, GrammarThemeId = 12, French = "Compteur mince et plats", Japanese = "まい"},
                new GrammarVocabulary() { Id = 333, GrammarThemeId = 12, French = "Cmpt Long et cylindrique", Japanese = "ほん"},
                new GrammarVocabulary() { Id = 334, GrammarThemeId = 12, French = "Cmpt Cubiques ou ronds", Japanese = "こ"},
                new GrammarVocabulary() { Id = 335, GrammarThemeId = 12, French = "Cmpt type livre", Japanese = "さつ"},
            };
            await database.InsertAllAsync(Cour12);

            List<GrammarVocabulary> Cour13 = new List<GrammarVocabulary>()
            {
                new GrammarVocabulary() { Id = 336, GrammarThemeId = 13, French = "Un", Japanese = "ひとつ (一つ)"},
                new GrammarVocabulary() { Id = 337, GrammarThemeId = 13, French = "Deux", Japanese = "ふたつ (二つ)"},
                new GrammarVocabulary() { Id = 338, GrammarThemeId = 13, French = "Trois", Japanese = "みつつ (三つ)"},
                new GrammarVocabulary() { Id = 339, GrammarThemeId = 13, French = "Quatre", Japanese = "ょつつ (四つ)"},
                new GrammarVocabulary() { Id = 340, GrammarThemeId = 13, French = "Cinq", Japanese = "いつつ (五つ)"},
                new GrammarVocabulary() { Id = 341, GrammarThemeId = 13, French = "Six", Japanese = "むつつ (六つ)"},
                new GrammarVocabulary() { Id = 342, GrammarThemeId = 13, French = "Sept", Japanese = "ななつ (七つ)"},
                new GrammarVocabulary() { Id = 343, GrammarThemeId = 13, French = "Huit", Japanese = "やつつ  (八つ)"},
                new GrammarVocabulary() { Id = 344, GrammarThemeId = 13, French = "Neuf", Japanese = "ここのつ (九つ)"},
                new GrammarVocabulary() { Id = 345, GrammarThemeId = 13, French = "Dix", Japanese = "とお (十)"},
                new GrammarVocabulary() { Id = 346, GrammarThemeId = 13, French = "Salle de cinéma", Japanese = "えいがかん"},
                new GrammarVocabulary() { Id = 347, GrammarThemeId = 13, French = "Origami", Japanese = "おりがみ"},
                new GrammarVocabulary() { Id = 348, GrammarThemeId = 13, French = "Fabriquer", Japanese = "つくる"},
                new GrammarVocabulary() { Id = 349, GrammarThemeId = 13, French = "Papier", Japanese = "かみ"},
                new GrammarVocabulary() { Id = 350, GrammarThemeId = 13, French = "Pinceau", Japanese = "ふで"},
                new GrammarVocabulary() { Id = 351, GrammarThemeId = 13, French = "Tulipe (chiyurishipu)", Japanese = "チユーリシプ"},
                new GrammarVocabulary() { Id = 352, GrammarThemeId = 13, French = "Bière", Japanese = "ビール"},
                new GrammarVocabulary() { Id = 353, GrammarThemeId = 13, French = "Gomme (à effacer)", Japanese = "けしゴム"},
                new GrammarVocabulary() { Id = 354, GrammarThemeId = 13, French = "Gâteau", Japanese = "ケーキ"},
                new GrammarVocabulary() { Id = 355, GrammarThemeId = 13, French = "Pomme", Japanese = "りんご"},
            };
            await database.InsertAllAsync(Cour13);

            return true;
        }

        private async Task<bool> InsertGrammarRules()
        {
            List<GrammarRule> Cour1 = new List<GrammarRule>()
            {
                new GrammarRule() { Id = 1, GrammarThemeId = 1, Rule = "Verbes en <span class=\"badge text-bg-primary\">-IRU</span> <span class=\"badge text-bg-primary\">-ERU</span> Type 1 ichidan"},
                new GrammarRule() { Id = 2, GrammarThemeId = 1, Rule = "Autres verbes Type 2 godan"},
                new GrammarRule() { Id = 3, GrammarThemeId = 1, Rule = "Conjugaison en <span class=\"badge text-bg-primary\">-ます</span>"},
                new GrammarRule() { Id = 4, GrammarThemeId = 1, Rule = "ichidan => retirer le radicale et ajouter <span class=\"badge text-bg-primary\">-ます</span> <span class=\"badge text-bg-success\">たべる => たべます</span>"},
                new GrammarRule() { Id = 5, GrammarThemeId = 1, Rule = "godan => remplacer <span class=\"badge text-bg-primary\">-u</span> par <span class=\"badge text-bg-primary\">-i</span> et ajouter <span class=\"badge text-bg-primary\">-ます</span> <span class=\"badge text-bg-success\">のむ => のみます</span>"},
                new GrammarRule() { Id = 6, GrammarThemeId = 1, Rule = "<span class=\"badge text-bg-primary\">か</span> en fin de phrase pour une question <span class=\"badge text-bg-success\">いきます か => Tu y vas ?</span>"},
                new GrammarRule() { Id = 7, GrammarThemeId = 1, Rule = "Négation suffixe <span class=\"badge text-bg-primary\">-ない</span> ou <span class=\"badge text-bg-primary\">-ません</span>"},
                new GrammarRule() { Id = 8, GrammarThemeId = 1, Rule = "ichidan => retirer le radicale et ajouter <span class=\"badge text-bg-primary\">-ない</span> ou <span class=\"badge text-bg-primary\">-ません</span> <span class=\"badge text-bg-success\">たべる => たべない, たべません</span>"},
                new GrammarRule() { Id = 9, GrammarThemeId = 1, Rule = "godan => remplacer <span class=\"badge text-bg-primary\">-u</span> par <span class=\"badge text-bg-primary\">-a</span> et ajouter <span class=\"badge text-bg-primary\">-ない</span> <span class=\"badge text-bg-success\">のむ => のまない</span>"},
                new GrammarRule() { Id = 10, GrammarThemeId = 1, Rule = "godan => Exception si verbe se termine en <span class=\"badge text-bg-primary\">-u</span> remplacer <span class=\"badge text-bg-primary\">-u</span> par <span class=\"badge text-bg-primary\">-wa</span> <span class=\"badge text-bg-success\">かう => かわない</span>"},
                new GrammarRule() { Id = 11, GrammarThemeId = 1, Rule = "godan => remplacer <span class=\"badge text-bg-primary\">-u</span> par <span class=\"badge text-bg-primary\">-i</span> et ajouter <span class=\"badge text-bg-primary\">-ません</span> <span class=\"badge text-bg-success\">のむ => のみません</span>"},
            };
            await database.InsertAllAsync(Cour1);

            List<GrammarRule> Cour2 = new List<GrammarRule>()
            {
                new GrammarRule() { Id = 12, GrammarThemeId = 2, Rule = "Complément d'objet avec la particule <span class=\"badge text-bg-primary\">を</span> <span class=\"badge text-bg-success\">ピザ を たべます</span>"},
                new GrammarRule() { Id = 13, GrammarThemeId = 2, Rule = "Indication sur le lieu ou se déroule une action <span class=\"badge text-bg-primary\">で</span> <span class=\"badge text-bg-success\">にわ で やすみます</span>"},
                new GrammarRule() { Id = 14, GrammarThemeId = 2, Rule = "Indication d'un emplacement spatiale <span class=\"badge text-bg-primary\">に</span> <span class=\"badge text-bg-success\">にわ に います</span>"},
                new GrammarRule() { Id = 15, GrammarThemeId = 2, Rule = "La particule <span class=\"badge text-bg-primary\">が</span>"},
                new GrammarRule() { Id = 16, GrammarThemeId = 2, Rule = "Sujet d'une phrase <span class=\"badge text-bg-primary\">が</span> <span class=\"badge text-bg-success\">ねこ が います</span>"},
                new GrammarRule() { Id = 17, GrammarThemeId = 2, Rule = "Note contrairement à <span class=\"badge text-bg-primary\">は</span>, <span class=\"badge text-bg-primary\">が</span> insiste plus sur le sujet en en faisant l'élement principale de la phrase"},
                new GrammarRule() { Id = 18, GrammarThemeId = 2, Rule = "utilisé pour répondre aux question <span class=\"badge text-bg-primary\">だれ</span>(qui?) <span class=\"badge text-bg-primary\">どの</span>(quel?) <span class=\"badge text-bg-primary\">どれ</span>(lequel?)"},
                new GrammarRule() { Id = 19, GrammarThemeId = 2, Rule = "Peut être mélangé avec <span class=\"badge text-bg-primary\">は</span> dans ce cas <span class=\"badge text-bg-primary\">は</span> est le thème de phrase et <span class=\"badge text-bg-primary\">が</span> le sujet <span class=\"badge text-bg-success\">Kyou wa hadrien ga resutoran de tomodachi to piza wo tabemasu.</span>"},
                new GrammarRule() { Id = 20, GrammarThemeId = 2, Rule = "Utilisé avec les Adjectifs <span class=\"badge text-bg-primary\">-i</span> et <span class=\"badge text-bg-primary\">-na</span> <span class=\"badge text-bg-success\">osushi ga oishii desu.</span>"},
                new GrammarRule() { Id = 21, GrammarThemeId = 2, Rule = "Utilisé avec <span class=\"badge text-bg-primary\">iru</span> et <span class=\"badge text-bg-primary\">aru</span> <span class=\"badge text-bg-success\">ねこ が います.</span>"},
                new GrammarRule() { Id = 22, GrammarThemeId = 2, Rule = "Utilisé avec les verbes intransitifs <span class=\"badge text-bg-success\">Ashita kara nihongo no ressun ga hajimaru</span>"},
                new GrammarRule() { Id = 23, GrammarThemeId = 2, Rule = "Quand la particule <span class=\"badge text-bg-primary\">が</span> est placée après un verbe à la forme polie, on traduit <span class=\"badge text-bg-primary\">が</span> par mais ou cependant. <span class=\"badge text-bg-success\">Kyonen nihon ni ikimashita ga, kyouto ni ikimasen deshita.</span>"},
                new GrammarRule() { Id = 24, GrammarThemeId = 2, Rule = "le fait d’employer <span class=\"badge text-bg-primary\">no desu ga</span> en fin de phrase permet de rendre notre requête plus polie et moins directe."},
                new GrammarRule() { Id = 25, GrammarThemeId = 2, Rule = "La particule <span class=\"badge text-bg-primary\">で</span> sert aussi à indiquer le moyen d'une action <span class=\"badge text-bg-success\">えんぴつ で かきます</span>"},
            };
            await database.InsertAllAsync(Cour2);

            List<GrammarRule> Cour3 = new List<GrammarRule>()
            {
                new GrammarRule() { Id = 26, GrammarThemeId = 3, Rule = "La particule <span class=\"badge text-bg-primary\">に</span> indique aussi le but d'un déplacement <span class=\"badge text-bg-success\">えき に いきます</span>"},
                new GrammarRule() { Id = 27, GrammarThemeId = 3, Rule = "La particule <span class=\"badge text-bg-primary\">と</span> indique avec qui on fait une action <span class=\"badge text-bg-success\">ともだち と いきます</span>"},
                new GrammarRule() { Id = 28, GrammarThemeId = 3, Rule = "La particule <span class=\"badge text-bg-primary\">から</span> indique le point de départ d'une action <span class=\"badge text-bg-success\">うち から えき まで いきます</span>"},
                new GrammarRule() { Id = 29, GrammarThemeId = 3, Rule = "La particule <span class=\"badge text-bg-primary\">まで</span> indique le point final d'une action <span class=\"badge text-bg-success\">うち から えき まで いきます</span>"},
                new GrammarRule() { Id = 30, GrammarThemeId = 3, Rule = "<span class=\"badge text-bg-primary\">から</span> peut être employé de manière temporelle <span class=\"badge text-bg-success\">Ashita kara nihongo no ressun ga hajimaru</span>"},
            };
            await database.InsertAllAsync(Cour3);

            List<GrammarRule> Cour4 = new List<GrammarRule>()
            {
                new GrammarRule() { Id = 31, GrammarThemeId = 4, Rule = "La particule <span class=\"badge text-bg-primary\">に</span> indique aussi le temps où se déroule une action <span class=\"badge text-bg-success\">かょうび に くるま で いきます</span>"},
                new GrammarRule() { Id = 32, GrammarThemeId = 4, Rule = "La question QUOI est formulé avec <span class=\"badge text-bg-primary\">なに</span> <span class=\"badge text-bg-success\">なに を します か</span>"},
                new GrammarRule() { Id = 33, GrammarThemeId = 4, Rule = "Si elle précède un mot commençant par <span class=\"badge text-bg-primary\">D</span> on utilise <span class=\"badge text-bg-primary\">なん</span> <span class=\"badge text-bg-success\">なん で たべます か</span>"},
                new GrammarRule() { Id = 34, GrammarThemeId = 4, Rule = "La question QUAND est formulé avec <span class=\"badge text-bg-primary\">いつ</span> <span class=\"badge text-bg-success\">いつ にほん に いきます か</span>"},
            };
            await database.InsertAllAsync(Cour4);

            List<GrammarRule> Cour5 = new List<GrammarRule>()
            {
                new GrammarRule() { Id = 35, GrammarThemeId = 5, Rule = "La particule <span class=\"badge text-bg-primary\">の</span>"},
                new GrammarRule() { Id = 36, GrammarThemeId = 5, Rule = "Exprime la propriété <span class=\"badge text-bg-success\">ともだち の でんしや</span>"},
                new GrammarRule() { Id = 37, GrammarThemeId = 5, Rule = "Exprime l'origine <span class=\"badge text-bg-success\">ドイシ の くるま</span>"},
                new GrammarRule() { Id = 38, GrammarThemeId = 5, Rule = "Exprime la composition <span class=\"badge text-bg-success\">きん の ゆびわ</span>"},
                new GrammarRule() { Id = 39, GrammarThemeId = 5, Rule = "Exprime un domaine <span class=\"badge text-bg-success\">れきし の ざつし</span>"},
                new GrammarRule() { Id = 40, GrammarThemeId = 5, Rule = "Se combine avec les mots temporels <span class=\"badge text-bg-success\">かょうび の あさ</span>"},
                new GrammarRule() { Id = 41, GrammarThemeId = 5, Rule = "Se combine avec la localisation spatiale <span class=\"badge text-bg-success\">つくえ の うえ</span>"},
                new GrammarRule() { Id = 42, GrammarThemeId = 5, Rule = "Se chaine <span class=\"badge text-bg-success\">いえ の まえ の き</span>"},
            };
            await database.InsertAllAsync(Cour5);

            List<GrammarRule> Cour6 = new List<GrammarRule>()
            {
                new GrammarRule() { Id = 43, GrammarThemeId = 6, Rule = "La forme passée"},
                new GrammarRule() { Id = 44, GrammarThemeId = 6, Rule = "ichidan => retirer le radicale et ajouter <span class=\"badge text-bg-primary\">-た</span> <span class=\"badge text-bg-success\">たべる => たべた</span>"},
                new GrammarRule() { Id = 45, GrammarThemeId = 6, Rule = "ichidan => retirer le radicale et ajouter <span class=\"badge text-bg-primary\">-ました</span> <span class=\"badge text-bg-success\">たべる => たべました</span>"},
                new GrammarRule() { Id = 46, GrammarThemeId = 6, Rule = "godan => remplacer <span class=\"badge text-bg-primary\">-u</span> par <span class=\"badge text-bg-primary\">-i</span> et ajouter <span class=\"badge text-bg-primary\">-ました</span> <span class=\"badge text-bg-success\">のむ => のみました</span>"},
                new GrammarRule() { Id = 47, GrammarThemeId = 6, Rule = "godan => La forme en <span class=\"badge text-bg-primary\">-た</span> dépends de la fin du verbe"},
                new GrammarRule() { Id = 48, GrammarThemeId = 6, Rule = "godan => <span class=\"badge text-bg-primary\">-す</span> remplacé par <span class=\"badge text-bg-primary\">-し</span> avec l'ajout de <span class=\"badge text-bg-primary\">-た</span> <span class=\"badge text-bg-success\">はなす => はなした</span>"},
                new GrammarRule() { Id = 49, GrammarThemeId = 6, Rule = "godan => <span class=\"badge text-bg-primary\">-く</span> remplacé par <span class=\"badge text-bg-primary\">-い</span> avec l'ajout de <span class=\"badge text-bg-primary\">-た</span> <span class=\"badge text-bg-success\">まねく => まねいた</span>"},
                new GrammarRule() { Id = 50, GrammarThemeId = 6, Rule = "godan => <span class=\"badge text-bg-primary\">-ぐ</span> remplacé par <span class=\"badge text-bg-primary\">-い</span> avec l'ajout de <span class=\"badge text-bg-primary\">-だ</span> <span class=\"badge text-bg-success\">いそぐ => いそいだ</span>"},
                new GrammarRule() { Id = 51, GrammarThemeId = 6, Rule = "godan => <span class=\"badge text-bg-primary\">-む</span> <span class=\"badge text-bg-primary\">-ぬ</span> <span class=\"badge text-bg-primary\">-ぶ</span> remplacé par <span class=\"badge text-bg-primary\">-ん</span> avec l'ajout de <span class=\"badge text-bg-primary\">-だ</span> <span class=\"badge text-bg-success\">ょぶ => ょんだ</span>"},
                new GrammarRule() { Id = 52, GrammarThemeId = 6, Rule = "godan => <span class=\"badge text-bg-primary\">-う</span> <span class=\"badge text-bg-primary\">-つ</span> <span class=\"badge text-bg-primary\">-る</span> remplacé par <span class=\"badge text-bg-primary\">-つ</span> avec l'ajout de <span class=\"badge text-bg-primary\">-た</span> <span class=\"badge text-bg-success\">ある => あつた</span>"},
                new GrammarRule() { Id = 53, GrammarThemeId = 6, Rule = "Attention <span class=\"badge text-bg-danger\">いく</span> devient <span class=\"badge text-bg-danger\">いつた</span>"},
                new GrammarRule() { Id = 54, GrammarThemeId = 6, Rule = "La forme passée négative"},
                new GrammarRule() { Id = 55, GrammarThemeId = 6, Rule = "Pour tous les verbes on ajoute <span class=\"badge text-bg-primary\">-でした</span> à la forme négative <span class=\"badge text-bg-primary\">-ません</span> <span class=\"badge text-bg-success\">いく => いきません でした</span>"},
                new GrammarRule() { Id = 56, GrammarThemeId = 6, Rule = "Pour tous les verbes on remplace <span class=\"badge text-bg-primary\">-ない</span> par la forme passée <span class=\"badge text-bg-primary\">-なつかた</span> <span class=\"badge text-bg-success\">いく => いかなつかた</span>"},
                new GrammarRule() { Id = 57, GrammarThemeId = 6, Rule = "Particule <span class=\"badge text-bg-primary\">に</span>"},
                new GrammarRule() { Id = 58, GrammarThemeId = 6, Rule = "la particule <span class=\"badge text-bg-primary\">に</span> sert à désigner le destinataire d'une action <span class=\"badge text-bg-success\">そぼ に しやしん を おくりました</span>"},
                new GrammarRule() { Id = 59, GrammarThemeId = 6, Rule = "Particule <span class=\"badge text-bg-primary\">と</span>"},
                new GrammarRule() { Id = 60, GrammarThemeId = 6, Rule = "la particule <span class=\"badge text-bg-primary\">と</span> peut être accompagné de la locution <span class=\"badge text-bg-primary\">いつしょ に </span>, lit. ensemble, avec <span class=\"badge text-bg-success\">ともだち と いしょに いきます</span>"},
            };
            await database.InsertAllAsync(Cour6);

            List<GrammarRule> Cour7 = new List<GrammarRule>()
            {
                new GrammarRule() { Id = 61, GrammarThemeId = 7, Rule = "Les démonstratifs"},
                new GrammarRule() { Id = 62, GrammarThemeId = 7, Rule = "Les démonstratifs spatiaux"},
                new GrammarRule() { Id = 63, GrammarThemeId = 7, Rule = "par ordre de distance <span class=\"badge text-bg-primary\">ここ</span> ici proche <span class=\"badge text-bg-success\">ここ に あります</span> lit. C 'est juste là"},
                new GrammarRule() { Id = 64, GrammarThemeId = 7, Rule = "par ordre de distance <span class=\"badge text-bg-primary\">そこ</span> distance moyenne"},
                new GrammarRule() { Id = 65, GrammarThemeId = 7, Rule = "par ordre de distance <span class=\"badge text-bg-primary\">あそこ</span> éloigné"},
                new GrammarRule() { Id = 66, GrammarThemeId = 7, Rule = "Les démonstratifs (adverbe ça)"},
                new GrammarRule() { Id = 67, GrammarThemeId = 7, Rule = "par ordre de distance <span class=\"badge text-bg-primary\">これ</span> ici proche <span class=\"badge text-bg-success\">これ は ください</span> lit. Celui là (proche) s'il vous plait"},
                new GrammarRule() { Id = 68, GrammarThemeId = 7, Rule = "par ordre de distance <span class=\"badge text-bg-primary\">それ</span> distance moyenne"},
                new GrammarRule() { Id = 69, GrammarThemeId = 7, Rule = "par ordre de distance <span class=\"badge text-bg-primary\">あれ</span> éloigné"},
                new GrammarRule() { Id = 70, GrammarThemeId = 7, Rule = "Les démonstratifs (adjectif)"},
                new GrammarRule() { Id = 71, GrammarThemeId = 7, Rule = "par ordre de distance <span class=\"badge text-bg-primary\">この</span> ici proche <span class=\"badge text-bg-success\">この へや で べんきょう します</span> lit. J'étudie dans cette pièce (juste à coté)"},
                new GrammarRule() { Id = 72, GrammarThemeId = 7, Rule = "par ordre de distance <span class=\"badge text-bg-primary\">その</span> distance moyenne"},
                new GrammarRule() { Id = 73, GrammarThemeId = 7, Rule = "par ordre de distance <span class=\"badge text-bg-primary\">あの</span> éloigné"},
            };
            await database.InsertAllAsync(Cour7);

            List<GrammarRule> Cour8 = new List<GrammarRule>()
            {
                new GrammarRule() { Id = 74, GrammarThemeId = 8, Rule = "La particule <span class=\"badge text-bg-primary\">だ</span>"},
                new GrammarRule() { Id = 75, GrammarThemeId = 8, Rule = "<span class=\"badge text-bg-primary\">だ</span> peut remplacer <span class=\"badge text-bg-primary\">です</span> <span class=\"badge text-bg-success\">フランス の ざつち だ</span>"},
                new GrammarRule() { Id = 76, GrammarThemeId = 8, Rule = "Présent affirmatif <span class=\"badge text-bg-primary\">だ / です</span> Fam. <span class=\"badge text-bg-primary\">です</span> Gen."},
                new GrammarRule() { Id = 77, GrammarThemeId = 8, Rule = "Présent négatif <span class=\"badge text-bg-primary\">で は ない</span> Fam. <span class=\"badge text-bg-primary\">で は ありません</span> Gen."},
                new GrammarRule() { Id = 78, GrammarThemeId = 8, Rule = "Passé affirmatif <span class=\"badge text-bg-primary\">だつた</span> Fam. <span class=\"badge text-bg-primary\">でした</span> Gen."},
                new GrammarRule() { Id = 79, GrammarThemeId = 8, Rule = "Passé négatif <span class=\"badge text-bg-primary\">で は なかつた</span> Fam. <span class=\"badge text-bg-primary\">で は ありません でした</span> Gen."},
                new GrammarRule() { Id = 80, GrammarThemeId = 8, Rule = "La particule <span class=\"badge text-bg-primary\">は</span>"},
                new GrammarRule() { Id = 81, GrammarThemeId = 8, Rule = "Toujours en tête de phrase"},
                new GrammarRule() { Id = 82, GrammarThemeId = 8, Rule = "Utilisé pour parler d'une chose connu de tous les interlocuteurs"},
                new GrammarRule() { Id = 83, GrammarThemeId = 8, Rule = "Sujet de la phrase en l'abscence de <span class=\"badge text-bg-primary\">が</span>"},
                new GrammarRule() { Id = 84, GrammarThemeId = 8, Rule = "Sinon thème principal de la phrase"},
                new GrammarRule() { Id = 85, GrammarThemeId = 8, Rule = "Si utilisé avec d'autres particules sauf <span class=\"badge text-bg-danger\">が</span> et <span class=\"badge text-bg-danger\">を</span> marque une oppostion"},
                new GrammarRule() { Id = 86, GrammarThemeId = 8, Rule = "Ex.<span class=\"badge text-bg-success\">ともだち と ょく でんわ で はなします</span> => je parle bcp avec mes amis au tèl"},
                new GrammarRule() { Id = 87, GrammarThemeId = 8, Rule = "Ex.<span class=\"badge text-bg-success\">ともだち と は ょく でんわ で はなします</span> => je parle bcp avec mes amis au tèl (sous entendu pas les autres)"},
                new GrammarRule() { Id = 88, GrammarThemeId = 8, Rule = "La particule <span class=\"badge text-bg-primary\">も</span>"},
                new GrammarRule() { Id = 89, GrammarThemeId = 8, Rule = "Remplace <span class=\"badge text-bg-primary\">は</span> <span class=\"badge text-bg-primary\">が</span> <span class=\"badge text-bg-primary\">を</span>"},
                new GrammarRule() { Id = 90, GrammarThemeId = 8, Rule = "Si la seconde phrase est parallèle à la première"},
                new GrammarRule() { Id = 91, GrammarThemeId = 8, Rule = "Ex.<span class=\"badge text-bg-success\">まいあさ コーヒー を のみます. ジユース も のみます</span>"},
            };
            await database.InsertAllAsync(Cour8);

            List<GrammarRule> Cour9 = new List<GrammarRule>()
            {
                new GrammarRule() { Id = 92, GrammarThemeId = 9, Rule = "Les adjectifs"},
                new GrammarRule() { Id = 93, GrammarThemeId = 9, Rule = "Adjectifs de la 1er cat. finnissent en <span class=\"badge text-bg-primary\">-い</span> qui suit toujours une voyelle"},
                new GrammarRule() { Id = 94, GrammarThemeId = 9, Rule = "on les fait suivre de <span class=\"badge text-bg-primary\">です</span> ou simplement tel quel en forme Fam. <span class=\"badge text-bg-success\">おいしい / おいしい です</span>"},
                new GrammarRule() { Id = 95, GrammarThemeId = 9, Rule = "La forme <span class=\"badge text-bg-primary\">-く</span>"},
                new GrammarRule() { Id = 96, GrammarThemeId = 9, Rule = "on remplace le <span class=\"badge text-bg-primary\">-い</span> par <span class=\"badge text-bg-primary\">-く</span>"},
                new GrammarRule() { Id = 97, GrammarThemeId = 9, Rule = "<span class=\"badge text-bg-success\">おいしい => おいしく</span>"},
                new GrammarRule() { Id = 98, GrammarThemeId = 9, Rule = "Attention <span class=\"badge text-bg-danger\">いい => ょく</span>"},
                new GrammarRule() { Id = 99, GrammarThemeId = 9, Rule = "La forme négative se construit a partir de la forme <span class=\"badge text-bg-primary\">-く</span>"},
                new GrammarRule() { Id = 100, GrammarThemeId = 9, Rule = "<span class=\"badge text-bg-success\">おいしい => おいしくない / おいしく ありません</span>"},
                new GrammarRule() { Id = 101, GrammarThemeId = 9, Rule = "La forme passée se construit a partir de la forme <span class=\"badge text-bg-primary\">-く</span> avec l'ajout de <span class=\"badge text-bg-primary\">-あつた</span>"},
                new GrammarRule() { Id = 102, GrammarThemeId = 9, Rule = "ATTENTION <span class=\"badge text-bg-danger\">う + あ => あ</span> donc <span class=\"badge text-bg-danger\">く + あつた => かつた</span>"},
                new GrammarRule() { Id = 103, GrammarThemeId = 9, Rule = "<span class=\"badge text-bg-success\">たのしい => たのしかつた</span>"},
                new GrammarRule() { Id = 104, GrammarThemeId = 9, Rule = "Rajouter <span class=\"badge text-bg-primary\">-です</span> pour la forme polie"},
                new GrammarRule() { Id = 105, GrammarThemeId = 9, Rule = "<span class=\"badge text-bg-success\">たのしかつた です</span>"},
                new GrammarRule() { Id = 106, GrammarThemeId = 9, Rule = "Pour la forme passée négative jouer avec <span class=\"badge text-bg-primary\">なかつた</span> et <span class=\"badge text-bg-primary\">なかつた です</span>"},
                new GrammarRule() { Id = 107, GrammarThemeId = 9, Rule = "Peut aussi être épithète d'un nom, dans ce cas se place devant le nom sans forme particulière"},
                new GrammarRule() { Id = 108, GrammarThemeId = 9, Rule = "<span class=\"badge text-bg-success\">おもしろい ほん</span>"},
                new GrammarRule() { Id = 109, GrammarThemeId = 9, Rule = "si on emploie plusieurs Adj. pour le m^me mot le premier se met à la forme <span class=\"badge text-bg-primary\">-くて</span> et la négation est <span class=\"badge text-bg-primary\">-なくて</span>"},
                new GrammarRule() { Id = 110, GrammarThemeId = 9, Rule = "<span class=\"badge text-bg-success\">おおきくて くらい へや</span>"},
            };
            await database.InsertAllAsync(Cour9);

            List<GrammarRule> Cour10 = new List<GrammarRule>()
            {
                new GrammarRule() { Id = 111, GrammarThemeId = 10, Rule = "Les adjectifs (2)"},
                new GrammarRule() { Id = 112, GrammarThemeId = 10, Rule = "Adjectifs de la 2er cat. sont invariable, fonctionnent comme des noms"},
                new GrammarRule() { Id = 113, GrammarThemeId = 10, Rule = "Suivis de <span class=\"badge text-bg-primary\">だ</span> ou <span class=\"badge text-bg-primary\">です</span>"},
                new GrammarRule() { Id = 114, GrammarThemeId = 10, Rule = "<span class=\"badge text-bg-success\">きれい だ / きれい です</span>"},
                new GrammarRule() { Id = 115, GrammarThemeId = 10, Rule = "Pour la négation au présent on la construit avec <span class=\"badge text-bg-primary\">で は ない</span> <span class=\"badge text-bg-primary\">で は ありません</span>"},
                new GrammarRule() { Id = 116, GrammarThemeId = 10, Rule = "<span class=\"badge text-bg-success\">きれい で は ない</span> <span class=\"badge text-bg-success\">きれい で は ありません</span>"},
                new GrammarRule() { Id = 117, GrammarThemeId = 10, Rule = "La forme passé se construit avec <span class=\"badge text-bg-primary\">だつた</span> <span class=\"badge text-bg-primary\">でした</span>"},
                new GrammarRule() { Id = 118, GrammarThemeId = 10, Rule = "<span class=\"badge text-bg-success\">きれい だつた / きれい でした</span>"},
                new GrammarRule() { Id = 119, GrammarThemeId = 10, Rule = "Pour la négation au passé on utilise <span class=\"badge text-bg-primary\">で は なかつた</span> <span class=\"badge text-bg-primary\">で は ありません でした</span>"},
                new GrammarRule() { Id = 120, GrammarThemeId = 10, Rule = "<span class=\"badge text-bg-success\">きれい で は なかつた</span> <span class=\"badge text-bg-success\">きれい で は ありません でした</span>"},
                new GrammarRule() { Id = 121, GrammarThemeId = 10, Rule = "Peut aussi être épithète d'un nom, dans ce cas se place devant le nom et on ajoute la particule <span class=\"badge text-bg-primary\">な</span>"},
                new GrammarRule() { Id = 122, GrammarThemeId = 10, Rule = "<span class=\"badge text-bg-success\">きれい な はな</span>"},
                new GrammarRule() { Id = 123, GrammarThemeId = 10, Rule = "Si deux adjectifs se suivent et que le premier est invariable il est suivis de <span class=\"badge text-bg-primary\">で</span>"},
                new GrammarRule() { Id = 124, GrammarThemeId = 10, Rule = "<span class=\"badge text-bg-success\">ゆうめい で おいし レストラン です</span>"},
                new GrammarRule() { Id = 125, GrammarThemeId = 10, Rule = "Le verbe Devenir <span class=\"badge text-bg-primary\">なる</span>"},
                new GrammarRule() { Id = 126, GrammarThemeId = 10, Rule = "Si il suit un nom ou un adjectif invariable il est relié par <span class=\"badge text-bg-primary\">に</span>"},
                new GrammarRule() { Id = 127, GrammarThemeId = 10, Rule = "<span class=\"badge text-bg-success\">きれい な まち に なりました</span>"},
                new GrammarRule() { Id = 128, GrammarThemeId = 10, Rule = "<span class=\"badge text-bg-success\">ゆうめい に なつた</span>"},
                new GrammarRule() { Id = 129, GrammarThemeId = 10, Rule = "Si il suit un nom ou un adjectif en <span class=\"badge text-bg-primary\">い</span> il faut le mettre à la forme <span class=\"badge text-bg-primary\">く</span>"},
                new GrammarRule() { Id = 130, GrammarThemeId = 10, Rule = "<span class=\"badge text-bg-success\">くらく なる</span>"},
                new GrammarRule() { Id = 131, GrammarThemeId = 10, Rule = "Les notion d'aimer et détester se construisent avec des adjectifs <span class=\"badge text-bg-primary\">すき</span> et <span class=\"badge text-bg-primary\">きらい</span>"},
                new GrammarRule() { Id = 132, GrammarThemeId = 10, Rule = "si on parle d'un objet on le relie par <span class=\"badge text-bg-primary\">が</span> et si c 'est une personne <span class=\"badge text-bg-primary\">は</span>"},
                new GrammarRule() { Id = 133, GrammarThemeId = 10, Rule = "<span class=\"badge text-bg-success\">やまさきさん は ぶんがく が だいすき です</span>"},
                new GrammarRule() { Id = 134, GrammarThemeId = 10, Rule = "D'autres adjectifs ont la même construction"},
                new GrammarRule() { Id = 135, GrammarThemeId = 10, Rule = "<span class=\"badge text-bg-primary\">ほしい</span> qui exprime le désir par exemple"},
                new GrammarRule() { Id = 136, GrammarThemeId = 10, Rule = "<span class=\"badge text-bg-success\">にほん の くるま が ほしい</span>"},
                new GrammarRule() { Id = 137, GrammarThemeId = 10, Rule = "<span class=\"badge text-bg-primary\">じょうず</span> pour dire qu'on est bon dans qqch"},
                new GrammarRule() { Id = 138, GrammarThemeId = 10, Rule = "<span class=\"badge text-bg-success\">わたし は えいご が じょうず です</span>"},
                new GrammarRule() { Id = 139, GrammarThemeId = 10, Rule = "<span class=\"badge text-bg-primary\">へた</span> pour dire l'inverse"},
                new GrammarRule() { Id = 140, GrammarThemeId = 10, Rule = "<span class=\"badge text-bg-success\">わたし は にほんご が へた です</span>"},
            };
            await database.InsertAllAsync(Cour10);

            List<GrammarRule> Cour11 = new List<GrammarRule>()
            {
                new GrammarRule() { Id = 141, GrammarThemeId = 11, Rule = "La forme en <span class=\"badge text-bg-primary\">-て</span>"},
                new GrammarRule() { Id = 142, GrammarThemeId = 11, Rule = "Se construit comme la fomre passée"},
                new GrammarRule() { Id = 143, GrammarThemeId = 11, Rule = "Verbes Simples <span class=\"badge text-bg-primary\">-て</span> s'ajoute au radical"},
                new GrammarRule() { Id = 144, GrammarThemeId = 11, Rule = "<span class=\"badge text-bg-success\">みる => みて</span>"},
                new GrammarRule() { Id = 145, GrammarThemeId = 11, Rule = "<span class=\"badge text-bg-success\">する => して</span>"},
                new GrammarRule() { Id = 146, GrammarThemeId = 11, Rule = "Pour les autres "},
                new GrammarRule() { Id = 147, GrammarThemeId = 11, Rule = "<span class=\"badge text-bg-primary\">-す</span> => <span class=\"badge text-bg-primary\">-して</span>"},
                new GrammarRule() { Id = 148, GrammarThemeId = 11, Rule = "<span class=\"badge text-bg-success\">はなす => はなして</span>"},
                new GrammarRule() { Id = 149, GrammarThemeId = 11, Rule = "<span class=\"badge text-bg-primary\">-く</span> => <span class=\"badge text-bg-primary\">-いて</span>"},
                new GrammarRule() { Id = 150, GrammarThemeId = 11, Rule = "<span class=\"badge text-bg-success\">まねく => まねいて</span>"},
                new GrammarRule() { Id = 151, GrammarThemeId = 11, Rule = "<span class=\"badge text-bg-danger\">いく => いつて</span>"},
                new GrammarRule() { Id = 152, GrammarThemeId = 11, Rule = "<span class=\"badge text-bg-primary\">-ぐ</span> => <span class=\"badge text-bg-primary\">-いで</span>"},
                new GrammarRule() { Id = 153, GrammarThemeId = 11, Rule = "<span class=\"badge text-bg-success\">いそぐ => いすいで</span>"},
                new GrammarRule() { Id = 154, GrammarThemeId = 11, Rule = "<span class=\"badge text-bg-primary\">-む</span> <span class=\"badge text-bg-primary\">-ぬ</span> <span class=\"badge text-bg-primary\">-ぶ</span> => <span class=\"badge text-bg-primary\">-んで</span>"},
                new GrammarRule() { Id = 155, GrammarThemeId = 11, Rule = "<span class=\"badge text-bg-success\">ょぶ => ょんで</span>"},
                new GrammarRule() { Id = 156, GrammarThemeId = 11, Rule = "<span class=\"badge text-bg-primary\">-う</span> <span class=\"badge text-bg-primary\">-つ</span> <span class=\"badge text-bg-primary\">-る</span> => <span class=\"badge text-bg-primary\">-つて</span>"},
                new GrammarRule() { Id = 157, GrammarThemeId = 11, Rule = "<span class=\"badge text-bg-success\">ある => あつて</span>"},
                new GrammarRule() { Id = 158, GrammarThemeId = 11, Rule = "Combiné avec le verbe <span class=\"badge text-bg-primary\">いる</span> peut exprimé une durée"},
                new GrammarRule() { Id = 159, GrammarThemeId = 11, Rule = "- 1 durée limitée, l'action est en train de se faire"},
                new GrammarRule() { Id = 160, GrammarThemeId = 11, Rule = "<span class=\"badge text-bg-success\">こども は いま にわ で あそんで います</span>"},
                new GrammarRule() { Id = 161, GrammarThemeId = 11, Rule = "En ce moment les enfants sont en train de jouer dans le jardin"},
                new GrammarRule() { Id = 162, GrammarThemeId = 11, Rule = "- 2 durée longue, une action qui se répète régulièrement, une situation habituelle"},
                new GrammarRule() { Id = 163, GrammarThemeId = 11, Rule = "<span class=\"badge text-bg-success\">わたし は Grenoble に すんで います</span>"},
                new GrammarRule() { Id = 164, GrammarThemeId = 11, Rule = "J'habite à grenoble"},
                new GrammarRule() { Id = 165, GrammarThemeId = 11, Rule = "- 3 avec les verbes qui ne peuvent pas durer exprime le résultat de l'action"},
                new GrammarRule() { Id = 166, GrammarThemeId = 11, Rule = "<span class=\"badge text-bg-success\">くるま とまつて いる</span>"},
                new GrammarRule() { Id = 167, GrammarThemeId = 11, Rule = "la voiture est arretée"},
            };
            await database.InsertAllAsync(Cour11);

            List<GrammarRule> Cour12 = new List<GrammarRule>()
            {
                new GrammarRule() { Id = 168, GrammarThemeId = 12, Rule = "Un chiffre devant une unitée la multiplie"},
                new GrammarRule() { Id = 169, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-success\">三十 = 30</span>"},
                new GrammarRule() { Id = 170, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-danger\">三百 = sanbyaku</span>"},
                new GrammarRule() { Id = 171, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-danger\">六百 = roppyaku</span>"},
                new GrammarRule() { Id = 172, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-danger\">八百 = happyyaku</span>"},
                new GrammarRule() { Id = 173, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-danger\">三千 = sanzen</span>"},
                new GrammarRule() { Id = 174, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-danger\">八千 = hassen</span>"},
                new GrammarRule() { Id = 175, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-danger\">万 = ichiman</span>"},
                new GrammarRule() { Id = 176, GrammarThemeId = 12, Rule = "Un chiffre après une unitée s'additionne"},
                new GrammarRule() { Id = 177, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-success\">十三 = 13</span>"},
                new GrammarRule() { Id = 178, GrammarThemeId = 12, Rule = "Pour les opérations on construit une phrase comme suit"},
                new GrammarRule() { Id = 179, GrammarThemeId = 12, Rule = "Chiffre Verbe Chiffre <span class=\"badge text-bg-primary\">は</span> resultat <span class=\"badge text-bg-primary\">です / に なります</span>"},
                new GrammarRule() { Id = 180, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-success\">40 ひく 8 は 32 です / に なります</span>"},
                new GrammarRule() { Id = 181, GrammarThemeId = 12, Rule = "Tout ce qui spécifie le nombre se place après"},
                new GrammarRule() { Id = 182, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-success\">三十八 ユーロ</span>"},
                new GrammarRule() { Id = 183, GrammarThemeId = 12, Rule = "Ajustements phonétiques our les classificateurs"},
                new GrammarRule() { Id = 184, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-success\">ほん => ぽん</span> pour 1, 6, 8, 10"},
                new GrammarRule() { Id = 185, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-danger\">いつぽん</span>"},
                new GrammarRule() { Id = 186, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-danger\">ろつぽん</span>"},
                new GrammarRule() { Id = 187, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-danger\">はつぽん</span>"},
                new GrammarRule() { Id = 189, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-danger\">じゆつぽん</span>"},
                new GrammarRule() { Id = 190, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-success\">ほん => ぼん</span> pour 3"},
                new GrammarRule() { Id = 191, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-danger\">さんぼん</span>"},
                new GrammarRule() { Id = 192, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-success\">こ</span> pour 1, 6, 8, 10"},
                new GrammarRule() { Id = 193, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-danger\">いつこ</span>"},
                new GrammarRule() { Id = 194, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-danger\">ろつこ</span>"},
                new GrammarRule() { Id = 195, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-danger\">はつこ</span>"},
                new GrammarRule() { Id = 196, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-danger\">じゆつこ</span>"},
                new GrammarRule() { Id = 197, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-success\">さつ</span> pour 1, 8, 10"},
                new GrammarRule() { Id = 198, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-danger\">いつさつ</span>"},
                new GrammarRule() { Id = 199, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-danger\">はつさつ</span>"},
                new GrammarRule() { Id = 200, GrammarThemeId = 12, Rule = "<span class=\"badge text-bg-danger\">じゆつさつ</span>"},
            };
            await database.InsertAllAsync(Cour12);

            List<GrammarRule> Cour13 = new List<GrammarRule>()
            {
                new GrammarRule() { Id = 201, GrammarThemeId = 13, Rule = "Compter les personnes, une ou deux utiliser le système japonais"},
                new GrammarRule() { Id = 202, GrammarThemeId = 13, Rule = "<span class=\"badge text-bg-success\">ひとり => 1, ふたり => 2</span>"},
                new GrammarRule() { Id = 203, GrammarThemeId = 13, Rule = "à partir de 3 utiliser le système chinois suivis de <span class=\"badge text-bg-primary\">にん</span>"},
                new GrammarRule() { Id = 204, GrammarThemeId = 13, Rule = "<span class=\"badge text-bg-success\">八にん</span> 8 personnes"},
                new GrammarRule() { Id = 205, GrammarThemeId = 13, Rule = "<span class=\"badge text-bg-danger\">四にん => yonin</span>"},
                new GrammarRule() { Id = 206, GrammarThemeId = 13, Rule = "Quand on compte dans une phrase les objets comptés sont suivis de <span class=\"badge text-bg-primary\">が</span> ou <span class=\"badge text-bg-primary\">を</span>"},
                new GrammarRule() { Id = 207, GrammarThemeId = 13, Rule = "<span class=\"badge text-bg-success\">わたし の にわ に は き が ろつぽん あります</span>"},
                new GrammarRule() { Id = 208, GrammarThemeId = 13, Rule = "Question avec <span class=\"badge text-bg-primary\">いくつ</span> Combien (d'objets) ou <span class=\"badge text-bg-primary\">なんにん</span> Combien (de personnes)"},
                new GrammarRule() { Id = 209, GrammarThemeId = 13, Rule = "<span class=\"badge text-bg-success\">りんご を いくつ たべました か</span> => <span class=\"badge text-bg-success\">りんご を 一つ たべました</span>"},
                new GrammarRule() { Id = 210, GrammarThemeId = 13, Rule = "Quand le mot compté est suivis de <span class=\"badge text-bg-primary\">に, で, から, と, の</span> l'expression chiffré est placé devant lui est reliée par <span class=\"badge text-bg-primary\">の</span>"},
                new GrammarRule() { Id = 211, GrammarThemeId = 13, Rule = "<span class=\"badge text-bg-success\">三にん の こども と こうえん で あそんで います</span>"},
                new GrammarRule() { Id = 212, GrammarThemeId = 13, Rule = "Le verbe <span class=\"badge text-bg-primary\">くる</span> faire est irrégulier"},
                new GrammarRule() { Id = 213, GrammarThemeId = 13, Rule = "<span class=\"badge text-bg-danger\">きます</span> <span class=\"badge text-bg-danger\">きません</span> <span class=\"badge text-bg-danger\">きました</span> <span class=\"badge text-bg-danger\">きた</span> <span class=\"badge text-bg-danger\">きて</span>  <span class=\"badge text-bg-danger\">こない</span>"},
                new GrammarRule() { Id = 214, GrammarThemeId = 13, Rule = "La particule <span class=\"badge text-bg-primary\">と</span> sert aussi à faire une énumération"},
                new GrammarRule() { Id = 215, GrammarThemeId = 13, Rule = "<span class=\"badge text-bg-success\">ばんごはん に ハム と チズ と パン を たつた</span>"},
                new GrammarRule() { Id = 216, GrammarThemeId = 13, Rule = "Si les objets énumérés sont chiffrés la particule utilisé pour les mots est répétée à chaque fois"},
                new GrammarRule() { Id = 217, GrammarThemeId = 13, Rule = "<span class=\"badge text-bg-success\">うちむらさん は けしごむ を 三こ と えんぴつ を 四ほん かつた</span>"},
            };
            await database.InsertAllAsync(Cour13);
            return true;
        }
    }
}
