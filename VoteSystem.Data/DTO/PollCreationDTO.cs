using System;
using System.Collections.Generic;
using System.Text;

namespace VoteSystem.Data.DTO
{
    public class PollCreationDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public DateTime LeftDateTime { get; set; }
        public DateTime RightDateTime { get; set; }
        public bool MultipleSelection { get; set; } 
    }
}
