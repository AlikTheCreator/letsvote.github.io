using System;
using System.Collections.Generic;
using System.Text;

namespace VoteSystem.Data.Entities.RegionPolicyAggregate
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RegionPolicy> RegionPolicies { get; set; }
    }
}
