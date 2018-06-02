using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qaarya.CommonClasses.ViewModels;
using Qaarya.CommonClasses.ViewModels.CommonViewModels;
using Qaarya.CommonClasses.ViewModels.Profile;

namespace Qaarya.Services.Interfaces
{
    public interface IProfileService
    {
        ProfileVM GetProfileByID(string UserID);
    }
}
