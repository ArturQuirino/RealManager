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
        private readonly IMongoCollection<TeamDb> _teams;

        public TeamRepository(IMongoRepository settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _teams = database.GetCollection<TeamDb>("teams");
        }

        public List<Team> Get(){
            var teamList = new List<Team>();
            var teamdbList = _teams.Find(team => true).ToList();
            teamdbList.ForEach(teamdb => teamList.Add(MapTeamDbToTeam(teamdb)));

            return teamList;
        }
            

        public Team Get(string id) =>
            MapTeamDbToTeam(_teams.Find(team => team.Id == id).FirstOrDefault());

        public Team Create(Team team){
            var teamdb = MapTeamToTeamDb(team);
            _teams.InsertOne(teamdb);
            return team;
        }

        public void Update(string id, Team team) =>
            _teams.ReplaceOne(team => team.Id == id, MapTeamToTeamDb(team));

        public void Remove(Team team) =>
            _teams.DeleteOne(teamdb => teamdb.Id == team.Id.ToString());

        public void Remove(string id) =>
            _teams.DeleteOne(teamdb => teamdb.Id == id);

        private TeamDb MapTeamToTeamDb(Team team){
            var players = new List<string>();
            team.Players.ForEach(player => players.Add(player.Id.ToString()));

            var starters = new List<string>();
            team.Starters.ForEach(starter => starters.Add(starter.Id.ToString()));

            return new TeamDb(){
                Id = team.Id.ToString(),
                Name = team.Name,
                Players = players,
                Starters = starters
            };
        }

        private Team MapTeamDbToTeam(TeamDb teamdb){
            return new Team(){

            };
        }
    }
}