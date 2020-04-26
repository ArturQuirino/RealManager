using System;
using System.Collections.Generic;
using System.Linq;
using RealManager.Domain;
using RealManager.Domain.Enums;
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
        public Team Create(Team team)
        {
            TeamDb teamDb = new TeamDb
            {
                Id = team.Id,
                Name = team.Name,
                Starter1Id = team.Starters[0].Id,
                Starter2Id = team.Starters[1].Id,
                Starter3Id = team.Starters[2].Id,
                Starter4Id = team.Starters[3].Id,
                Starter5Id = team.Starters[4].Id,
                Starter6Id = team.Starters[5].Id,
                Starter7Id = team.Starters[6].Id,
                Starter8Id = team.Starters[7].Id,
                Starter9Id = team.Starters[8].Id,
                Starter10Id = team.Starters[9].Id,
                Starter11Id = team.Starters[10].Id,
            };

            _dataContext.Teams.Add(teamDb);
            _dataContext.SaveChanges();

            return team;
        }

        public Team Update(Team team)
        {
            var teamDb = _dataContext.Teams.Single(teamDb => teamDb.Id == team.Id);
            teamDb.Starter1Id = team.Starters[0].Id;
            teamDb.Starter2Id = team.Starters[1].Id;
            teamDb.Starter3Id = team.Starters[2].Id;
            teamDb.Starter4Id = team.Starters[3].Id;
            teamDb.Starter5Id = team.Starters[4].Id;
            teamDb.Starter6Id = team.Starters[5].Id;
            teamDb.Starter7Id = team.Starters[6].Id;
            teamDb.Starter8Id = team.Starters[7].Id;
            teamDb.Starter9Id = team.Starters[8].Id;
            teamDb.Starter10Id = team.Starters[9].Id;
            teamDb.Starter11Id = team.Starters[10].Id;

            _dataContext.Teams.Update(teamDb);
            _dataContext.SaveChanges();

            return team;
        }


        public Team GetTeam(Guid teamId)
        {
            var teamDb = _dataContext.Teams
                        .Single(team => team.Id == teamId);

            var playersDbFromTeam = _dataContext.Players.Where(player => player.TeamId == teamId).ToList();

            var playersFromTeam = new List<Player>();

            foreach(PlayerDb playerDb in playersDbFromTeam)
            {
                playersFromTeam.Add(new Player()
                {
                    Id = playerDb.Id,
                    Defence = playerDb.Defence,
                    Drible = playerDb.Drible,
                    Name = playerDb.Name,
                    Pace = playerDb.Pace,
                    Pass = playerDb.Pass,
                    Physical = playerDb.Physical,
                    Position = (Position)playerDb.Position,
                    Shoot = playerDb.Shoot,
                    TeamId = playerDb.TeamId,
                    Overall = playerDb.Overall
                });
            }

            Team team = new Team();
            team.Id = teamDb.Id;
            team.Name = teamDb.Name;
            team.Players.AddRange(playersFromTeam);
            team.Starters.AddRange(playersFromTeam
                .Where(player => 
                    player.Id == teamDb.Starter1Id ||
                    player.Id == teamDb.Starter2Id ||
                    player.Id == teamDb.Starter3Id ||
                    player.Id == teamDb.Starter4Id ||
                    player.Id == teamDb.Starter5Id ||
                    player.Id == teamDb.Starter6Id ||
                    player.Id == teamDb.Starter7Id ||
                    player.Id == teamDb.Starter8Id ||
                    player.Id == teamDb.Starter9Id ||
                    player.Id == teamDb.Starter10Id ||
                    player.Id == teamDb.Starter11Id
                    ));

            return team;


        }
    }
}