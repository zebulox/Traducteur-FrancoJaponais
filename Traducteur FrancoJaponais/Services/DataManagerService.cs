using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Traducteur_FrancoJaponais.Model;
using Traducteur_FrancoJaponais.Model.Interface;
using Traducteur_FrancoJaponais.Services.Interface;

namespace Traducteur_FrancoJaponais.Services
{
    public class DataManagerService<T> : IDataManager<T> where T : IDataModel, new()
    {
        readonly SQLiteAsyncConnection _dataBaseService;
        public DataManagerService(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService.Getdatabase();
        }
        public Task<List<T>> GetAll()
        {
            return _dataBaseService.Table<T>().ToListAsync();
        }

        public Task<List<T>> Get(Expression<Func<T, bool>> expr)
        {
            Func<T, bool> deleg = expr.Compile();
            return _dataBaseService.Table<T>().Where(expr).ToListAsync();
        }

        public SQLiteAsyncConnection returndatabaseservice()
        {
            return this._dataBaseService;
        }

        public Task<int> Insert(T data)
        {
            return _dataBaseService.InsertAsync(data);
        }
    }
}
