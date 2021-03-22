using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Entities.RegionPolicyAggregate;

namespace VoteSystem.Data.Repositories
{
    public interface IRegionRepository
    {
        void CreateRegion(Region region);
        public Region Get(int id);
        public int GetRegiondIdByName(string name);
        public List<int> GetAllPollIdsForRegionPolicies(int id);
    }
}
