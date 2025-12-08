using System;
using System.Collections.Generic;
using System.Text;

namespace Traducteur_FrancoJaponais.Services.Interface
{
    public interface IPermissionManager
    {
        Task<PermissionStatus> CheckAndRequestCameraPermission();
    }
}
