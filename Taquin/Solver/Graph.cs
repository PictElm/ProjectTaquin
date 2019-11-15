using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    public class Graph
    {

        private Node init;
        private Node final;

        public List<Node> Opened { get; private set; }
        public List<Node> Closed { get; private set; }

        public Graph(Node init)
        {
            this.init = init;

            this.Opened = new List<Node>();
            this.Closed = new List<Node>();
        }

        public Node FindIfExist(int[,] grid)
        {
            return this.FindIfExist(new Node(grid));
        }

        public Node FindIfExist(Node n)
        {
            if (this.Closed.Count < this.Opened.Count)
                return this.FindIfExistInClosed(n) ?? this.FindIfExistInOpened(n);
            return this.FindIfExistInOpened(n) ?? this.FindIfExistInClosed(n);
        }

        public Node FindIfExistInOpened(Node n)
        {
            foreach (var node in this.Opened)
                if (n == node)
                    return node;

            return null;
        }

        public Node FindIfExistInClosed(Node n)
        {
            foreach (var node in this.Closed)
                if (n == node)
                    return node;

            return null;
        }

        public void Finish(Node final)
        {
            this.final = final;
        }

        public Node GetFinal()
        {
            return this.final;
        }

    }
}
