using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Repositories;
using VoteSystem.Data.Entities.VoteAggregate;
using System.Linq;
using System.Data.Entity;

namespace VoteSystem.EF.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        public void Create(Vote vote)
        {
            using (var ctx = new VoteContext())
            {
                ctx.Votes.Add(vote);
                ctx.SaveChanges();
            }
        }
        public void CreateVoteChoice(VoteChoice voteChoice)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                voteContext.Votes.Attach(voteChoice.Vote);
                voteContext.Entry(voteChoice.Vote).State = System.Data.Entity.EntityState.Unchanged;
                voteContext.VoteChoices.Add(voteChoice);
                voteContext.SaveChanges();
            }
        }

        public bool IsVoted(int userId, string pollName)
        {
            using (var ctx = new VoteContext())
            {
                var resp = (from v in ctx.Votes
                            join vc in ctx.VoteChoices on v.Id equals vc.Vote.Id
                            join c in ctx.Choices on vc.choiceId equals c.Id
                            join p in ctx.Polls on c.Poll.Id equals p.Id
                            where v.UserId == userId && p.Name == pollName
                            select new { UserId = v.UserId }).ToList();

                if (resp.Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        public List<Vote> GetAllForUser(int userId)
        {
            using (var ctx = new VoteContext())
            {
                return ctx.Votes.Include(v => v.VoteChoices).Where(u => u.UserId == userId).ToList();
            }
        }
        public Dictionary<string, int> GetResultInPoll(int pollId)
        {
            using (var ctx = new VoteContext())
            {
                Dictionary<string, int> PollResult = new Dictionary<string, int>();
                var contextrespCount = (from vc in ctx.VoteChoices
                                   join c in ctx.Choices on vc.choiceId equals c.Id
                                   where c.Poll.Id == pollId
                                   select new { c.Name, c.Id} into x
                                   group x by new { x.Name} into g
                                   select new
                                   { 
                                    choiceName = g.Key.Name,
                                    Count = g.Select(x => x.Id).Count()
                                   }).AsEnumerable().ToDictionary(kvp => kvp.choiceName, kvp => kvp.Count);
                foreach (var a in contextrespCount)
                {
                    PollResult.Add(a.Key, a.Value);
                }
                return PollResult;
            }
        }

        public Vote GetVote(int voteId)
        {
            using (var ctx = new VoteContext())
            {
                Vote vote = ctx.Votes.Include(vote => vote.VoteChoices).FirstOrDefault(vote => vote.Id == voteId);
                if (vote == null)
                    return null;
                return vote;
            }
        }
    }
}
