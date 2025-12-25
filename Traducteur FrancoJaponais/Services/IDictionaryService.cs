using DataModels.DisplayModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Traducteur_FrancoJaponais.Services.DataBase.Interface;

namespace Traducteur_FrancoJaponais.Services
{
    public interface IDictionaryService
    {
        public ObservableCollection<DicoDisplayFrenchWord> FromFrenchResults { get; set; }
        Task GetFromFrench(string query);

    }
}
