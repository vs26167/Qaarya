using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qaarya.CommonClasses.ViewModels;
using Qaarya.CommonClasses.ViewModels.CommonViewModels;

namespace Qaarya.Services.Interfaces
{
    public interface IServiceService
    {
        List<ServiceVM> GetList();
        ServiceVM GetServiceByID(int ServiceID);
        ServiceVM EditService(int ServiceID);
        List<DropDownVM> GetCategories();
        List<DropDownVM> CollectionType(int CollectionTypeID);
    }
}
