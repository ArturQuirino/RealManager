using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealManager.Domain;

namespace RealManager.Services.Interfaces
{
    public interface ILeagueService
    {
        List<League> GetLeagueFromTeamId(Guid teamId);
    }
}
