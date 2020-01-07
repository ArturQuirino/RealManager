using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealManager.Services.Interfaces
{
    public interface IMatchService
    {
        bool RunMatchEvent(int time);
    }
}
