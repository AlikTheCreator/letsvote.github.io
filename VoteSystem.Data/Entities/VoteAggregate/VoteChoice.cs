using System;
using System.Collections.Generic;
using System.Text;

namespace VoteSystem.Data.Entities.VoteAggregate
{
    public class VoteChoice
    {
        public int Id { get; set; }
        public Vote Vote { get; set; }
        public int choiceId { get; set; }
    }
}
