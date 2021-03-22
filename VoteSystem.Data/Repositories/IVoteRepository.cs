using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Entities.VoteAggregate;

namespace VoteSystem.Data.Repositories
{
    public interface IVoteRepository
    {
        void Create(Vote vote);
        void CreateVoteChoice(VoteChoice voteChoice);
        bool IsVoted(int userId, string pollName);
        Vote GetVote(int voteId);
        List<Vote> GetAllForUser(int userId);
        Dictionary<string, int> GetResultInPoll(int pollId);
    }
}
