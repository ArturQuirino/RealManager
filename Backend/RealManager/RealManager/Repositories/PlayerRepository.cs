using System;
using System.Collections.Generic;
using MongoDB.Driver;
using RealManager.Domain;
using RealManager.Repositories.Models;
using Repositories.Interfaces;

namespace Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IMongoCollection<PlayerDb> _players;

        public PlayerRepository(IMongoRepository settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _players = database.GetCollection<PlayerDb>("players");
        }

        public List<PlayerDb> Get() =>
            _players.Find(player => true).ToList();

        public PlayerDb Get(string id) =>
            _players.Find(player => player.Id == id).FirstOrDefault();

        public Player Create(Player player){
            var playerdb = MapPlayerToPlayerDb(player);
            _players.InsertOne(playerdb);
            return player;
        }

        public void update(string id, PlayerDb playerdb) =>
            _players.ReplaceOne(player => player.Id == id, playerdb);

        public void Remove(PlayerDb playerDb) =>
            _players.DeleteOne(player => player.Id == playerDb.Id);

        public void Remove(string id) =>
            _players.DeleteOne(player => player.Id == id);

        private PlayerDb MapPlayerToPlayerDb(Player player){
            return new PlayerDb(){
                Id = player.Id.ToString(),
                Defence = player.Defence,
                Drible = player.Drible,
                Pace = player.Pace,
                Pass = player.Pass,
                Physical = player.Physical,
                Position = player.Position,
                Shoot = player.Shoot,
                Name = player.Name
            };
        }
    }
}