using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaDirtyMarkingTest
    {
        [Test]
        public void dirty_propagation()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
                           .Add(rootChild0 = Node(width:50, height:20))
                           .Add(rootChild1 = Node(width:50, height:20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);


            rootChild0.Style.Width = 20;

            Assert.IsTrue(rootChild0.IsDirty);
            Assert.IsFalse(rootChild1.IsDirty);
            Assert.IsTrue(root.IsDirty);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.IsFalse(rootChild0.IsDirty);
            Assert.IsFalse(rootChild1.IsDirty);
            Assert.IsFalse(root.IsDirty);
        }

        [Test]
        public void dirty_propagation_only_if_prop_changed()
        {
            YogaNode rootChild0, rootChild1;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 100, height: 100)
                           .Add(rootChild0 = Node(width:50, height:20))
                           .Add(rootChild1 = Node(width:50, height:20));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            rootChild0.Style.Width = 50;

            Assert.IsFalse(rootChild0.IsDirty);
            Assert.IsFalse(rootChild1.IsDirty);
            Assert.IsFalse(root.IsDirty);
        }

        [Test]
        public void dirty_mark_all_children_as_dirty_when_display_changes()
        {
            YogaNode child0, child1, child1Child0Child0;
            YogaNode root = Node(flexDirection: FlexDirection.Row, height: 100)
                           .Add(child0 = Node(flexGrow: 1))
                           .Add(child1 = Node(flexGrow: 1, display:Display.None)
                                   .Add(Node()
                                           .Add(child1Child0Child0 = Node(width:8, height:16))
                                        )
                            );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, child1Child0Child0.Layout.Width);
            Assert.AreEqual(0, child1Child0Child0.Layout.Height);


            child0.Style.Display = Display.None;
            child1.Style.Display = Display.Flex;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(8, child1Child0Child0.Layout.Width);
            Assert.AreEqual(16, child1Child0Child0.Layout.Height);

            child0.Style.Display = Display.Flex;
            child1.Style.Display = Display.None;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, child1Child0Child0.Layout.Width);
            Assert.AreEqual(0, child1Child0Child0.Layout.Height);

            child0.Style.Display = Display.None;
            child1.Style.Display = Display.Flex;

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(8, child1Child0Child0.Layout.Width);
            Assert.AreEqual(16, child1Child0Child0.Layout.Height);
        }

        [Test]
        public void dirty_node_only_if_children_are_actually_removed()
        {
            YogaNode child0;
            YogaNode root = Node(alignItems: YogaAlign.FlexStart, width: 50, height: 50)
               .Add(child0 = Node(width:50, height:25));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            YogaNode child1 = Node();
            root.RemoveChild(child1);

            Assert.IsFalse(root.IsDirty);
            
            root.RemoveChild(child0);
            Assert.IsTrue(root.IsDirty);
        }

        [Test]
        public void dirty_node_only_if_undefined_values_gets_set_to_undefined()
        {
            YogaNode root = Node(width:50, height:50, minWidth:YogaValue.YGUndefined);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.IsFalse(root.IsDirty);

            root.Style.MinWidth = YogaValue.YGUndefined;

            Assert.IsFalse(root.IsDirty);
        }
    }
}
