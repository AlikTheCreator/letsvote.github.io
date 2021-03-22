using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.DTO;
using VoteSystem.Data.Entities.PollAggregate;

namespace VoteSystem.Domain.Interfaces
{
    public interface IPollService
    {
        void CreatePoll(PollCreationDTO creationDTO);
        Choice CreateChoice(ChoiceCreationDTO choiceCreation);
        Dictionary<bool, string> CheckAllPolicy(string temp_name);
    }
}
