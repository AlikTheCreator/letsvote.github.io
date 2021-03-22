using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Repositories;
using VoteSystem.Domain.Interfaces;

namespace VoteSystem.Domain.DefaultImplementations
{
    public class RegistrationUserService : IRegistrationUserService
    {
        IVoteRepository _voteRepos;
        IRegionRepository _regionRepos;
        IUserRepository _userRepos;
        IAuthorizationContext _contextRegistration;
        public RegistrationUserService(IAuthorizationContext contextRegistration,  IVoteRepository voteRepository, IRegionRepository regionRepository, IUserRepository userRepository)
        {
            _voteRepos = voteRepository;
            _regionRepos = regionRepository;
            _userRepos = userRepository;
            _contextRegistration = contextRegistration;
        }
        public bool RegistrateUser(string Name, string Surname, string Email, string password, string RegionName)
        {
            string PaspCode = _contextRegistration.GetPassportInfo().Item1;
            int IndefCode = _contextRegistration.GetPassportInfo().Item2;
            var user = _userRepos.GetUser(PaspCode, IndefCode);
            user.Name = Name;
            user.Surname = Surname;
            user.Email = Email;
            user.Password = password;
            user.RegionId = _regionRepos.GetRegiondIdByName(RegionName);
            _userRepos.CreateUser(user);
            return true;
        }
    }
}
