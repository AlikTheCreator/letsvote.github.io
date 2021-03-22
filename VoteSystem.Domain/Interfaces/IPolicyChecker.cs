using System;
using System.Collections.Generic;
using System.Text;

namespace VoteSystem.Domain.Interfaces
{
    public interface IPolicyChecker
    {
        bool CheckPolicy(int pollId);
        bool CheckAdminPolicy(int pollId);
    }
}
