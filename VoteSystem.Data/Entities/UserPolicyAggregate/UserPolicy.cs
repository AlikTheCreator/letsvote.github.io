using System;
using System.Collections.Generic;
using System.Text;

namespace VoteSystem.Data.Entities.UserPolicyAggregate
{
    public enum PolicyType
    { 
        Access, 
        Administration
    }
    public class UserPolicy
    {
        public PolicyType PolicyType { get; set; }
        public int Id { get; set; }
        public User user { get; set; }
        public int? PollId { get; set; }
    }
}
