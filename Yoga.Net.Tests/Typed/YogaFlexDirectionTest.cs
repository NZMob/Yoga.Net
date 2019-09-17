using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaFlexDirectionTest
    {
        [Test]
        public void flex_direction_column_no_height()
        {

            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(width: 100)
                           .Add(rootChild0 = Node(height: 10))
                           .Add(rootChild1 = Node(height: 10))
                           .Add(rootChild2 = Node(height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(30, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(10, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(20, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(30, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(10, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(20, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);
        }

        [Test]
        public void flex_direction_row_no_width()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(flexDirection:FlexDirection.Row, height: 100)
                           .Add(rootChild0 = Node(width: 10))
                           .Add(rootChild1 = Node(width: 10))
                           .Add(rootChild2 = Node(width: 10));
            
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(30, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(10, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(10, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            Assert.AreEqual(20, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(10, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(30, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(20, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(10, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(10, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(10, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);
        }

        [Test]
        public void flex_direction_column()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(width: 100, height:100)
                           .Add(rootChild0 = Node(height: 10))
                           .Add(rootChild1 = Node(height: 10))
                           .Add(rootChild2 = Node(height: 10));

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(10, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(20, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(10, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(20, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);
        }

        [Test]
        public void flex_direction_row()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(flexDirection:FlexDirection.Row, width: 100, height:100)
                           .Add(rootChild0 = Node(width: 10))
                           .Add(rootChild1 = Node(width: 10))
                           .Add(rootChild2 = Node(width: 10));
            
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(10, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(10, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            Assert.AreEqual(20, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(10, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(90, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(80, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(10, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            Assert.AreEqual(70, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(10, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);
        }

        [Test]
        public void flex_direction_column_reverse()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(flexDirection:FlexDirection.ColumnReverse, width: 100, height:100)
                           .Add(rootChild0 = Node(height: 10))
                           .Add(rootChild1 = Node(height: 10))
                           .Add(rootChild2 = Node(height: 10));
            
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(90, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(80, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(70, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(90, rootChild0.Layout.Top);
            Assert.AreEqual(100, rootChild0.Layout.Width);
            Assert.AreEqual(10, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild1.Layout.Left);
            Assert.AreEqual(80, rootChild1.Layout.Top);
            Assert.AreEqual(100, rootChild1.Layout.Width);
            Assert.AreEqual(10, rootChild1.Layout.Height);

            Assert.AreEqual(0, rootChild2.Layout.Left);
            Assert.AreEqual(70, rootChild2.Layout.Top);
            Assert.AreEqual(100, rootChild2.Layout.Width);
            Assert.AreEqual(10, rootChild2.Layout.Height);
        }

        [Test]
        public void flex_direction_row_reverse()
        {
            YogaNode rootChild0, rootChild1, rootChild2;
            YogaNode root = Node(flexDirection:FlexDirection.RowReverse, width: 100, height:100)
                           .Add(rootChild0 = Node(width: 10))
                           .Add(rootChild1 = Node(width: 10))
                           .Add(rootChild2 = Node(width: 10));
            
            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(90, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(80, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(10, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            Assert.AreEqual(70, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(10, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(100, root.Layout.Width);
            Assert.AreEqual(100, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(10, rootChild0.Layout.Width);
            Assert.AreEqual(100, rootChild0.Layout.Height);

            Assert.AreEqual(10, rootChild1.Layout.Left);
            Assert.AreEqual(0, rootChild1.Layout.Top);
            Assert.AreEqual(10, rootChild1.Layout.Width);
            Assert.AreEqual(100, rootChild1.Layout.Height);

            Assert.AreEqual(20, rootChild2.Layout.Left);
            Assert.AreEqual(0, rootChild2.Layout.Top);
            Assert.AreEqual(10, rootChild2.Layout.Width);
            Assert.AreEqual(100, rootChild2.Layout.Height);
        }
    }
}
