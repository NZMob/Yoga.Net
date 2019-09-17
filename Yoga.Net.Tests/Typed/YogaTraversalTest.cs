using System.Collections.Generic;
using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaTraversalTest
    {
        [Test]
        public void pre_order_traversal()
        {
            YogaNode rootChild0, rootChild1, rootChild0Child0;
            YogaNode root = Node()
                      .Add(rootChild0 = Node()
                              .Add(rootChild0Child0 = Node()))
                      .Add(rootChild1 = Node());

            List<YogaNode> visited = new List<YogaNode>();
            root.TraversePreOrder(node => visited.Add(node));

            YogaNode[] expected = 
            {
                root,
                rootChild0,
                rootChild0Child0,
                rootChild1
            };
            Assert.AreEqual(visited, expected);
        }
    }
}
