using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TestApplication.Data.Models
{
    public class User : IdentityUser
    {
        [MaxLength(30)]
        public string FullName { get; set; }
    }
}
