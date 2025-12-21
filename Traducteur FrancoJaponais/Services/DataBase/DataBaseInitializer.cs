using DataModels.Model;
using SQLite;
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
            await database.CreateTableAsync<HiromiPhrase>();
            await database.CreateTableAsync<HiromiCourse>();
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
            await InitWordsData();
            return true;
        }

        private async Task InitWordsData()
        {

        }

    }
}
