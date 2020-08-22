const Match = require('../domain/match');
const Position = require('../domain/position');


class MatchService {
  runFriendly(homeTeam, awayTeam) {
    const match = new Match(homeTeam._id, homeTeam.name, awayTeam._id, awayTeam.name);

    for (let minute = 0; minute <= 90; minute++) {
      const singleEvent = this.runEvent(match, minute, homeTeam, awayTeam);
      match.events.push(singleEvent);
      match.awayGoals = singleEvent.awayGoals;
      match.homeGoals = singleEvent.homeGoals;
    }

    return match;
  }

  runEvent(match, minute, homeTeam, awayTeam) {
    const event = {
      description: [],
      homeGoals: match.homeGoals,
      awayGoals: match.awayGoals,
      minute,
    };
    const homeTeamAttacking = Math.random() > 0.5;

    let attackPlayer;
    let defencePlayer;
    let goalKeeper;

    if (homeTeamAttacking) {
      attackPlayer = this.selectAttackPlayer(homeTeam);
      defencePlayer = this.selectDefencePlayer(homeTeam);
      goalKeeper = this.selectGoalkeeper(homeTeam);
    } else {
      attackPlayer = this.selectAttackPlayer(awayTeam);
      defencePlayer = this.selectDefencePlayer(awayTeam);
      goalKeeper = this.selectGoalkeeper(awayTeam);
    }

    let positionDescriptionEvent = 0;
    event.description.push({
      description: `${attackPlayer.name} is trying to drible the defender`,
      position: positionDescriptionEvent,
    });

    positionDescriptionEvent++;

    const dribleSuccessChance = attackPlayer.drible + attackPlayer.pace / 2 - 15 * minute / attackPlayer.physical;
    const realDrible = Math.random() * 150;
    const ableToDrible = realDrible > 150 - dribleSuccessChance;

    if (!ableToDrible) {
      event.description.push({
        description: `${attackPlayer.name} lost the ball`,
        position: positionDescriptionEvent,
      });

      return event;
    }

    event.description.push({
      description: `${defencePlayer.name} is trying tackle the foward player.`,
      position: positionDescriptionEvent,
    });

    positionDescriptionEvent++;

    const tackleSuccessChance = defencePlayer.defence + defencePlayer.pace / 2 - 15 / defencePlayer.physical;
    const realTackle = Math.random() * 150;
    const ableToTackle = realTackle > 150 - tackleSuccessChance;

    if (ableToTackle) {
      event.description.push({
        description: `${defencePlayer.name} made the tackle`,
        position: positionDescriptionEvent,
      });

      return event;
    }

    event.description.push({
      description: `${attackPlayer.name}  will shoot`,
      position: positionDescriptionEvent,
    });

    positionDescriptionEvent++;

    const shootOnTargetChance = attackPlayer.shoot - 15 * minute / attackPlayer.physical;
    const realShoot = Math.random() * 100;
    const ableToShootOnTarget = realShoot > 100 - shootOnTargetChance;

    if (!ableToShootOnTarget) {
      event.description.push({
        description: `${attackPlayer.name} shoot far away from the goal`,
        position: positionDescriptionEvent,
      });

      return event;
    }

    event.description.push({
      description: `${goalKeeper.name} jumped!`,
      position: positionDescriptionEvent,
    });

    positionDescriptionEvent++;

    const defenceSuccessChance = goalKeeper.defence + goalKeeper.pace / 2 - 5 * minute / goalKeeper.physical;
    const realDefence = Math.random() * 150;
    const ableToDefend = realDefence > 150 - defenceSuccessChance;

    if (ableToDefend) {
      event.description.push({
        description: `${goalKeeper.name} catched the ball!`,
        position: positionDescriptionEvent,
      });

      return event;
    }

    event.description.push({
      description: `GOAL GOAL GOAL!! ${attackPlayer.name} scored a GOAL!`,
      position: positionDescriptionEvent,
    });

    if (homeTeamAttacking) {
      event.homeGoals++;
    } else {
      event.awayGoals++;
    }

    return event;
  }

  selectAttackPlayer(team) {
    const attackers = team.starters.filter((player) => player.position === Position.AT);
    return attackers[Math.floor(Math.random() * attackers.length)];
  }

  selectDefencePlayer(team) {
    const defenders = team.starters.filter((player) => player.position === Position.DF);
    return defenders[Math.floor(Math.random() * defenders.length)];
  }

  selectGoalkeeper(team) {
    return team.starters.find((player) => player.position === Position.GK);
  }
}

module.exports = MatchService;
