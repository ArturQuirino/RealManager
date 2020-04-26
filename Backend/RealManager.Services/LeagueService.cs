using RealManager.Domain;
using RealManager.Repositories.Interfaces;
using RealManager.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace RealManager.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly ILeagueRepository _leagueRepository;
        public LeagueService(ILeagueRepository leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }

        public List<League> GetLeagueFromTeamId(Guid teamId)
        {
            var leagueId = _leagueRepository.GetLeagueFromTeamId(teamId).IdLeague;
            return _leagueRepository.GetLeagueFromIdLeague(leagueId);
        }
    }
}