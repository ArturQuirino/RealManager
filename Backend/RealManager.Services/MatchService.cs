using RealManager.Domain;
using RealManager.Domain.Enums;
using RealManager.Repositories.Interfaces;
using RealManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RealManager.Services
{
    public class MatchService : IMatchService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMatchRepository _matchRepository;
        public MatchService(ITeamRepository teamRepository, IMatchRepository matchRepository)
        {
            _teamRepository = teamRepository;
            _matchRepository = matchRepository;
        }
        public bool RunMatchEvent(int time)
        {
            return true;

        }

        public Match RunFriendly(Guid homeTeamId, Guid awayTeamId)
        {
            var homeTeam = GetStartersTeam(homeTeamId);
            var awayTeam = GetStartersTeam(awayTeamId);

            Match currentMatch = new Match(homeTeam.Id, homeTeam.Name, awayTeam.Id, awayTeam.Name);

            for (int minute = 0; minute <= 90; minute++)
            {
                var singleEvent = RunEvent(currentMatch, minute, homeTeam, awayTeam);
                currentMatch.Events.Add(singleEvent);
                currentMatch.AwayGoals = singleEvent.AwayGoals;
                currentMatch.HomeGoals = singleEvent.HomeGoals;
            }

            _matchRepository.Create(currentMatch);

            return currentMatch;
        }

        public List<Match> GetMatchesByTeamId(Guid teamId)
        {
            return _matchRepository.GetMatchesByTeam(teamId);
        }

        public Match GetMatchById(Guid matchId)
        {
            return _matchRepository.GetById(matchId);
        }

        private MatchEvent RunEvent(Match match, int minute, Team homeTeam, Team awayTeam)
        {
            MatchEvent singleEvent = new MatchEvent(match);

            var randomNumber = new Random();

            bool homeTeamAttack = randomNumber.Next(0,2) > 0.5;

            Player attackPlayer;
            Player defencePlayer;
            Player goalKeeperPlayer;

            if(homeTeamAttack){
                attackPlayer = SelectAttackPlayer(homeTeam);
                defencePlayer = SelectDefencePlayer(awayTeam);
                goalKeeperPlayer = SelectGoalkeeper(awayTeam);
            }else{
                attackPlayer = SelectAttackPlayer(awayTeam);
                defencePlayer = SelectDefencePlayer(homeTeam);
                goalKeeperPlayer = SelectGoalkeeper(homeTeam);
            }

            singleEvent.Description.Add(attackPlayer.Name + " is trying to drible the defender.");

            int dribleSuccessChance = attackPlayer.Drible + attackPlayer.Pace / 2 - 15 * minute / attackPlayer.Physical;
            
            var realDrible = randomNumber.Next(0, 150);

            var ableToDrible = realDrible > 150 - dribleSuccessChance;

            if (!ableToDrible) {
                singleEvent.Description.Add(attackPlayer.Name + " lost the ball.");
                return singleEvent;
            }

            singleEvent.Description.Add(defencePlayer.Name + " is trying tackle the foward player.");

            int tackleSucessChance = defencePlayer.Defence + defencePlayer.Pace / 2 - 15 * minute / defencePlayer.Physical;

            var realTackle = randomNumber.Next(0, 150);

            var ableToTackle = realTackle > 150 - tackleSucessChance;

            if (ableToTackle){
                singleEvent.Description.Add(defencePlayer.Name + " made the tackle.");
                return singleEvent;
            }

            singleEvent.Description.Add(attackPlayer.Name + " will shoot.");

            int shootOnTargetChance = attackPlayer.Shoot - 15 * minute / attackPlayer.Physical;

            var realShoot = randomNumber.Next(0, 100);

            var ableToShootOnTarget = realShoot > 100 - shootOnTargetChance;

            if (!ableToShootOnTarget){
                singleEvent.Description.Add(attackPlayer.Name + " shoot far away from the goal.");
                return singleEvent;
            }

            singleEvent.Description.Add(goalKeeperPlayer.Name + " jumped!");

            int defenceSucessChance = goalKeeperPlayer.Defence + goalKeeperPlayer.Pace / 2 - 5 * minute / goalKeeperPlayer.Physical;

            var realDefence = randomNumber.Next(0, 150);

            var ableToDefence = realDefence > 150 - defenceSucessChance;

            if (ableToDefence){
                singleEvent.Description.Add(goalKeeperPlayer.Name + " catched the ball!");
                return singleEvent;
            }


            singleEvent.Description.Add(attackPlayer.Name + " Scored a GOAL!!!.");
            if(homeTeamAttack){
                singleEvent.HomeGoals++;
            }else{
                singleEvent.AwayGoals++;
            }

            return singleEvent;
        }

        private static Player SelectGoalkeeper(Team team)
        {
            return team.Starters.FirstOrDefault(starter => starter.Position == Position.GK);
        }

        private static Player SelectDefencePlayer(Team team)
        {
            var defenders = team.Starters.Where(starter => starter.Position == Position.DF).ToList();
            var random = new Random();
            int index = random.Next(defenders.Count);
            return defenders[index];
        }

        private static Player SelectAttackPlayer(Team team)
        {
            var attackers = team.Starters.Where(starter => starter.Position == Position.ATA).ToList();
            var random = new Random();
            int index = random.Next(attackers.Count);
            return attackers[index];
        }

        public Team GetStartersTeam(Guid teamId)
        {
            return _teamRepository.GetTeam(teamId);
        }

        private Team CreateRandomTeam() {
            var team = new Team();
            var goalkeeper = new Player()
            {
                Defence = 20,
                Drible = 20,
                Pace = 20,
                Pass = 20,
                Physical = 20,
                Shoot = 20,
                Position = Position.GK,
            };

            var defender = new Player()
            {
                Defence = 20,
                Drible = 20,
                Pace = 20,
                Pass = 20,
                Physical = 20,
                Shoot = 20,
                Position = Position.DF,
            };

            var attackPlayer = new Player()
            {
                Defence = 20,
                Drible = 20,
                Pace = 20,
                Pass = 20,
                Physical = 20,
                Shoot = 20,
                Position = Position.ATA,
            };

            team.Players.Add(goalkeeper);
            team.Players.Add(defender);
            team.Players.Add(attackPlayer);

            return team;
        }
    }
}
