using System;
using System.Collections.Generic;
using System.Text;

namespace VoteSystem.Data.DTO
{
    public class ChoiceCreationDTO
    {
        public string OptionName { get; set; }
        public string OptionDescription { get; set; }
        public int pollId { get; set; }
    }
}
