using System;
using System.Collections.Generic;
using System.Text;

namespace VoteSystem.Data.Entities.UserPolicyAggregate
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PassportCode { get; set; }
        public int IdentificationCode { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RegionId { get; set; }
        public List<UserPolicy> UserPolicies { get; set; }
    }
}
