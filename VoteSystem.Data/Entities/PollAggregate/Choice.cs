using System;
using System.Collections.Generic;
using System.Text;

namespace VoteSystem.Data.Entities.PollAggregate
{
    public class Choice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Poll Poll { get; set; }
    }
}
