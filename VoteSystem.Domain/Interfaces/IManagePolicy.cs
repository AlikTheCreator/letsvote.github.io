using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Entities.UserPolicyAggregate;

namespace VoteSystem.Domain.Interfaces
{
    public interface IManagePolicy
    {
        bool GivePolicyToUser(int userId, int pollId);
        bool GiveAdminPolicyToUser(int userId, int pollId);
        bool GivePolicyToUser(int userId, int pollId, PolicyType type); 
    }
}
