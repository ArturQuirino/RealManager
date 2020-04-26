using System;
using System.Collections.Generic;
using System.Linq;
using RealManager.Domain;
using RealManager.Repositories.Interfaces;
using RealManager.Repositories.Models;

namespace RealManager.Repositories
{
    public class LeagueRepository : ILeagueRepository
    {
        private DataContext _dataContext;
        public LeagueRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public League AddTeamToLeague(Team team)
        {
            var leagueDb = new LeagueDb()
            {
                Id = Guid.NewGuid(),
                Drawn = 0,
                GoalDifference = 0,
                GoalsAgainst = 0,
                GoalsFor = 0,
                IdLeague = new Guid("28db8f1b-1cb2-422f-81d6-d3027e36ef73"),
                Lost = 0,
                Matches = 0,
                Points = 0,
                Position = 0,
                Season = 1,
                TeamId = team.Id,
                TeamName = team.Name,
                Won = 0
            };

            _dataContext.Leagues.Add(leagueDb);
            _dataContext.SaveChanges();

            return MapLeagueDbToLeague(leagueDb);
        }

        public League GetLeagueFromTeamId(Guid teamId)
        {
            var leagueDb = _dataContext.Leagues.Single(league => league.TeamId == teamId);
            return MapLeagueDbToLeague(leagueDb);
        }

        public List<League> GetLeagueFromIdLeague(Guid idLeague)
        {
            var leaguesDb = _dataContext.Leagues.Where(league => league.IdLeague == idLeague);
            List<League> leagues = new List<League>();
            foreach(var leagueDb in leaguesDb)
            {
                leagues.Add(MapLeagueDbToLeague(leagueDb));
            }

            return leagues;
        }

        private League MapLeagueDbToLeague(LeagueDb leagueDb)
        {
            return new League()
            {
                Drawn = leagueDb.Drawn,
                GoalDifference = leagueDb.GoalDifference,
                GoalsAgainst = leagueDb.GoalsAgainst,
                GoalsFor = leagueDb.GoalsFor,
                IdLeague = leagueDb.IdLeague,
                Lost = leagueDb.Lost,
                Matches = leagueDb.Matches,
                Points = leagueDb.Points,
                Position = leagueDb.Position,
                Season = leagueDb.Season,
                TeamId = leagueDb.TeamId,
                TeamName = leagueDb.TeamName,
                Won = leagueDb.Won
            };
        }
    }
}