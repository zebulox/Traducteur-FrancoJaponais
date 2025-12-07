using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Traducteur_FrancoJaponais.Model;
using Traducteur_FrancoJaponais.Model.Interface;

namespace Traducteur_FrancoJaponais.Services.Interface
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
