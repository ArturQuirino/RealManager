using System;
using System.Collections.Generic;
using System.Linq;
using RealManager.Domain;
using RealManager.Domain.Enums;
using RealManager.Repositories.Interfaces;
using RealManager.Repositories.Models;

namespace RealManager.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private DataContext _dataContext;
        public MatchRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Match Create(Match match)
        {
            List<MatchEventDescriptionDb> matchEventDescriptionsDb = new List<MatchEventDescriptionDb>();

            List<MatchEventDb> matchEventsDb = new List<MatchEventDb>();
            foreach(var matchEvent in match.Events)
            {
                var matchEventId = Guid.NewGuid();
                matchEventsDb.Add(new MatchEventDb()
                {
                    AwayGoals = matchEvent.AwayGoals,
                    HomeGoals = matchEvent.HomeGoals,
                    Id = matchEventId,
                    MatchId = match.Id
                });

                foreach(var eventDescription in matchEvent.Description)
                {
                    matchEventDescriptionsDb.Add(new MatchEventDescriptionDb()
                    {
                        Description = eventDescription.Description,
                        Id = Guid.NewGuid(),
                        MatchEventId = matchEventId,
                        Position = eventDescription.Position
                    });
                }
            }

            MatchDb matchDb = new MatchDb { 
                Id = match.Id,
                AwayGoals = match.AwayGoals,
                AwayTeamId = match.AwayTeamId,
                AwayTeamName = match.AwayTeamName,
                FinalResult = match.FinalResult,
                HomeGoals = match.HomeGoals,
                HomeTeamId = match.HomeTeamId,
                HomeTeamName = match.HomeTeamName
            };

            _dataContext.MatchEventDescriptions.AddRange(matchEventDescriptionsDb);
            _dataContext.MatchEvents.AddRange(matchEventsDb);
            _dataContext.Matches.Add(matchDb);
            _dataContext.SaveChanges();

            return match;
        }

        public List<Match> GetMatchesByTeam(Guid teamId)
        {
            var matchesDb = _dataContext.Matches.Where(
                (match) => match.AwayTeamId == teamId || match.HomeTeamId == teamId
            ).ToList();

            var matchEventsDb = _dataContext.MatchEvents.Where(me => matchesDb.Select(m => m.Id).Contains(me.MatchId)).ToList();

            var matchEventsDescriptionDb = _dataContext.MatchEventDescriptions.Where(med => matchEventsDb.Select(me => me.Id).Contains(med.MatchEventId)).ToList();

            List<Match> matches = new List<Match>();

           

            foreach(var matchDb in matchesDb)
            {
                Match match = GetFullMatch(matchEventsDb, matchEventsDescriptionDb, matchDb);

                matches.Add(match);

            }

            return matches;
        }

        public Match GetById(Guid matchId)
        {
            var matchDb = _dataContext.Matches.FirstOrDefault(m => m.Id == matchId);

            var matchEventsDb = _dataContext.MatchEvents.Where(me => matchDb.Id == me.MatchId).ToList();

            var matchEventsDescriptionDb = _dataContext.MatchEventDescriptions.Where(med => matchEventsDb.Select(me => me.Id).Contains(med.MatchEventId)).ToList();

            return GetFullMatch(matchEventsDb, matchEventsDescriptionDb, matchDb);
        }

        private Match GetFullMatch(List<MatchEventDb> matchEventsDb, List<MatchEventDescriptionDb> matchEventsDescriptionDb, MatchDb matchDb)
        {
            var match = new Match()
            {
                AwayTeamId = matchDb.AwayTeamId,
                AwayGoals = matchDb.AwayGoals,
                AwayTeamName = matchDb.AwayTeamName,
                Id = matchDb.Id,
                HomeGoals = matchDb.HomeGoals,
                HomeTeamId = matchDb.HomeTeamId,
                HomeTeamName = matchDb.HomeTeamName,
                Events = new List<MatchEvent>()
            };

            List<MatchEvent> matchEvents = new List<MatchEvent>();
            foreach (var matchEventDb in matchEventsDb)
            {
                if (matchEventDb.MatchId == matchDb.Id)
                {
                    var matchEvent = new MatchEvent
                    {
                        AwayGoals = matchEventDb.AwayGoals,
                        HomeGoals = matchEventDb.HomeGoals,
                        Description = new List<MatchEventDescription>()
                    };

                    var matchesEventDescriptions = matchEventsDescriptionDb.Where(med => med.MatchEventId == matchEventDb.Id).ToList();

                    foreach (var matchEventDesc in matchesEventDescriptions)
                    {
                        matchEvent.Description.Add(new MatchEventDescription() {
                            Description = matchEventDesc.Description,
                            Position = matchEventDesc.Position
                        });
                    }

                    match.Events.Add(matchEvent);
                }
            }

            return match;
        }
    }
}