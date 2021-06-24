using System;

namespace MishMash.Data
{
    public class Channel
    {
        //Has an Id – a GUID String or an Integer.
        //Has a Name
        //Has a Description
        //Has a Type – can be one of the following values (“Game”, “Motivation”, “Lessons”, “Radio”, “Other”).
        //Has Tags – a collection of Strings.
        //Has Followers – a collection of Users.

        public Channel()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Type Type { get; set; }
    }
}