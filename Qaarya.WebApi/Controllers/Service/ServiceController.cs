using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Qaarya.Services.Interfaces;
using Qaarya.Repository.Interfaces;
using Qaarya.CommonClasses.ViewModels;
using Qaarya.Services.Services;

namespace Qaarya.WebApi.Controllers 
{
    //[RoutePrefix("Service")]
    //[Authorize]
    public class ServiceController : ApiController
    {
        private readonly IServiceService _serviceService;
        //public ServiceController()
        //{

        //}

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        //[Route("Index")]
        [HttpGet]
        public List<ServiceVM> Index()
        {
            return _serviceService.GetList();
        }

        [HttpGet]
        public ServiceVM AddService(int ServiceID = 0)
        {
            ServiceVM Data = null;
            if (ServiceID > 0)
            {
               Data = _serviceService.EditService(ServiceID);
            }
            else
            {
               Data = new ServiceVM();
            }

            Data.CategoryList = _serviceService.GetCategories();
            Data.RateTypeList = _serviceService.CollectionType(3); // TypeID = 3 for Rate Type list 
            Data.ServiceAreaRangeList = _serviceService.CollectionType(1); // TypeID = 1 for Service Area Range list 
            Data.ExperienceLevelList = _serviceService.CollectionType(4);  // TypeID = 4 for Experience Level list 
            return Data;
        }

        [HttpGet]
        public List<ServiceVM> GetListDemoDeleted()
        {
            var data = _serviceService.GetList();
            return data;
        }

        [HttpPost]
        public int SaveService(ServiceVM Service)
        {
            //var data = _serviceService.GetList();
            return 0;
        }
    }
}
