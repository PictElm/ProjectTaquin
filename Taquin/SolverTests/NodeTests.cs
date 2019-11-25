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
    public class NodeTests
    {

        [TestMethod()]
        public void AttachTest()
        {
            Node parent = new Node(new int[0, 0]);
            Node child = new Node(new int[0, 0]);

            parent.Attach(child, new int[] { 0, 0, 0, 1 });

            Assert.AreEqual(parent, child.Parent);
            Assert.AreEqual(parent.MoveCount + 1, child.MoveCount);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            int[,] g1 = { { 1, 2 }, { 3, 4 } };
            int[,] g2 = { { 3, 1 }, { 4, 2 } };
            int[,] gT = { { 1, -1 }, { -1, 4 } };

            Node n1 = new Node(g1);
            Node n2 = new Node(g2);

            Assert.IsTrue(n1 == new Node(g1));
            Assert.IsTrue(n1 != n2);

            Node nT = new Node(gT);

            Assert.IsTrue(nT == n1);
            Assert.IsTrue(nT != n2);
        }

    }
}