using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver2
{
    public abstract class AGame<T_Node, T_Move> where T_Node : class, Graph.INode<T_Move>
    {

        public abstract Graph.INode<T_Move> State { get; set; }

    }
}
