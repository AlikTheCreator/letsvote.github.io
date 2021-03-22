using System;
using System.Collections.Generic;
using System.Text;

namespace VoteSystem.Data.Entities.RegionPolicyAggregate
{
    public class RegionPolicy
    {
        public int Id { get; set; }
        public Region Region { get; set; }
        public int? PollId { get; set; }
    }
}
