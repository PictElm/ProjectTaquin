using System.Collections.Generic;

namespace Solver2.Graph
{
    public class Graph<T_Move>
    {

        private INode<T_Move> init;
        private INode<T_Move> final;

        public List<INode<T_Move>> Opened { get; private set; }
        public List<INode<T_Move>> Closed { get; private set; }

        public Graph(INode<T_Move> init)
        {
            this.init = init;

            this.Opened = new List<INode<T_Move>>();
            this.Closed = new List<INode<T_Move>>();
        }

        public INode<T_Move> FindIfExist(INode<T_Move> n)
        {
            if (this.Closed.Count < this.Opened.Count)
                return this.FindIfExistInClosed(n) ?? this.FindIfExistInOpened(n);
            return this.FindIfExistInOpened(n) ?? this.FindIfExistInClosed(n);
        }

        public INode<T_Move> FindIfExistInOpened(INode<T_Move> n)
        {
            foreach (var node in this.Opened)
                if (n.SameAs(node))
                    return node;

            return null;
        }

        public INode<T_Move> FindIfExistInClosed(INode<T_Move> n)
        {
            foreach (var node in this.Closed)
                if (n.SameAs(node))
                    return node;

            return null;
        }

        public void Finish(INode<T_Move> final)
        {
            this.final = final;
        }

        public INode<T_Move> GetFinal()
        {
            return this.final;
        }

    }
}
