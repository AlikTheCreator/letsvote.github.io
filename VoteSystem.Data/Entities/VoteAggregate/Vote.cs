using System;
using System.Collections.Generic;
using System.Text;

namespace VoteSystem.Data.Entities.VoteAggregate
{
    public class Vote
    {
        public int Id { get; set; }
        public DateTime VoteDate { get; set; }
        public int UserId { get; set; }
        public List<VoteChoice> VoteChoices { get; set; }
    }
}
