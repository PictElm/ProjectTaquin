using System.Collections.Generic;

namespace Solver2.Graph
{
    public class Graph<T_Node, T_Move> where T_Node : class, INode<T_Move>
    {

        private T_Node init;
        private T_Node final;

        public List<T_Node> Opened { get; private set; }
        public List<T_Node> Closed { get; private set; }

        public Graph(T_Node init)
        {
            this.init = init;

            this.Opened = new List<T_Node>();
            this.Closed = new List<T_Node>();
        }

        public T_Node FindIfExist(T_Node n)
        {
            if (this.Closed.Count < this.Opened.Count)
                return this.FindIfExistInClosed(n) ?? this.FindIfExistInOpened(n);
            return this.FindIfExistInOpened(n) ?? this.FindIfExistInClosed(n);
        }

        public T_Node FindIfExistInOpened(T_Node n)
        {
            foreach (var node in this.Opened)
                if (n.SameAs(node))
                    return node;

            return null;
        }

        public T_Node FindIfExistInClosed(T_Node n)
        {
            foreach (var node in this.Closed)
                if (n.SameAs(node))
                    return node;

            return null;
        }

        public void Finish(T_Node final)
        {
            this.final = final;
        }

        public T_Node GetFinal()
        {
            return this.final;
        }

    }
}
