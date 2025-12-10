using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Traducteur_FrancoJaponais.Services.DataBase.Interface
{
    public interface IDataBaseService
    {
        SQLiteAsyncConnection Getdatabase();
        void backupCoursesOnFileSystem();
        void ReinitCourses();
    }
}
