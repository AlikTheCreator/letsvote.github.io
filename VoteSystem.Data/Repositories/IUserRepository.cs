using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Entities.UserPolicyAggregate;

namespace VoteSystem.Data.Repositories
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        void CreateUserPolicy(UserPolicy userPolicy);
        bool IsInRegion(int regionId, int userId);
        List<User> GetAllUsersForRegion(int regionId);
        public List<int> GetAllUserPollIdsWithPolicies(int id);
        public bool UserExists(string paspCode, int IndefCode);
        public User GetUser(string PaspCode, int IndefCode);
        public User GetUser(int Id);
        public User GetUser(string email);
        public int GetUserId(string name);
        public int GetRegionId(int userId);
    }
}
