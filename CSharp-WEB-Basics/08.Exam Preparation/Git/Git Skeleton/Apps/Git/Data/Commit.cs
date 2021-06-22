using System;
using System.ComponentModel.DataAnnotations;

namespace Git.Data
{
    public class Commit
    {
        //Has an Id – a string, Primary Key
        //Has a Description – a string with min length 5(required)
        //Has a CreatedOn – a datetime(required)
        //Has a CreatorId – a string
        //Has Creator – a User object
        //Has RepositoryId – a string
        //Has Repository– a Repository object

        public Commit()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public string RepositoryId { get; set; }

        public virtual Repository Repository { get; set; }
    }
}