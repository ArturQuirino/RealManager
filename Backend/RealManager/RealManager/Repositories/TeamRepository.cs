using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using RealManager.Domain;
using RealManager.Repositories.Interfaces;
using RealManager.Repositories.Models;

namespace RealManager.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private DataContext _dataContext;
        public TeamRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
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


        public Team Get(Guid teamId)
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
                    TeamId = playerDb.TeamId
                });
            }

            Team team = new Team();
            team.Id = teamDb.Id;
            team.Name = teamDb.Name;
            team.Players = playersFromTeam;
            team.Starters = playersFromTeam
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
                    ).ToList();

            return team;


        }
    }
}