using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Entities.UserPolicyAggregate;
using VoteSystem.Data.Repositories;
using VoteSystem.Domain.Interfaces;

namespace VoteSystem.Domain.DefaultImplementations
{
    public class ManagePolicy : IManagePolicy
    {
        IUserRepository _userRepos;
        public ManagePolicy(IUserRepository userRepository)
        {
            _userRepos = userRepository;
        }
        public bool GivePolicyToUser(int userId, int pollId)
        {
            if (_userRepos.GetUser(userId) == null)
                return false;
            UserPolicy userPolicy = new UserPolicy()
            {
                PolicyType = (PolicyType)0,
                user = _userRepos.GetUser(userId),
                PollId = pollId
            };
            _userRepos.CreateUserPolicy(userPolicy);
            return true;
        }
        public bool GiveAdminPolicyToUser(int userId, int pollId)
        {
            if (_userRepos.GetUser(userId) == null)
                return false;
            UserPolicy userPolicy = new UserPolicy()
            {
                PolicyType = (PolicyType)1,
                user = _userRepos.GetUser(userId),
                PollId = pollId
            };
            UserPolicy userPolicy1 = new UserPolicy()
            {
                PolicyType = (PolicyType)0,
                user = _userRepos.GetUser(userId),
                PollId = pollId
            };
            _userRepos.CreateUserPolicy(userPolicy);
            _userRepos.CreateUserPolicy(userPolicy1);
            return true;
        }

        public bool GivePolicyToUser(int userId, int pollId, PolicyType type)
        {
            if (type == PolicyType.Access) {
                return GivePolicyToUser(userId, pollId);
            }
            if (type == PolicyType.Administration) {
                return GiveAdminPolicyToUser(userId, pollId);
            }
            return false;
        }
    }
}
