using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    public class Node
    {

        private int[,] grid;

        private String _testString;

        private Node _parent;
        public Node Parent
        {
            get { return this._parent; }
            private set
            {
                if (value != null && this._parent != null)
                    this._parent.Detach(this);
                this._parent = value;
            }
        }
        private List<Node> children;

        public int[] MoveFromParent { get; private set; }
        public int MoveCount { get; private set; }

        public int GCost { get; set; } // coût du chemin du noeud initial jusqu'à ce noeud
        public int HCost { get; set; } // estimation heuristique du coût pour atteindre le noeud final
        public int TotalCost { get { return this.GCost + this.HCost; } }

        public Node(int[,] gameState)
        {
            this.grid = gameState;

            this.Parent = null;
            this.children = new List<Node>();
        }

        public void Attach(Node child, int[] moveFromParentToChild)
        {
            this.children.Add(child);
            child.Parent = this;

            child.MoveFromParent = moveFromParentToChild;
            child.MoveCount++;
        }

        public void Detach(Node child)
        {
            if (Object.ReferenceEquals(child.Parent, this))
            {
                this.children.Remove(child);
                child.Parent = null;
            }
        }

        public override String ToString()
        {
            if (this._testString == null)
            {
                StringBuilder r = new StringBuilder();

                foreach (var a in this.grid)
                    r.Append(a).Append(", ");

                this._testString = r.ToString();
            }

            return this._testString;
        }

        internal int[,] ToGrid()
        {
            return this.grid;
        }

        public static bool operator==(Node a, Node b)
        {
            if (Object.ReferenceEquals(a, b)) return true;
            if (null == a as Object) return null == b as Object; // TODO: nêe??
            if (null == b as Object) return null == a as Object;
            if (a.ToString() == b.ToString()) return true;

            int[,] ga = a.ToGrid(), gb = b.ToGrid();
            for (int i = 0; i < ga.GetLength(0); i++)
                for (int j = 0; j < ga.GetLength(1); j++)
                    if (ga[i, j] != gb[i, j] && ga[i, j] != -1 && gb[i, j] != -1)
                        return false;

            return true;
        }

        public static bool operator!=(Node a, Node b)
        {
            return !(a == b); // TODO: optimizable?
        }

    }
}
