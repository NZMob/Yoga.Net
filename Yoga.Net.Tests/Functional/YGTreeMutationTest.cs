using NUnit.Framework;
using static Yoga.Net.YogaGlobal;
using System.Collections.Generic;

namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGTreeMutationTest
    {
        static List<YogaNode> GetChildren(YogaNode node)
        {
            var count = YGNodeGetChildCount(node);
            List<YogaNode> children = new List<YogaNode>(count);
            for (int i = 0; i < count; i++)
                children.Add(node.Children[i]);
            return children;
        }

        [Test]
        public void set_children_adds_children_to_parent()
        {
            YogaNode root = YGNodeNew();
            YogaNode rootChild0 = YGNodeNew();
            YogaNode rootChild1 = YGNodeNew();

            YGNodeSetChildren(root, new List<YogaNode> {rootChild0, rootChild1});

            List<YogaNode> children = GetChildren(root);
            List<YogaNode> expectedChildren = new List<YogaNode> {rootChild0, rootChild1};
            Assert.AreEqual(children, expectedChildren);

            List<YogaNode> owners = new List<YogaNode> {YGNodeGetOwner(rootChild0), YGNodeGetOwner(rootChild1)};
            List<YogaNode> expectedOwners = new List<YogaNode> {root, root};
            Assert.AreEqual(owners, expectedOwners);
        }

        [Test]
        public void set_children_to_empty_removes_old_children()
        {
            YogaNode root = YGNodeNew();
            YogaNode rootChild0 = YGNodeNew();
            YogaNode rootChild1 = YGNodeNew();

            YGNodeSetChildren(root, new List<YogaNode> {rootChild0, rootChild1});
            YGNodeSetChildren(root, new List<YogaNode> { });

            List<YogaNode> children = GetChildren(root);
            List<YogaNode> expectedChildren = new List<YogaNode> { };
            Assert.AreEqual(children, expectedChildren);

            List<YogaNode> owners = new List<YogaNode> {YGNodeGetOwner(rootChild0), YGNodeGetOwner(rootChild1)};
            List<YogaNode> expectedOwners = new List<YogaNode> {null, null};
            Assert.AreEqual(owners, expectedOwners);
        }

        [Test]
        public void set_children_replaces_non_common_children()
        {
            YogaNode root = YGNodeNew();
            YogaNode rootChild0 = YGNodeNew();
            YogaNode rootChild1 = YGNodeNew();
            YogaNode rootChild2 = YGNodeNew();
            YogaNode rootChild3 = YGNodeNew();

            rootChild0.LineIndex = 0;
            rootChild1.LineIndex = 1;
            rootChild2.LineIndex = 2;
            rootChild3.LineIndex = 3;

            YGNodeSetChildren(root, new List<YogaNode> {rootChild0, rootChild1});

            YGNodeSetChildren(root, new List<YogaNode> {rootChild2, rootChild3});

            List<YogaNode> children = GetChildren(root);
            List<YogaNode> expectedChildren = new List<YogaNode> {rootChild2, rootChild3};
            Assert.AreEqual(children, expectedChildren);

            List<YogaNode> owners = new List<YogaNode> {YGNodeGetOwner(rootChild0), YGNodeGetOwner(rootChild1)};
            List<YogaNode> expectedOwners = new List<YogaNode> {null, null};
            Assert.AreEqual(owners, expectedOwners);
        }

        [Test]
        public void set_children_keeps_and_reorders_common_children()
        {
            YogaNode root = YGNodeNew();
            YogaNode rootChild0 = YGNodeNew();
            YogaNode rootChild1 = YGNodeNew();
            YogaNode rootChild2 = YGNodeNew();
            YogaNode rootChild3 = YGNodeNew();

            rootChild0.LineIndex = 0;
            rootChild1.LineIndex = 1;
            rootChild2.LineIndex = 2;
            rootChild3.LineIndex = 3;

            YGNodeSetChildren(root, new YogaNode[] {rootChild0, rootChild1, rootChild2});

            YGNodeSetChildren(root, new YogaNode[] {rootChild2, rootChild1, rootChild3});

            List<YogaNode> children = GetChildren(root);
            List<YogaNode> expectedChildren = new List<YogaNode> {rootChild2, rootChild1, rootChild3};
            Assert.AreEqual(children, expectedChildren);

            List<YogaNode> owners = new List<YogaNode>
            {
                YGNodeGetOwner(rootChild0),
                YGNodeGetOwner(rootChild1),
                YGNodeGetOwner(rootChild2),
                YGNodeGetOwner(rootChild3)
            };
            var expectedOwners = new List<YogaNode> {null, root, root, root};
            Assert.AreEqual(owners, expectedOwners);
        }
    }
}
