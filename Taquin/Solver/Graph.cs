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
            String test = new Node(grid).ToString();

            foreach (var node in this.Opened)
                if (node.ToString() == test)
                    return node;

            foreach (var node in this.Closed)
                if (node.ToString() == test)
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
