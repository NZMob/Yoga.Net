using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaPersistenceTest
    {
        [Test]
        public void cloning_shared_root()
        {
            YogaConfig config = new YogaConfig {PrintTree = true};

            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(config, width: 100, height: 100)
                           .Add(rootChild0 = Node(flexGrow: 1, flexBasis: 50))
                           .Add(rootChild1 = Node(flexGrow: 1));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(75, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(75, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(25, rootChild1.Layout.Height);

            YogaNode root2 = YogaNode.Clone(root);
            root2.Style.Width = 100;

            Assert.AreEqual(2, root.ChildCount);
            // The children should have referential equality at this point.
            Assert.AreEqual(rootChild0, root2.Children[0]);
            Assert.AreEqual(rootChild1, root2.Children[1]);

            YogaArrange.CalculateLayout(root2, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(2, root.ChildCount);
            // Re-layout with no changed input should result in referential equality.
            Assert.AreEqual(rootChild0, root2.Children[0]);
            Assert.AreEqual(rootChild1, root2.Children[1]);

            root2.Style.Width = 150;
            root2.Style.Height = 200;
            YogaArrange.CalculateLayout(root2, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(2, root2.ChildCount);
            // Re-layout with changed input should result in cloned children.
            YogaNode root2Child0 = root2.Children[0];
            YogaNode root2Child1 = root2.Children[1];

            Assert.AreNotEqual(rootChild0, root2Child0);
            Assert.AreNotEqual(rootChild1, root2Child1);

            // Everything in the root should remain unchanged.
            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(75, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(75, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(25, rootChild1.Layout.Height);

            // The new root now has new layout.
            Assert.AreEqual(0, root2.Layout.Left);
            Assert.AreEqual(0, root2.Layout.Top);
            Assert.AreEqual(150, root2.Layout.Width);
            Assert.AreEqual(200, root2.Layout.Height);

            Assert.AreEqual(0, root2Child0.Layout.Left);
            Assert.AreEqual(0, root2Child0.Layout.Top);
            Assert.AreEqual(150, root2Child0.Layout.Width);
            Assert.AreEqual(125, root2Child0.Layout.Height);

            Assert.AreEqual(0, root2Child1.Layout.Left);
            Assert.AreEqual(125, root2Child1.Layout.Top);
            Assert.AreEqual(150, root2Child1.Layout.Width);
            Assert.AreEqual(75, root2Child1.Layout.Height);
        }

        [Test]
        public void mutating_children_of_a_clone_clones()
        {
            YogaConfig config = new YogaConfig
                { PrintTree = true };

            YogaNode root = Node(config);
            Assert.AreEqual(0, root.ChildCount);

            YogaNode root2 = YogaNode.Clone(root);
            Assert.AreEqual(0, root.ChildCount);

            YogaNode root2Child0 = new YogaNode(config);
            root2.Children.Add(root2Child0);

            Assert.AreEqual(0, root.ChildCount);
            Assert.AreEqual(1, root2.ChildCount);

            YogaNode root3 = YogaNode.Clone(root2);
            Assert.AreEqual(1, root2.ChildCount);
            Assert.AreEqual(1, root3.ChildCount);
            Assert.AreEqual(root2.Children[0], root3.Children[0]);

            YogaNode root3Child1 = new YogaNode(config);
            root3.Children.Add(root3Child1);
            Assert.AreEqual(1, root2.ChildCount);
            Assert.AreEqual(2, root3.ChildCount);
            Assert.AreEqual(root3Child1, root3.Children[1]);
            Assert.IsFalse(ReferenceEquals(root2.Children[0], root3.Children[1]));

            YogaNode root4 = YogaNode.Clone(root3);
            Assert.AreEqual(root3Child1, root4.Children[1]);

            root4.Children.Remove(root3Child1);
            Assert.AreEqual(2, root3.ChildCount);
            Assert.AreEqual(1, root4.ChildCount);
            //Assert.IsFalse(ReferenceEquals(root3.Children[0], root4.Children[0]));
        }

        [Test]
        public void cloning_two_levels()
        {
            YogaConfig config = new YogaConfig {PrintTree = true};

            YogaNode rootChild0, rootChild1, rootChild10, rootChild11;
            YogaNode root =
                Node(config, width: 100, height: 100)
                   .Add(rootChild0 = Node(config, flexGrow: 1, flexBasis: 15))
                   .Add(rootChild1 = Node(config, flexGrow: 1)
                                     .Add(rootChild10 = Node(config, flexBasis: 10, flexGrow: 1))
                                     .Add(rootChild11 = Node(config, flexBasis: 25)));


            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(40, rootChild0.Layout.Height);
            Assert.AreEqual(60, rootChild1.Layout.Height);
            Assert.AreEqual(35, rootChild10.Layout.Height);
            Assert.AreEqual(25, rootChild11.Layout.Height);

            YogaNode root2Child0 = YogaNode.Clone(rootChild0);
            YogaNode root2Child1 = YogaNode.Clone(rootChild1);
            YogaNode root2 = YogaNode.Clone(root);

            root2Child0.Style.FlexGrow = 0;
            root2Child0.Style.FlexBasis = 40;

            root2.Children.Clear();
            root2.Children.Add(root2Child0);
            root2.Children.Add(root2Child1);
            Assert.AreEqual(2, root.ChildCount);

            YogaArrange.CalculateLayout(root2, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            // Original root is unchanged
            Assert.AreEqual(40, rootChild0.Layout.Height);
            Assert.AreEqual(60, rootChild1.Layout.Height);
            Assert.AreEqual(35, rootChild10.Layout.Height);
            Assert.AreEqual(25, rootChild11.Layout.Height);

            // New root has new layout at the top
            Assert.AreEqual(40, root2Child0.Layout.Height);
            Assert.AreEqual(60, root2Child1.Layout.Height);

            // The deeper children are untouched.
            Assert.AreEqual(rootChild10, root2Child1.Children[0]);
            Assert.AreEqual(rootChild11, root2Child1.Children[1]);
        }

        [Test]
        public void cloning_and_freeing()
        {
            YogaConfig config = new YogaConfig {PrintTree = true};

            YogaNode root = Node(config, width: 100, height: 100)
                           .Add(Node(config))
                           .Add(Node(config));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            YogaNode root2 = YogaNode.Clone(root);

            YogaArrange.CalculateLayout(root2, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
        }
    }
}
