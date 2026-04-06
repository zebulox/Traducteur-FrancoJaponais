using System;
using System.Collections.Generic;
using System.Text;

namespace Traducteur_FrancoJaponais.Services.DataBase.Interface
{
    public interface IDataBaseInitializer
    {
        Task<bool> InitDataBaseTables();
        Task<bool> InitCourData();
        //Task<bool> InitDicoData();


        Task<bool> InitFrenchData();
        Task<bool> InitJapaneseData();
        Task<bool> InitTagData();
        Task<bool> InitFrenchJapaneseAssocData();
        Task<bool> InitJapaneseTagAssocData();
    }
}
