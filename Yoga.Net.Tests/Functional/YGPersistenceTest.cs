using System.Diagnostics;
using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGPersistenceTest
    {
        [Test]
        public void cloning_shared_root()
        {
            YogaConfig config = YGConfigNew();
            YGConfigSetPrintTreeFlag(config, true);

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetFlexBasis(rootChild0, 50);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeInsertChild(root, rootChild1, 1);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(75, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(75, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(rootChild1));

            YogaNode root2 = YGNodeClone(root);
            YGNodeStyleSetWidth(root2, 100);

            Assert.AreEqual(2, YGNodeGetChildCount(root2));
            // The children should have referential equality at this point.
            Assert.AreEqual(rootChild0, root2.Children[0]);
            Assert.AreEqual(rootChild1, root2.Children[1]);

            YGNodeCalculateLayout(root2, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(2, YGNodeGetChildCount(root2));
            // Relayout with no changed input should result in referential equality.
            Assert.AreEqual(rootChild0, root2.Children[0]);
            Assert.AreEqual(rootChild1, root2.Children[1]);

            YGNodeStyleSetWidth(root2, 150);
            YGNodeStyleSetHeight(root2, 200);
            YGNodeCalculateLayout(root2, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(2, YGNodeGetChildCount(root2));
            // Relayout with changed input should result in cloned children.
            YogaNode root2Child0 = root2.Children[0];
            YogaNode root2Child1 = root2.Children[1];

            Assert.AreNotEqual(rootChild0, root2Child0);
            Assert.AreNotEqual(rootChild1, root2Child1);

            // Everything in the root should remain unchanged.
            Assert.AreEqual(0, YGNodeLayoutGetLeft(root));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(root));
            Assert.AreEqual(100, YGNodeLayoutGetHeight(root));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(rootChild0));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild0));
            Assert.AreEqual(75, YGNodeLayoutGetHeight(rootChild0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(rootChild1));
            Assert.AreEqual(75, YGNodeLayoutGetTop(rootChild1));
            Assert.AreEqual(100, YGNodeLayoutGetWidth(rootChild1));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(rootChild1));

            // The new root now has new layout.
            Assert.AreEqual(0, YGNodeLayoutGetLeft(root2));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root2));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root2));
            Assert.AreEqual(200, YGNodeLayoutGetHeight(root2));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root2Child0));
            Assert.AreEqual(0, YGNodeLayoutGetTop(root2Child0));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root2Child0));
            Assert.AreEqual(125, YGNodeLayoutGetHeight(root2Child0));

            Assert.AreEqual(0, YGNodeLayoutGetLeft(root2Child1));
            Assert.AreEqual(125, YGNodeLayoutGetTop(root2Child1));
            Assert.AreEqual(150, YGNodeLayoutGetWidth(root2Child1));
            Assert.AreEqual(75, YGNodeLayoutGetHeight(root2Child1));
        }

        [Test]
        public void mutating_children_of_a_clone_clones()
        {
            YogaConfig config = YGConfigNew();
            YGConfigSetPrintTreeFlag(config, true);

            YogaNode root = YGNodeNewWithConfig(config);
            Assert.AreEqual(0, YGNodeGetChildCount(root));

            YogaNode root2 = YGNodeClone(root);
            Assert.AreEqual(0, YGNodeGetChildCount(root2));

            YogaNode root2Child0 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root2, root2Child0, 0);

            Assert.AreEqual(0, YGNodeGetChildCount(root));
            Assert.AreEqual(1, YGNodeGetChildCount(root2));

            YogaNode root3 = YGNodeClone(root2);
            Assert.AreEqual(1, YGNodeGetChildCount(root2));
            Assert.AreEqual(1, YGNodeGetChildCount(root3));
            Assert.AreEqual(root2.Children[0], root3.Children[0]);

            YogaNode root3Child1 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root3, root3Child1, 1);
            Assert.AreEqual(1, YGNodeGetChildCount(root2));
            Assert.AreEqual(2, YGNodeGetChildCount(root3));
            Assert.AreEqual(root3Child1, root3.Children[1]);
            Assert.IsFalse(ReferenceEquals(root2.Children[0], root3.Children[1]));

            YogaNode root4 = YGNodeClone(root3);
            Assert.AreEqual(root3Child1, root4.Children[1]);

            YGNodeRemoveChild(root4, root3Child1);
            Assert.AreEqual(2, YGNodeGetChildCount(root3));
            Assert.AreEqual(1, YGNodeGetChildCount(root4));
            //Assert.IsFalse(ReferenceEquals(root3.Children[0], root4.Children[0]));
        }

        [Test]
        public void cloning_two_levels()
        {
            YogaConfig config = YGConfigNew();
            YGConfigSetPrintTreeFlag(config, true);

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild0, 1);
            YGNodeStyleSetFlexBasis(rootChild0, 15);
            YGNodeInsertChild(root, rootChild0, 0);

            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(rootChild1, 1);
            YGNodeInsertChild(root, rootChild1, 1);

            YogaNode rootChild10 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexBasis(rootChild10, 10);
            YGNodeStyleSetFlexGrow(rootChild10, 1);
            YGNodeInsertChild(rootChild1, rootChild10, 0);

            YogaNode rootChild11 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexBasis(rootChild11, 25);
            YGNodeInsertChild(rootChild1, rootChild11, 1);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(rootChild1));
            Assert.AreEqual(35, YGNodeLayoutGetHeight(rootChild10));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(rootChild11));

            YogaNode root2Child0 = YGNodeClone(rootChild0);
            YogaNode root2Child1 = YGNodeClone(rootChild1);
            YogaNode root2 = YGNodeClone(root);

            YGNodeStyleSetFlexGrow(root2Child0, 0);
            YGNodeStyleSetFlexBasis(root2Child0, 40);

            YGNodeRemoveAllChildren(root2);
            YGNodeInsertChild(root2, root2Child0, 0);
            YGNodeInsertChild(root2, root2Child1, 1);
            Assert.AreEqual(2, YGNodeGetChildCount(root2));

            YGNodeCalculateLayout(root2, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            // Original root is unchanged
            Assert.AreEqual(40, YGNodeLayoutGetHeight(rootChild0));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(rootChild1));
            Assert.AreEqual(35, YGNodeLayoutGetHeight(rootChild10));
            Assert.AreEqual(25, YGNodeLayoutGetHeight(rootChild11));

            // New root has new layout at the top
            Assert.AreEqual(40, YGNodeLayoutGetHeight(root2Child0));
            Assert.AreEqual(60, YGNodeLayoutGetHeight(root2Child1));

            // The deeper children are untouched.
            Assert.AreEqual(rootChild10, root2Child1.Children[0]);
            Assert.AreEqual(rootChild11, root2Child1.Children[1]);
        }

        [Test]
        public void cloning_and_freeing()
        {
            //int initialInstanceCount = YGNodeGetInstanceCount();

            YogaConfig config = YGConfigNew();
            YGConfigSetPrintTreeFlag(config, true);

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root, 100);
            YGNodeStyleSetHeight(root, 100);
            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, rootChild0, 0);
            YogaNode rootChild1 = YGNodeNewWithConfig(config);
            YGNodeInsertChild(root, rootChild1, 1);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            YogaNode root2 = YGNodeClone(root);

            // Freeing the original root should be safe as long as we don't free its
            // children.


            YGNodeCalculateLayout(root2, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            //Assert.AreEqual(initialInstanceCount, YGNodeGetInstanceCount());
        }
    }
}
