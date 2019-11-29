using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver2.Graph
{
    public interface INode<T_Move>
    {

        INode<T_Move> Parent { get; set; }
        T_Move MoveFromParent { get; set; }
        List<INode<T_Move>> Children { get; set; }

        bool SameAs(INode<T_Move> mate);
        String ToString();

        List<INode<T_Move>> Nexts(AGame<INode<T_Move>, T_Move> gameRef, INode<T_Move> restrMustMatch = null);
        int Heuristics(INode<T_Move> final);
        void Attach(INode<T_Move> child, T_Move moveFromParentToChild);

        int GCost { get; set; }
        int HCost { get; set; }
        int TotalCost { get; }

    }
}
