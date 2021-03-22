using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Repositories;
using VoteSystem.Data.Entities.UserPolicyAggregate;
using System.Linq;
using System.Data.Entity;

namespace VoteSystem.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void CreateUser(User user)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                voteContext.Users.Add(user);
                voteContext.SaveChangesAsync();
            }
        }
        public void CreateUserPolicy(UserPolicy userPolicy)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                voteContext.Users.Attach(userPolicy.user);
                voteContext.Entry(userPolicy.user).State = System.Data.Entity.EntityState.Unchanged;
                voteContext.UserPolicies.Add(userPolicy);
                voteContext.SaveChanges();
            }
        }
        public bool UserExists(string paspCode, int IndefCode)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                if (voteContext.Users.FirstOrDefault(u => u.PassportCode == paspCode) != null)
                {
                    if (voteContext.Users.FirstOrDefault(u => u.PassportCode == paspCode).IdentificationCode == IndefCode)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public List<User> GetAllUsersForRegion(int regionId)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                return voteContext.Users.Include(u => u.UserPolicies).ToList().Where(u => u.RegionId == regionId).ToList();
            }
        }

        public bool IsInRegion(int regionId, int userId)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                return voteContext.Users.FirstOrDefault(u => u.Id == userId).RegionId == regionId;
            }
        }

        public List<int> GetAllUserPollIdsWithPolicies(int id)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                List<UserPolicy> userPolicies = voteContext.UserPolicies.Where(p => p.user.Id == id).ToList();
                List<int> outlist = new List<int>();
                foreach (var a in userPolicies)
                {
                    outlist.Add((a.PollId).Value);
                }
                return outlist;
            }
        }
        public User GetUser(string PaspCode, int IndefCode)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                return voteContext.Users.Include(x => x.UserPolicies).
                    FirstOrDefault(p => (p.PassportCode == PaspCode) && (p.IdentificationCode == IndefCode));
            }
        }
        public User GetUser(int Id)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                return voteContext.Users.Include(x => x.UserPolicies).FirstOrDefault(p => p.Id == Id);
            }
        }
        public int GetUserId(string name)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                return voteContext.Users.FirstOrDefault(u => u.Name == name).Id;
            }
        }

        public int GetRegionId(int userId)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                return voteContext.Users.FirstOrDefault(u => u.Id == userId).RegionId;
            }
        }

        public User GetUser(string email)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                return voteContext.Users.Include(x => x.UserPolicies).FirstOrDefault(u => u.Email == email);
            }
        }
    }
}
