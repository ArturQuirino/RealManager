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
        private readonly ILeagueRepository _leagueRepository;
        public MatchService(ITeamRepository teamRepository, IMatchRepository matchRepository, ILeagueRepository leagueRepository)
        {
            _teamRepository = teamRepository;
            _matchRepository = matchRepository;
            _leagueRepository = leagueRepository;
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
            SaveMatchInLeague(currentMatch);

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

        private void SaveMatchInLeague(Match match)
        {
            var idLeagueHomeTeam = _leagueRepository.GetLeagueFromTeamId(match.HomeTeamId).IdLeague;
            var completeDivision = _leagueRepository.GetLeagueFromIdLeague(idLeagueHomeTeam);

            var leagueHomeTeam = completeDivision.First(league => league.TeamId == match.HomeTeamId);
            var leagueAwayTeam = completeDivision.First(league => league.TeamId == match.AwayTeamId);

            leagueHomeTeam.GoalsFor += match.HomeGoals;
            leagueAwayTeam.GoalsFor += match.AwayGoals;

            leagueHomeTeam.GoalsAgainst += match.AwayGoals;
            leagueAwayTeam.GoalsAgainst += match.HomeGoals;

            leagueHomeTeam.GoalDifference = leagueHomeTeam.GoalsFor - leagueHomeTeam.GoalsAgainst;
            leagueAwayTeam.GoalDifference = leagueAwayTeam.GoalsFor - leagueAwayTeam.GoalsAgainst;

            leagueHomeTeam.Matches++;
            leagueAwayTeam.Matches++;

            if(match.HomeGoals > match.AwayGoals)
            {
                leagueHomeTeam.Won++;
                leagueHomeTeam.Points += 3;

                leagueAwayTeam.Lost++;
            }
            else if (match.HomeGoals < match.AwayGoals)
            {
                leagueAwayTeam.Won++;
                leagueAwayTeam.Points += 3;

                leagueHomeTeam.Lost++;
            }
            else
            {
                leagueHomeTeam.Drawn++;
                leagueAwayTeam.Drawn++;

                leagueHomeTeam.Points++;
                leagueAwayTeam.Points++;
            }

            completeDivision = completeDivision.OrderByDescending(teamLeague => teamLeague.Points).ToList();
            for(int position = 1; position <= completeDivision.Count; position++)
            {
                completeDivision[position-1].Position = position;
            }

            _leagueRepository.UpdateLeague(completeDivision);
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
            var positionDescriptionEvent = 0;
            singleEvent.Description.Add(new MatchEventDescription() {
                Description = attackPlayer.Name + " is trying to drible the defender.",
                Position = positionDescriptionEvent
            });

            positionDescriptionEvent++;

            int dribleSuccessChance = attackPlayer.Drible + attackPlayer.Pace / 2 - 15 * minute / attackPlayer.Physical;
            
            var realDrible = randomNumber.Next(0, 150);

            var ableToDrible = realDrible > 150 - dribleSuccessChance;

            if (!ableToDrible) {
                singleEvent.Description.Add(new MatchEventDescription()
                {
                    Description = attackPlayer.Name + " lost the ball.",
                    Position = positionDescriptionEvent
                });
                return singleEvent;
            }

            singleEvent.Description.Add(new MatchEventDescription()
            {
                Description = defencePlayer.Name + " is trying tackle the foward player.",
                Position = positionDescriptionEvent
            });

            positionDescriptionEvent++;

            int tackleSucessChance = defencePlayer.Defence + defencePlayer.Pace / 2 - 15 * minute / defencePlayer.Physical;

            var realTackle = randomNumber.Next(0, 150);

            var ableToTackle = realTackle > 150 - tackleSucessChance;

            if (ableToTackle){
                singleEvent.Description.Add(new MatchEventDescription()
                {
                    Description = defencePlayer.Name + " made the tackle.",
                    Position = positionDescriptionEvent
                });
                return singleEvent;
            }

            singleEvent.Description.Add(new MatchEventDescription()
            {
                Description = attackPlayer.Name + " will shoot.",
                Position = positionDescriptionEvent
            });

            positionDescriptionEvent++;

            int shootOnTargetChance = attackPlayer.Shoot - 15 * minute / attackPlayer.Physical;

            var realShoot = randomNumber.Next(0, 100);

            var ableToShootOnTarget = realShoot > 100 - shootOnTargetChance;

            if (!ableToShootOnTarget){
                singleEvent.Description.Add(new MatchEventDescription()
                {
                    Description = attackPlayer.Name + " shoot far away from the goal.",
                    Position = positionDescriptionEvent
                });
                return singleEvent;
            }

            singleEvent.Description.Add(new MatchEventDescription()
            {
                Description = goalKeeperPlayer.Name + " jumped!",
                Position = positionDescriptionEvent
            });

            positionDescriptionEvent++;

            int defenceSucessChance = goalKeeperPlayer.Defence + goalKeeperPlayer.Pace / 2 - 5 * minute / goalKeeperPlayer.Physical;

            var realDefence = randomNumber.Next(0, 150);

            var ableToDefence = realDefence > 150 - defenceSucessChance;

            if (ableToDefence){
                singleEvent.Description.Add(new MatchEventDescription()
                {
                    Description = goalKeeperPlayer.Name + " catched the ball!",
                    Position = positionDescriptionEvent
                });
                return singleEvent;
            }

            singleEvent.Description.Add(new MatchEventDescription()
            {
                Description = attackPlayer.Name + " Scored a GOAL!!!.",
                Position = positionDescriptionEvent
            });

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
