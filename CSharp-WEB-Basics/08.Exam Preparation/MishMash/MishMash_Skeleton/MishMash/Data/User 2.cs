using System;
using System.Collections.Generic;
using MishMash.Data.Enums;

namespace MishMash.Data
{
    public class User
    {
        //Has an Id – a GUID String or an Integer.
        //Has an Username
        //Has a Password
        //Has an Email
        //Has Followed Channels – a collection of Channels.
        //Has an Role – can be one of the following values (“User”, “Admin”)

        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.FollowedChannels = new HashSet<Channel>();
        }

        public string Id { get; set; }

        public string Username { get; set; }    

        public string Password { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Channel> FollowedChannels { get; set; }

        public Role Role { get; set; }
    }
}
