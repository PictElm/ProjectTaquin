using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.Tests
{
    [TestClass()]
    public class GraphTests
    {

        [TestMethod()]
        public void FindIfExistTest_NotFound()
        {
            int[,] stateA = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            int[,] stateB = {
                { 1, 4, 6 },
                { 8, 2, 5 },
                { 7, 9, 3 }
            };

            Graph g = new Graph(new Node(stateA));
            g.Opened.Add(new Node(stateA));
            g.Closed.Add(new Node(stateA));

            Node notFound = g.FindIfExist(stateB);
            Assert.IsNull(notFound);
        }

        [TestMethod()]
        public void FindIfExistTest_FoundInOpened()
        {
            int[,] stateA = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            int[,] stateB = {
                { 1, 4, 6 },
                { 8, 2, 5 },
                { 7, 9, 3 }
            };

            Graph g = new Graph(new Node(stateA));
            g.Closed.Add(new Node(stateA));

            Node search = new Node(stateB);
            g.Opened.Add(search);

            Node found = g.FindIfExist(stateB);
            Assert.AreEqual(search, found);
        }

        [TestMethod()]
        public void FindIfExistTest_FoundInClosed()
        {
            int[,] stateA = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            int[,] stateB = {
                { 1, 4, 6 },
                { 8, 2, 5 },
                { 7, 9, 3 }
            };

            Graph g = new Graph(new Node(stateA));
            g.Opened.Add(new Node(stateA));

            Node search = new Node(stateB);
            g.Closed.Add(search);

            Node found = g.FindIfExist(stateB);
            Assert.AreEqual(search, found);
        }

    }
}