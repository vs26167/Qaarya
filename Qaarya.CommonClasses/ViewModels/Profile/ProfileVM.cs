using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qaarya.CommonClasses.ViewModels.Profile
{
    public class ProfileVM
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }


        public long ProfileID { get; set; }
        public string ProfileFirstName { get; set; }
        public string ProfileLastName { get; set; }
        public Nullable<System.DateTime> ProfileDateofBirth { get; set; }
        public Nullable<long> ProfileGenderID { get; set; }
        public string ProfileAddressLocation { get; set; }
        public string ProfileUserID { get; set; }
        public string ProfileDescription { get; set; }

        public long GenderID { get; set; }
        public string GenderDescription { get; set; }
    }
}
