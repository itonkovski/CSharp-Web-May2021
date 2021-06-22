using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Git.Data
{
    public class Repository
    {
        //Has an Id – a string, Primary Key
        //Has a Name – a string with min length 3 and max length 10 (required)
        //Has a CreatedOn – a datetime(required)
        //Has a IsPublic – bool (required)
        //Has a OwnerId – a string
        //Has a Owner – a User object
        //Has Commits collection – a Commit type

        public Repository()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Commits = new HashSet<Commit>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsPublic { get; set; }

        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public virtual ICollection<Commit> Commits { get; set; }
    }
}