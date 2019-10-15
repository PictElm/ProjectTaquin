using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    public interface ISolve
    {
        void Solve(Game game, int[,] finalState);
    }
}
