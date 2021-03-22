using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoteSystem.Data.DTO;
using VoteSystem.Data.Entities.PollAggregate;
using VoteSystem.Data.Repositories;
using VoteSystem.Domain.Interfaces;

namespace VoteSystem.Domain.DefaultImplementations
{
    public class PollService : IPollService
    {
        IPollRepository _pollRepos;
        IManagePolicy _managePolicy;
        IVoteService _voteService;
        IPolicyChecker _policyChecker;
        IVoteRepository _voteRepos;
        IAuthorizationContext _contextRegistration;
        public PollService(IAuthorizationContext contextRegistration,
                           IPollRepository pollRepository, IManagePolicy managePolicy,
                           IVoteService voteService, IPolicyChecker policyChecker, IVoteRepository voteRepository)
        {
            _voteRepos = voteRepository;
            _managePolicy = managePolicy;
            _pollRepos = pollRepository;
            _voteService = voteService;
            _policyChecker = policyChecker;
            _contextRegistration = contextRegistration;
        }

        public Choice CreateChoice(ChoiceCreationDTO choiceCreation)
        {
            var choice = new Choice()
            {
                Name = choiceCreation.OptionName,
                Description = choiceCreation.OptionDescription,
                Poll = _pollRepos.Get(_pollRepos.GetPolls().FirstOrDefault(p => p.Id == choiceCreation.pollId).Name)
            };
            _pollRepos.Get(choiceCreation.pollId).Choices.Add(choice);
            _pollRepos.CreateChoice(choice);
            return choice;
        }

        public void CreatePoll(PollCreationDTO pollCreation)
        {
            var poll = new Poll()
            {
                Name = pollCreation.Name,
                Description = pollCreation.Description,
                PollOwnerUserId = pollCreation.OwnerId,
                PollStartDate = pollCreation.LeftDateTime,
                PollEndDate = pollCreation.RightDateTime,
                MutlipleSelection = pollCreation.MultipleSelection,
                Choices = new List<Choice>()
            };
            _pollRepos.Create(poll);
            _managePolicy.GiveAdminPolicyToUser(pollCreation.OwnerId, poll.Id);
        }
        public Dictionary<bool, string> CheckAllPolicy(string temp_name)
        {
            Dictionary<bool, string> allResponses = new Dictionary<bool, string>();
            Poll poll = _pollRepos.Get(temp_name);
            bool policyresponse = _policyChecker.CheckPolicy(poll.Id);
            if (!policyresponse)
            {
                string policyAnswer = "You are not allowed to vote!";
                allResponses.Add(policyresponse, policyAnswer);
                return allResponses;
            }
            bool multiplevoteresponse = _voteRepos.IsVoted(_contextRegistration.GetLoggedUser().Id, temp_name);
            if (multiplevoteresponse)
            {
                string voteAnswer = "You have already voted!";
                allResponses.Add(multiplevoteresponse, voteAnswer);
                return allResponses;
            }
            return new Dictionary<bool, string>();
        }
    }
}
