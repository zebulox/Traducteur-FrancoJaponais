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
                GetWordFireAndForget(french);
            }
        }

        private async Task GetWordFireAndForget(French french)
        {
            var frJpAsso = await db.Table<FrenchJapanese>().Where(fj => fj.Fid == french.Id).ToListAsync();

            var japanese = new List<Japanese>();
            foreach (var frjp in frJpAsso)
            {
                japanese.Add(await db.Table<Japanese>().Where(j => j.Id == frjp.Jid).FirstOrDefaultAsync());
            }

            var jpTagasso = new List<JapaneseTag>();
            foreach (var jp in japanese)
            {
                jpTagasso.Add(await db.Table<JapaneseTag>().Where(j => j.Jid == jp.Id).FirstOrDefaultAsync());
            }

            var tag = new List<Tag>();
            foreach (var jptag in jpTagasso)
            {
                tag.Add(await db.Table<Tag>().Where(t => t.Id == jptag.Tid).FirstOrDefaultAsync());
            }

            FromFrenchResults.Add(
                new DicoDisplayFrenchWord() 
                { 
                    Id = french.Id,
                    French = french.Value,
                    Japaneses = japanese.Select(j => j.Value).ToList(),
                    Tags = tag.Select(j => j.Value).ToList()
                }
            );
        }

        private async Task<List<French>> GetFrenchFromQuery(string query)
        {
            return await db.Table<French>().Where(f => f.Value.Contains(query)).ToListAsync();
        }
    }
}
