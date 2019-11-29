using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solver2.Graph;

namespace Solver2.Taquin
{
    public class TaquinNode : INode<TaquinGame.Move>
    {

        public int[,] Grid { get; private set; }
        public TaquinGame.Move MoveFromParent { get; set; }

        public int GCost { get; set; } // coût du chemin du noeud initial jusqu'à ce noeud
        public int HCost { get; set; } // estimation heuristique du coût pour atteindre le noeud final

        public int TotalCost { get { return this.GCost + this.HCost; } }

        private INode<TaquinGame.Move> _parent;
        public INode<TaquinGame.Move> Parent
        {
            get { return this._parent; }
            set
            {
                if (value != null && this._parent != null)
                    this._parent.Children.Remove(this);

                this._parent = value;

                if (value != null)
                    this._parent.Children.Add(this);
            }
        }
        public List<INode<TaquinGame.Move>> Children { get; set; }

        private String _hash;
        public String Hash
        {
            get
            {
                if (this._hash == null)
                {
                    this._hash = "";
                    foreach (var v in this.Grid)
                        this._hash += v.ToString() + ",";
                }
                return this._hash;
            }
        }

        public TaquinNode(int[,] grid)
        {
            this.Grid = grid;
            this.Parent = null;
            this.Children = new List<INode<TaquinGame.Move>>();
        }

        public TaquinNode(int[,] grid, TaquinGame.Move moveFromParent) : this(grid)
        {
            this.MoveFromParent = moveFromParent;
        }

        public TaquinNode() : this(null) { }

        public void Attach(INode<TaquinGame.Move> child, TaquinGame.Move moveFromParentToChild)
        {
            child.Parent = this;
            child.MoveFromParent = moveFromParentToChild;
        }

        public int Heuristics(INode<TaquinGame.Move> final)
        {
            return 0;
        }
        
        public List<INode<TaquinGame.Move>> Nexts(AGame<INode<TaquinGame.Move>, TaquinGame.Move> gameRef, INode<TaquinGame.Move> restrMustMatch = null)
        {
            if (restrMustMatch == null)
                return gameRef.NextNodes(this);
            return gameRef.NextNodes(this, node => restrMustMatch.SameAs(node));
        }

        public bool SameAs(INode<TaquinGame.Move> mate)
        {
            if (Object.ReferenceEquals(this, mate)) return true;
            if (null == this as Object) return null == mate as Object;
            if (null == mate as Object) return null == this as Object;

            if (this.Hash == (mate as TaquinNode).Hash) return true;
            int[,] ga = this.Grid, gb = (mate as TaquinNode).Grid;
            for (int i = 0; i < ga.GetLength(0); i++)
                for (int j = 0; j < ga.GetLength(1); j++)
                    if (ga[i, j] != gb[i, j] && ga[i, j] != -1 && gb[i, j] != -1)
                        return false;

            return true;
        }

        public override string ToString()
        {
            if (this.Parent == null)
                return "Etat initial";
            return $"({this.MoveFromParent.i1}, {this.MoveFromParent.j1}) -> ({this.MoveFromParent.i2}, {this.MoveFromParent.j2})";
        }

    }
}
