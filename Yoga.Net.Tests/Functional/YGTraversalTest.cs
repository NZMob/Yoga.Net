using NUnit.Framework;
using static Yoga.Net.YogaGlobal;
using System.Collections.Generic;

namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGTraversalTest
    {
        [Test]
        public void pre_order_traversal()
        {
            YogaNode root = YGNodeNew();
            YogaNode rootChild0 = YGNodeNew();
            YogaNode rootChild1 = YGNodeNew();
            YogaNode rootChild0Child0 = YGNodeNew();

            YGNodeSetChildren(root, new List<YogaNode> {rootChild0, rootChild1});
            YGNodeInsertChild(rootChild0, rootChild0Child0, 0);

            List<YogaNode> visited = new List<YogaNode>();
            root.TraversePreOrder(node => visited.Add(node));

            YogaNode[] expected = new YogaNode[]
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
