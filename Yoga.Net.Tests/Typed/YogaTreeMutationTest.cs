using NUnit.Framework;
using System.Collections.Generic;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaTreeMutationTest
    {
        static List<YogaNode> GetChildren(YogaNode node)
        {
            var count = node.ChildCount;
            List<YogaNode> children = new List<YogaNode>(count);
            for (int i = 0; i < count; i++)
                children.Add(node.Children[i]);
            return children;
        }

        [Test]
        public void set_children_adds_children_to_parent()
        {
            YogaNode root = new YogaNode();
            YogaNode rootChild0 = new YogaNode();
            YogaNode rootChild1 = new YogaNode();

            root.SetChildren(new[] {rootChild0, rootChild1});

            var children = GetChildren(root);
            var expectedChildren = new List<YogaNode> {rootChild0, rootChild1};
            Assert.AreEqual(children, expectedChildren);

            List<YogaNode> owners = new List<YogaNode> {rootChild0.Owner, rootChild1.Owner};
            List<YogaNode> expectedOwners = new List<YogaNode> {root, root};
            Assert.AreEqual(owners, expectedOwners);
        }

        [Test]
        public void set_children_to_empty_removes_old_children()
        {
            YogaNode root = new YogaNode();
            YogaNode rootChild0 = new YogaNode();
            YogaNode rootChild1 = new YogaNode();

            root.SetChildren(new [] {rootChild0, rootChild1});
            root.SetChildren(new YogaNode[] { });

            var children = GetChildren(root);
            var expectedChildren = new YogaNode[] { };
            Assert.AreEqual(children, expectedChildren);

            var owners = new [] {rootChild0.Owner, rootChild1.Owner};
            var expectedOwners = new YogaNode[] {null, null};
            Assert.AreEqual(owners, expectedOwners);
        }

        [Test]
        public void set_children_replaces_non_common_children()
        {
            YogaNode root = new YogaNode();
            YogaNode rootChild0 = new YogaNode();
            YogaNode rootChild1 = new YogaNode();
            YogaNode rootChild2 = new YogaNode();
            YogaNode rootChild3 = new YogaNode();

            rootChild0.LineIndex = 0;
            rootChild1.LineIndex = 1;
            rootChild2.LineIndex = 2;
            rootChild3.LineIndex = 3;

            root.SetChildren(new [] {rootChild0, rootChild1});
            root.SetChildren(new [] {rootChild2, rootChild3});

            var children = GetChildren(root);
            var expectedChildren = new [] {rootChild2, rootChild3};
            Assert.AreEqual(children, expectedChildren);

            var owners = new [] {rootChild0.Owner, rootChild1.Owner};
            var expectedOwners = new YogaNode[] {null, null};
            Assert.AreEqual(owners, expectedOwners);
        }

        [Test]
        public void set_children_keeps_and_reorders_common_children()
        {
            YogaNode root = new YogaNode();
            YogaNode rootChild0 = new YogaNode();
            YogaNode rootChild1 = new YogaNode();
            YogaNode rootChild2 = new YogaNode();
            YogaNode rootChild3 = new YogaNode();

            rootChild0.LineIndex = 0;
            rootChild1.LineIndex = 1;
            rootChild2.LineIndex = 2;
            rootChild3.LineIndex = 3;

            root.SetChildren(new [] {rootChild0, rootChild1, rootChild2});
            root.SetChildren(new [] {rootChild2, rootChild1, rootChild3});

            var children = GetChildren(root);
            var expectedChildren = new [] {rootChild2, rootChild1, rootChild3};
            Assert.AreEqual(children, expectedChildren);

            List<YogaNode> owners = new List<YogaNode>
            {
                rootChild0.Owner,
                rootChild1.Owner,
                rootChild2.Owner,
                rootChild3.Owner
            };
            var expectedOwners = new [] {null, root, root, root};
            Assert.AreEqual(owners, expectedOwners);
        }
    }
}
