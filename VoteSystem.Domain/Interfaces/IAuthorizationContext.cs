
using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Entities.UserPolicyAggregate;

namespace VoteSystem.Domain.Interfaces
{
    public interface IAuthorizationContext
    {
        bool SetPasswordInfo(string passportCode, int indefCode);
        Tuple<string, int> GetPassportInfo();

        User GetLoggedUser();
    }
}
