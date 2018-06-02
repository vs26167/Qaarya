using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Qaarya.Services.Interfaces;
using Qaarya.Repository.Interfaces;
using Qaarya.CommonClasses.ViewModels;
using Qaarya.CommonClasses.ViewModels.CommonViewModels;

namespace Qaarya.Services.Services
{

    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryCollectionRepository _categoryCollectionRepository;
        //public ServiceService()
        //{

        //}
        public ServiceService(
            IServiceRepository serviceRepository,
            ICategoryRepository categoryRepository,
            ICategoryCollectionRepository categoryCollectionRepository
            )
        {
            _serviceRepository = serviceRepository;
            _categoryRepository = categoryRepository;
            _categoryCollectionRepository = categoryCollectionRepository;
        }

        /// <summary>
        /// To get the List of all the Services as per the Location and Category 
        /// </summary>
        /// <returns></returns>
        public List<ServiceVM> GetList()
        {
            var ServiceData = _serviceRepository.GetAll().ToList();
            var CategoryData = _categoryRepository.GetAll().ToList();

            var ServiceList = (from Service in ServiceData
                        join Category in CategoryData on Service.ServiceCategoryID equals Category.CategoryID
                        where Service.ServiceDateDeleted == null
                        select new ServiceVM
                        {
                            ServiceID = Service.ServiceID,
                            ServiceName = Service.ServiceName,
                            ServiceDescription = Service.ServiceDescription,
                            //ServicePincode = Service.ServiceLocationPincode,
                            ServiceRate = Service.ServiceRate,
                            CategoryID = Service.ServiceCategoryID,
                            CategoryName = Category.CategoryName
                        }).ToList();
            return ServiceList;
        }

        /// <summary>
        /// To get the List of all the Services as per the Location and Category 
        /// </summary>
        /// <returns></returns>
        public List<ServiceVM> GetListDemoDeleted()
        {
            var ServiceData = _serviceRepository.GetAll().ToList();
            var CategoryData = _categoryRepository.GetAll().ToList();

            var ServiceList = (from Service in ServiceData
                               join Category in CategoryData on Service.ServiceCategoryID equals Category.CategoryID
                               where Service.ServiceDateDeleted == null
                               select new ServiceVM
                               {
                                   ServiceID = Service.ServiceID,
                                   ServiceName = Service.ServiceName,
                                   ServiceDescription = Service.ServiceDescription,
                                   //ServicePincode = Service.ServiceLocationPincode,
                                   ServiceRate = Service.ServiceRate,
                                   CategoryID = Service.ServiceCategoryID,
                                   CategoryName = Category.CategoryName
                               }).ToList();
            return ServiceList;
        }

        /// <summary>
        /// Getting Service Based on ID
        /// </summary>
        /// <param name="ServiceID"></param>
        /// <returns></returns>
        public ServiceVM GetServiceByID(int ServiceID)
        {
            var ServiceData = _serviceRepository.GetAll().ToList();
            var CategoryData = _categoryRepository.GetAll().ToList();

            var ServiceByID = (from Service in ServiceData
                        join Category in CategoryData on Service.ServiceCategoryID equals Category.CategoryID
                        where Service.ServiceID == ServiceID && Service.ServiceDateDeleted == null
                        select new ServiceVM
                        {
                            ServiceID = Service.ServiceID,
                            ServiceName = Service.ServiceName,
                            ServiceDescription = Service.ServiceDescription,
                            //ServicePincode = Service.ServiceLocationPincode,
                            ServiceRate = Service.ServiceRate,
                            CategoryID = Service.ServiceCategoryID,
                            CategoryName = Category.CategoryName
                        }).FirstOrDefault();

            return ServiceByID;
        }

        /// <summary>
        /// For Edit Screen of Service
        /// </summary>
        /// <param name="ServiceID">Long Parameter</param>
        /// <returns>View Model Service</returns>
        public ServiceVM EditService(int ServiceID)
        {
            ServiceVM ObjServiceByID = _serviceRepository.FindBy(x=>x.ServiceID == ServiceID && x.ServiceDateDeleted == null).Select( x=> new ServiceVM
                               {
                                   ServiceID = x.ServiceID,
                                   ServiceName = x.ServiceName,
                                   ServiceDescription = x.ServiceDescription,
                                   CategoryID = x.ServiceCategoryID,
                                   SubCategoryID = x.ServiceSubCategoryID,
                                   RateTypeID = x.ServicePaymentTypeID,
                                   ServiceRate = x.ServiceRate,
                                   LocationLongitude = x.ServiceLocationLongitude,
                                   LocationLatitude = x.ServiceLocationLatitude,
                                   ServiceRangeID = x.ServiceAreaRangeID,
                                   ServiceExperienceLevelID = x.ServiceExperienceLevelID
                               }).FirstOrDefault();            
            return ObjServiceByID;
        }

        /// <summary>
        /// To Get the Categories List.
        /// </summary>
        /// <returns></returns>
        public List<DropDownVM> GetCategories()
        {
            List<DropDownVM> CategoryList = _categoryRepository.GetAll().Select(x => new DropDownVM
            {
                Value = x.CategoryID,
                Text = x.CategoryName
            }).ToList();

            return CategoryList;
        }

        /// <summary>
        /// To Get the Categories List.
        /// </summary>
        /// <returns></returns>
        public List<DropDownVM> CollectionType(int CollectionTypeID)
        {
            List<DropDownVM> CollectionTypeList = _categoryCollectionRepository.GetAll().Where(x => x.CategoryCollectionTypeID == CollectionTypeID).Select(x => new DropDownVM
            {
                Value = x.CategoryCollectionValue,
                Text = x.CategoryCollectionName
            }).ToList();

            return CollectionTypeList;
        }

    }
}
