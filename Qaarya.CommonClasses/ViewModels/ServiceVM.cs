using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qaarya.CommonClasses.ViewModels.CommonViewModels;

namespace Qaarya.CommonClasses.ViewModels
{
    public class ServiceVM
    {

        public long ServiceID { get; set; }
        public String ServiceName { get; set; }
        public String ServiceDescription { get; set; }
        public Nullable<long> CategoryID { get; set; }
        public string SubCategoryID { get; set; }
        public Nullable<long> RateTypeID { get; set; }
        public Nullable<decimal> ServiceRate { get; set; }
        public string LocationLongitude { get; set; }
        public string LocationLatitude { get; set; }
        public Nullable<long> ServiceRangeID { get; set; }
        public Nullable<long> ServiceExperienceLevelID { get; set; }
        public String CategoryName { get; set; }

        /// <summary>
        /// Lists for Dropdowns
        /// </summary>
        public List<DropDownVM> CategoryList { get; set; }
        public List<DropDownVM> RateTypeList { get; set; }
        public List<DropDownVM> ServiceAreaRangeList { get; set; }
        public List<DropDownVM> ExperienceLevelList { get; set; }
    }
}
