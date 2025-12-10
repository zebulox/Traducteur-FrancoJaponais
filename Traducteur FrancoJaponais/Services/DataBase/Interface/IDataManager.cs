using DataModels.Model.Interface;
using SQLite;
using System.Linq.Expressions;

namespace Traducteur_FrancoJaponais.Services.DataBase.Interface
{
    public interface IDataManager<T> where T : IDataModel, new()
    {

        Task<List<T>> GetAll();
        Task<List<T>> Get(Expression<Func<T, bool>> expr);
        Task<T> GetById(int id);
        Task<int> Insert(T data);
        Task<int> Delete(T data);
        SQLiteAsyncConnection returndatabaseservice();

    }
}
