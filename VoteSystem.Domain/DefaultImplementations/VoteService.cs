using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoteSystem.Data.Entities.UserPolicyAggregate;
using VoteSystem.Data.Entities.VoteAggregate;
using VoteSystem.Data.Repositories;
using VoteSystem.Domain.Interfaces;

namespace VoteSystem.Domain.DefaultImplementations
{
    public class VoteService : IVoteService
    {
        IVoteRepository _voteRepos;
        IPollRepository _pollRepos;
        IAuthorizationContext _contextRegistration;
        public VoteService(
            IVoteRepository voteRepository, 
            IPollRepository pollRepository,
            IAuthorizationContext contextRegistration
        )
        {
            _pollRepos = pollRepository;
            _voteRepos = voteRepository;
            _contextRegistration = contextRegistration;
        }
        public Dictionary<string, int> GetPollResult(string pollName)
        {
            int pollId = _pollRepos.Get(pollName).Id;
            return _voteRepos.GetResultInPoll(pollId);
        }
        public Vote Vote(int Idchoice)
        {
            return Vote(new List<int>() { Idchoice });
        }

        public Vote Vote(List<int> Idchoices)
        {
            var vote = new Vote()
            {
                UserId = _contextRegistration.GetLoggedUser().Id,
                VoteDate = DateTime.Now,
                VoteChoices = new List<VoteChoice>()
            };

            foreach (var choiceId in Idchoices)
            {
                vote.VoteChoices.Add(new VoteChoice()
                {
                    choiceId = choiceId
                });
            }

            _voteRepos.Create(vote);
            return vote;
        }
    }
}
