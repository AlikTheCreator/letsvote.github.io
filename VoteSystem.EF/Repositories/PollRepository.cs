using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoteSystem.Data.Entities.PollAggregate;
using VoteSystem.Data.Repositories;
using System.Data.Entity;

namespace VoteSystem.EF.Repositories
{
    public class PollRepository : IPollRepository
    {
        public int Create(Poll poll)
        {
            using (var ctx = new VoteContext())
            {
                ctx.Polls.Add(poll);
                ctx.SaveChanges();
                return poll.Id;
            }
        }
        public void CreateChoice(Choice choice)
        {
            using (var ctx = new VoteContext())
            {
                ctx.Polls.Attach(choice.Poll);
                ctx.Entry(choice.Poll).State = System.Data.Entity.EntityState.Unchanged;
                ctx.Choices.Add(choice);
                ctx.SaveChanges();
            }
        }
        public Poll Get(int id)
        {
            using (var ctx = new VoteContext())
                return ctx.Polls.Include(p => p.Choices).FirstOrDefault(p => p.Id == id);
        }
        public Poll Get(string pollName)
        {
            using (var ctx = new VoteContext())
            {
                return ctx.Polls.Include(x => x.Choices).FirstOrDefault(p => p.Name == pollName);
            }
        }
        // this is because you might want to get an ID without the whole aggregate - do it
        public int? GetPollId(string pollName) {

            using (var ctx = new VoteContext())
            {
                return ctx.Polls.FirstOrDefault(p => p.Name == pollName)?.Id;
            }
        }

        public List<Poll> GetPolls()
        {
            using (var ctx = new VoteContext())
            {
                return ctx.Polls.Include(r => r.Choices).ToList();
            }
        }
    }
}
