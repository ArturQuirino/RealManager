using RealManager.Domain;
using RealManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealManager.Services
{
    public class MatchService : IMatchService
    {

        public bool RunMatchEvent(int time)
        {
            var attackPlayer = new Player()
            {
                Defence = 80,
                Drible = 80,
                Pace = 80,
                Pass = 80,
                Physical = 80,
                Shoot = 80,
                Position = Position.ATA,
            };

            var defencePlayer = new Player()
            {
                Defence = 20,
                Drible = 20,
                Pace = 20,
                Pass = 20,
                Physical = 20,
                Shoot = 20,
                Position = Position.DF,
            };

            var goalKeeperPlayer = new Player()
            {
                Defence = 20,
                Drible = 20,
                Pace = 20,
                Pass = 20,
                Physical = 20,
                Shoot = 20,
                Position = Position.GK,
            };

            int dribleSuccessChance = attackPlayer.Drible + attackPlayer.Pace / 2 - 15 * time / attackPlayer.Physical;
            var randomNumber = new Random();

            var realDrible = randomNumber.Next(0, 150);

            var ableToDrible = realDrible > 150 - dribleSuccessChance;

            if (!ableToDrible) return false;


            int tackleSucessChance = defencePlayer.Defence + defencePlayer.Pace / 2 - 15 * time / defencePlayer.Physical;

            var realTackle = randomNumber.Next(0, 150);

            var ableToTackle = realTackle > 150 - tackleSucessChance;

            if (ableToTackle) return false;


            int shootOnTargetChance = attackPlayer.Shoot - 15 * time / attackPlayer.Physical;

            var realShoot = randomNumber.Next(0, 100);

            var ableToShootOnTarget = realShoot > 100 - shootOnTargetChance;

            if (!ableToShootOnTarget) return false;



            int defenceSucessChance = goalKeeperPlayer.Defence + goalKeeperPlayer.Pace / 2 - 5 * time / goalKeeperPlayer.Physical;

            var realDefence = randomNumber.Next(0, 150);

            var ableToDefence = realDefence > 150 - defenceSucessChance;

            if (ableToDefence) return false;

            return true;
        }
    }
}
