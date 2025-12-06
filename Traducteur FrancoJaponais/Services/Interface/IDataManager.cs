using System;
using System.Collections.Generic;
using System.Text;
using Traducteur_FrancoJaponais.Model;
using Traducteur_FrancoJaponais.Model.Interface;

namespace Traducteur_FrancoJaponais.Services.Interface
{
    public interface IDataManager<T> where T : IDataModel, new()
    {
        Task<int> Insert(T data);

        Task<List<T>> GetAll();
    }
}
