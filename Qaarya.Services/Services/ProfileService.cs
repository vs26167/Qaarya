using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qaarya.Services.Interfaces;
using Qaarya.Repository.Interfaces;
using Qaarya.CommonClasses.ViewModels;
using Qaarya.CommonClasses.ViewModels.CommonViewModels; 
using Qaarya.CommonClasses.ViewModels.Profile;

namespace Qaarya.Services.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IUserRepository _userRepository;
        private readonly IGenderRepository _genderRepository;
        //public ProfileService()
        //{

        //}
        public ProfileService(
            IProfileRepository profileRepository,
            IUserRepository userRepository,
            IGenderRepository genderRepository
            )
        {
            _profileRepository = profileRepository;
            _userRepository = userRepository;
            _genderRepository = genderRepository;
        }

        /// <summary>
        /// Getting Profile Based on UserID
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public ProfileVM GetProfileByID(string UserID)
        {
            var AspUserData = _userRepository.GetAll().ToList();
            var ProfileData = _profileRepository.GetAll().ToList();
            var GenderData = _genderRepository.GetAll().ToList();

            var ProfileDetailData = (from User in AspUserData
                               join Profile in ProfileData on User.Id equals Profile.ProfileUserID
                               join Gender in GenderData on Profile.ProfileGenderID equals Gender.GenderID
                               where User.Id == UserID && Profile.ProfileDateDeleted == null
                               select new ProfileVM
                               {
                                   Id = User.Id,
                                   ProfileFirstName = Profile.ProfileFirstName,
                                   ProfileLastName = Profile.ProfileLastName,
                                   ProfileGenderID = Gender.GenderID,
                                   GenderDescription = Gender.GenderDescription,
                                   ProfileDateofBirth = Profile.ProfileDateofBirth,
                                   ProfileDescription = Profile.ProfileDescription,
                                   Email = User.Email,
                                   PhoneNumber = User.PhoneNumber,
                                   ProfileAddressLocation = Profile.ProfileAddressLocation
                               }).FirstOrDefault();

            return ProfileDetailData;
        }
    }
}
