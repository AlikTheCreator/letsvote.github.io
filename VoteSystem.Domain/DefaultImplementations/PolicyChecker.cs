using System;
using System.Linq;
using VoteSystem.Data.Repositories;
using VoteSystem.Domain.Interfaces;
using VoteSystem.Data.Entities.UserPolicyAggregate;

namespace VoteSystem.Domain.DefaultImplementations
{
    public class PolicyChecker : IPolicyChecker
    {
        IUserRepository _userRepos;
        IAuthorizationContext _authorizationContext;
        public PolicyChecker(IUserRepository userRepository, IAuthorizationContext authorizationContext)
        {
            _userRepos = userRepository;
            _authorizationContext = authorizationContext;
        }
        public bool CheckPolicy(int pollId)
        {
            foreach (var a in _authorizationContext.GetLoggedUser().UserPolicies.Where(u => u.PolicyType == (PolicyType)0))
            {
                if (a.PollId == pollId)
                    return true;
            }
            return false;
        }
        public bool CheckAdminPolicy(int pollId)
        {
            foreach (var a in _authorizationContext.GetLoggedUser().UserPolicies.Where(u => u.PolicyType == (PolicyType)1))
            {
                if (a.PollId == pollId)
                    return true;
            }
            return false;
        }
    }
}
