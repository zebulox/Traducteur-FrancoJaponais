using DataModels.DisplayModels;
using DataModels.Model.Dictionary;
using SQLite;
using System.Collections.ObjectModel;
using Traducteur_FrancoJaponais.Services.DataBase.Interface;

namespace Traducteur_FrancoJaponais.Services
{
    public class DictionaryService : IDictionaryService
    {
        public ObservableCollection<DicoDisplayFrenchWord> FromFrenchResults { get; set; }
        private ISQLiteAsyncConnection db;
        public DictionaryService(IDataBaseService dbConnexion)
        {
            FromFrenchResults = new ObservableCollection<DicoDisplayFrenchWord>();
            db = dbConnexion.Getdatabase();
        }
        public async Task GetFromFrench(string query)
        {
            var AllFrenchMatch = await GetFrenchFromQuery(query);
            foreach (var french in AllFrenchMatch)
            {
                await GetWordFromFrenchFireAndForget(french);
            }
        }


        //doublons pris en flag sur la recherche, les Ids sont différents pour la base?
        public async Task GetFromJapanese(string query)
        {
            var AllJapaneseMatch = await GetJapaneseFromQuery(query);
            foreach (var japanese in AllJapaneseMatch)
            {
                await GetWordFromJapaneseFireAndForget(japanese);
            }
        }

        public async Task GetFromTag(string query)
        {
            if (query == null)
                return;
            var tag = await GetTag(query.ToLower());
            var jpTagAsoc = await GetJapaneseAssocFromTag(tag.Id);

            foreach (var jpTag in jpTagAsoc)
            {
                await GetWordFromJpTgAssoc(jpTag);
            }
        }

        private async Task<List<French>> GetFrenchFromQuery(string query)
        {
            return await db.Table<French>().Where(f => f.Value.Contains(query.ToLower())).ToListAsync();
        }

        private async Task GetWordFromFrenchFireAndForget(French french)
        {
            var frJpAsso = await db.Table<FrenchJapanese>().Where(fj => fj.Fid == french.Id).ToListAsync();

            var japanese = new List<Japanese>();
            foreach (var frjp in frJpAsso)
            {
                var results = await db.Table<Japanese>().Where(j => j.Id == frjp.Jid).ToListAsync();
                foreach (var item in results)
                {
                    if (!japanese.Any(j => j.Value1 == item.Value1 && j.Value2 == item.Value2 && j.Value3 == item.Value3))
                    {
                        japanese.Add(item);
                    }
                }
            }

            var jpTagasso = new List<JapaneseTag>();
            foreach (var jp in japanese)
            {
                jpTagasso.AddRange(await db.Table<JapaneseTag>().Where(j => j.Jid == jp.Id).ToListAsync());
            }

            var tag = new List<Tag>();
            foreach (var jptag in jpTagasso)
            {
                var results = await db.Table<Tag>().Where(t => t.Id == jptag.Tid).ToListAsync();
                foreach (var item in results)
                {
                    if (!tag.Any(t => t.Id == item.Id))
                    {
                        tag.Add(item);
                    }
                }
            }

            FromFrenchResults.Add(
                new DicoDisplayFrenchWord() 
                { 
                    Id = french.Id,
                    French = french.Value,
                    Japaneses = japanese.Select(j => j.Value1 + " : " + j.Value2 + " : " + j.Value3).ToList(),
                    Tags = tag.Select(j => j.Value).ToList()
                }
            );
        }

        

        private async Task<List<Japanese>> GetJapaneseFromQuery(string query)
        {
            return await db.Table<Japanese>().Where(f => f.Value3.Contains(query.ToLower()) || f.Value2.Contains(query.ToLower())).ToListAsync();
        }

        private async Task GetWordFromJapaneseFireAndForget(Japanese japanese)
        {
            var frJpAsso = await db.Table<FrenchJapanese>().Where(fj => fj.Jid == japanese.Id).ToListAsync();

            var french = new List<French>();
            foreach (var frjp in frJpAsso)
            {
                var results = await db.Table<French>().Where(f => f.Id == frjp.Fid).ToListAsync();
                foreach (var item in results)
                {
                    if (!french.Any(j => j.Value == item.Value))
                    {
                        french.Add(item);
                    }
                }
            }

            var jpTagasso = new List<JapaneseTag>();
            jpTagasso.AddRange(await db.Table<JapaneseTag>().Where(j => j.Jid == japanese.Id).ToListAsync());
            

            var tag = new List<Tag>();
            foreach (var jptag in jpTagasso)
            {
                var results = await db.Table<Tag>().Where(t => t.Id == jptag.Tid).ToListAsync();
                foreach (var item in results)
                {
                    if (!tag.Any(t => t.Id == item.Id))
                    {
                        tag.Add(item);
                    }
                }
            }

            FromFrenchResults.Add(
                new DicoDisplayFrenchWord()
                {
                    Id = japanese.Id,
                    French = $"{japanese.Value1} : {japanese.Value2} : {japanese.Value3}",
                    Japaneses = french.Select(f => f.Value).ToList(),
                    Tags = tag.Select(j => j.Value).ToList()
                }
            );
            
        }

        private async Task<Tag> GetTag(string query)
        {
            return await db.Table<Tag>().Where(t => t.Value.Equals(query)).FirstOrDefaultAsync();
        }
        private async Task<List<JapaneseTag>> GetJapaneseAssocFromTag(int TagId)
        {
            return await db.Table<JapaneseTag>().Where(t => t.Tid == TagId).ToListAsync();
        }
        private async Task GetWordFromJpTgAssoc(JapaneseTag jpTag)
        {
            var japaneseWord = await db.Table<Japanese>().Where(j => j.Id == jpTag.Jid).FirstOrDefaultAsync();
            String japaneseDisplay = (String.IsNullOrEmpty(japaneseWord.Value3) ? "" : japaneseWord.Value3 + " : ") + japaneseWord.Value2 + " : " + japaneseWord.Value1;
            if (FromFrenchResults.Any(f => f.French == japaneseDisplay))
            {
                return;
            }

            var FrJpAssoc = await db.Table<FrenchJapanese>().Where(fj => fj.Jid == jpTag.Jid).ToListAsync();

            List<French> french = new List<French>();
            foreach (var FrJp in FrJpAssoc)
            {
                var fr = await db.Table<French>().Where(f => f.Id == FrJp.Fid).FirstOrDefaultAsync();
                if (!french.Any(x => x.Value == fr.Value && x.Id == fr.Id))
                {
                    french.Add(fr);
                }
            }

            List<Tag> tags = new List<Tag>();
            List<JapaneseTag> japaneseTags = await db.Table<JapaneseTag>().Where(jt => jt.Jid == japaneseWord.Id).ToListAsync();
            foreach (var jptg in japaneseTags)
            {
                var tag = await db.Table<Tag>().Where(t => t.Id == jptg.Tid).FirstOrDefaultAsync();
                if (!tags.Any(t => t.Value == tag.Value))
                {
                    tags.Add(tag);
                }
            }
            FromFrenchResults.Add(
                new DicoDisplayFrenchWord()
                {
                    Id = japaneseWord.Id,
                    French = japaneseDisplay,
                    Japaneses = french.Select(j => j.Value).ToList(),
                    Tags = tags.Select(j => j.Value).ToList()
                }
            );

        }
    }
}
