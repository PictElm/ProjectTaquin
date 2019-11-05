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

    }
}