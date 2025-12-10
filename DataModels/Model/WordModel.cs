using DataModels.Model.Interface;
using SQLite;

namespace DataModels.Model
{
    public class WordModel : IDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public String Kana { get; set; } = String.Empty;
        public String Japonais { get; set; } = String.Empty;
        public String Romanji { get; set; } = String.Empty;
        public String Francais { get; set; } = String.Empty;
        public String Detail { get; set; } = String.Empty;

        public WordModel()
        {

        }
    }
}
