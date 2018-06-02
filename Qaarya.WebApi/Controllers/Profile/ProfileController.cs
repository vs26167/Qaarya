using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Qaarya.CommonClasses.ViewModels.Profile;
using Qaarya.Services.Interfaces;

namespace Qaarya.WebApi.Controllers
{
    [Authorize]
    public class ProfileController : ApiController
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public ProfileVM GetProfileInformation(string UserID)
        {
            return _profileService.GetProfileByID(UserID);
        }
    }
}
