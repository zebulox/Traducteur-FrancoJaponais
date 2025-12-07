using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Traducteur_FrancoJaponais.Services.Interface
{
    public interface IDataBaseService
    {
        SQLiteAsyncConnection Getdatabase();

        void InitDataOnBase();
        void backupCoursesOnFileSystem();
        void ReinitCourses();
    }
}
