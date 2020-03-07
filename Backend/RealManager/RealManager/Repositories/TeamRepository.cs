using System;
using System.Collections.Generic;
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
    }
}