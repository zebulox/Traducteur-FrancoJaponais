using DataModels.Model.Interface;
using SQLite;

namespace DataModels.Model
{
    public class HiromiPhrase : IDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int CourseNumber { get; set; }
        public String Japonais { get; set; }
        public String Francais { get; set; }
        public String Explication { get; set; }

        public HiromiPhrase()
        {

        }
    }
}
