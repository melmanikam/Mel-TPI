using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Mel_TPI.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Mel_TPIUser class
public class Mel_TPIUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

