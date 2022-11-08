using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TestApplication.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Votes = new HashSet<Vote>();
        }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
