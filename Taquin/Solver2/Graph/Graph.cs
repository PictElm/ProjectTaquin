using System.Collections.Generic;

namespace Solver2.Graph
{
    public class Graph<TMove>
    {

        public ANode<TMove> First { get; private set; }
        public ANode<TMove> Last { get; private set; }

        public List<ANode<TMove>> Opened { get; private set; }
        public List<ANode<TMove>> Closed { get; private set; }

        public Graph(ANode<TMove> init)
        {
            this.First = init;

            this.Opened = new List<ANode<TMove>>();
            this.Closed = new List<ANode<TMove>>();
        }

        public void Finish(ANode<TMove> final)
        {
            this.Last = final;
        }

        #region FindNode
        public ANode<TMove> FindIfExist(ANode<TMove> n)
        {
            if (this.Closed.Count < this.Opened.Count)
                return this.FindIfExistInClosed(n) ?? this.FindIfExistInOpened(n);
            return this.FindIfExistInOpened(n) ?? this.FindIfExistInClosed(n);
        }

        public ANode<TMove> FindIfExistInOpened(ANode<TMove> n)
        {
            foreach (var node in this.Opened)
                if (n.Equals(node))
                    return node;

            return null;
        }

        public ANode<TMove> FindIfExistInClosed(ANode<TMove> n)
        {
            foreach (var node in this.Closed)
                if (n.Equals(node))
                    return node;

            return null;
        }
        #endregion

    }
}
