using System;
using System.ComponentModel.DataAnnotations;

namespace Suls.Data
{
    public class Submission
    {
        //Has an Id – a string, Primary Key
        //Has Code – a string with min length 30 and max length 800 (required)
        //Has Achieved Result – an integer between 0 and 300 (required)
        //Has a Created On – a DateTime object (required)
        //Has Problem – a Problem object
        //Has User – a User object

        public Submission()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(800)]
        public string Code { get; set; }

        public int AcvievedResult { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ProblemId { get; set; }

        public virtual Problem Problem { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}