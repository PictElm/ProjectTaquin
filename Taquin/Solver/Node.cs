using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    class Node
    {

        private int[,] grid;

        public Node Parent { get; private set; }
        private List<Node> children;

        public int MoveCount { get; private set; }

        public Node(int[,] gameState)
        {
            this.grid = gameState;

            this.Parent = null;
            this.children = new List<Node>();
        }

        public void Attach(Node child)
        {
            this.children.Add(child);
            child.Parent = this;

            child.MoveCount++;
        }

        public override string ToString()
        {
            StringBuilder r = new StringBuilder();

            foreach (var a in this.grid)
                r.Append(a);

            return r.ToString();
        }

    }
}
