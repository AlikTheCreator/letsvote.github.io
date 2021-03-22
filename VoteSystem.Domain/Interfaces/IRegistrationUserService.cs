using System;
using System.Collections.Generic;
using System.Text;

namespace VoteSystem.Domain.Interfaces
{
    public interface IRegistrationUserService
    {
        bool RegistrateUser(string Name, string Surname, string Email, string password, string RegionName);
    }
}
