﻿using Qaarya.WebApi.IdentityInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace Qaarya.WebApi.Models
{
    public class ModelFactory
    {
        private UrlHelper _UrlHelper;
        private ApplicationUserManager _AppUserManager;

        public ModelFactory(HttpRequestMessage request, ApplicationUserManager appUserManager)
        {
            _UrlHelper = new UrlHelper(request);
            _AppUserManager = appUserManager;
        }

        //public UserReturnModel Create(ApplicationUser appUser)
        //{
        //    return new UserReturnModel
        //    {
        //        Url = _UrlHelper.Link("GetUserById", new { id = appUser.Id }),
        //        Id = appUser.Id,
        //        UserName = appUser.UserName,
        //        FullName = string.Format("{0} {1}", appUser.FirstName, appUser.LastName),
        //        Email = appUser.Email,
        //        EmailConfirmed = appUser.EmailConfirmed,
        //        Gender = appUser.Gender,
        //        Level = appUser.Level,
        //        DateofBirth = appUser.DateofBirth,
        //        Roles = _AppUserManager.GetRolesAsync(appUser.Id).Result,
        //        Claims = _AppUserManager.GetClaimsAsync(appUser.Id).Result
        //    };
        //}
    }

    public class UserReturnModel
    {
        public string Url { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        //public string FullName { get; set; }
        //public int Gender { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        //public int Level { get; set; }
        //public DateTime DateofBirth { get; set; }
        public IList<string> Roles { get; set; }
        public IList<System.Security.Claims.Claim> Claims { get; set; }
    }
}