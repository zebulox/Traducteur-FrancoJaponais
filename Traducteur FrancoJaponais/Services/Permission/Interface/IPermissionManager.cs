using System;
using System.Collections.Generic;
using System.Text;

namespace Traducteur_FrancoJaponais.Services.Permission.Interface
{
    public interface IPermissionManager
    {
        Task<PermissionStatus> CheckAndRequestCameraPermission();

        Task<PermissionStatus> CheckAndRequestWriteExternalStorage();

        Task<PermissionStatus> CheckAndRequestReadExternalStorage();
    }
}
