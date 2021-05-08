using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace koichanCore.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the koichanCoreUser class
    public class koichanCoreUser : IdentityUser
    {
        [PersonalData]
        public string UserName { get; set; }
    }
}
