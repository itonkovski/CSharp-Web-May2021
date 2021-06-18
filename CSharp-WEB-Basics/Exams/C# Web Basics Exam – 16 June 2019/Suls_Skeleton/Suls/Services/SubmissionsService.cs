using System;
using System.Linq;
using Suls.Data;
using SulsApp.Data;

namespace Suls.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly ApplicationDbContext db;
        private readonly Random random;

        public SubmissionsService(ApplicationDbContext db, Random random)
        {
            this.db = db;
            this.random = random;
        }

        public void Create(string problemId, string userId, string code)
        {
            var problemMaxPoints = this.db.Problems
                .Where(x => x.Id == problemId)
                .Select(x => x.Points)
                .FirstOrDefault();
            var submission = new Submission
            {
                Code = code,
                UserId = userId,
                ProblemId = problemId,
                AcvievedResult = this.random.Next(0, problemMaxPoints + 1),
                CreatedOn = DateTime.UtcNow
            };
            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }
    }
}
