using NUnit.Framework;
using static Yoga.Net.YogaBuild;

namespace Yoga.Net.Tests.Typed
{
    [TestFixture]
    public class YogaAndroidNewsFeed
    {
        [Test]
        public void android_news_feed()
        {
            YogaNode rootChild0,
                rootChild0Child0,
                rootChild0Child0Child0,
                rootChild0Child0Child0Child0,
                rootChild0Child0Child0Child0Child0,
                rootChild0Child0Child0Child0Child0Child0,
                rootChild0Child0Child0Child0Child1,
                rootChild0Child0Child0Child0Child1Child0,
                rootChild0Child0Child0Child0Child1Child1,
                rootChild0Child0Child1,
                rootChild0Child0Child1Child0,
                rootChild0Child0Child1Child0Child0,
                rootChild0Child0Child1Child0Child0Child0,
                rootChild0Child0Child1Child0Child1,
                rootChild0Child0Child1Child0Child1Child0,
                rootChild0Child0Child1Child0Child1Child1;
            YogaNode root = Node(alignContent: YogaAlign.Stretch, width: 1080)
               .Add(rootChild0 = Node()
                   .Add(rootChild0Child0 = Node(alignContent: YogaAlign.Stretch)
                       .Add(rootChild0Child0Child0 = Node(alignContent: YogaAlign.Stretch)
                           .Add(rootChild0Child0Child0Child0 = Node(flexDirection: FlexDirection.Row, alignContent: YogaAlign.Stretch, alignItems: YogaAlign.FlexStart, margin: new Edges(start: 36, top: 24))
                               .Add(rootChild0Child0Child0Child0Child0 = Node(flexDirection: FlexDirection.Row,alignContent: YogaAlign.Stretch)
                                   .Add(rootChild0Child0Child0Child0Child0Child0 = Node(alignContent: YogaAlign.Stretch,width: 120,height: 120))
                                )
                                .Add(rootChild0Child0Child0Child0Child1 = Node(alignContent: YogaAlign.Stretch,flexShrink: 1,margin: new Edges(right: 36),padding: new Edges(left: 36, top: 21, right: 36, bottom: 18))
                                    .Add(rootChild0Child0Child0Child0Child1Child0 = Node(flexDirection: FlexDirection.Row,alignContent: YogaAlign.Stretch,flexShrink: 1))
                                    .Add(rootChild0Child0Child0Child0Child1Child1 = Node(alignContent: YogaAlign.Stretch,flexShrink: 1))
                                )
                            )
                       )
                       .Add(rootChild0Child0Child1 = Node(alignContent: YogaAlign.Stretch)
                           .Add(rootChild0Child0Child1Child0 = Node(flexDirection: FlexDirection.Row,alignContent: YogaAlign.Stretch,alignItems: YogaAlign.FlexStart,margin: new Edges(start: 174, top: 24))
                               .Add(rootChild0Child0Child1Child0Child0 = Node(flexDirection: FlexDirection.Row,alignContent: YogaAlign.Stretch)
                                   .Add(rootChild0Child0Child1Child0Child0Child0 = Node(alignContent: YogaAlign.Stretch,width: 72,height: 72))
                               )
                               .Add(rootChild0Child0Child1Child0Child1 = Node(alignContent: YogaAlign.Stretch,flexShrink: 1,margin: new Edges(right: 36),padding: new Edges(left: 36, top: 21, right: 36, bottom: 18))
                                   .Add(rootChild0Child0Child1Child0Child1Child0 = Node(flexDirection: FlexDirection.Row,alignContent: YogaAlign.Stretch,flexShrink: 1))
                                   .Add(rootChild0Child0Child1Child0Child1Child1 = Node(alignContent: YogaAlign.Stretch,flexShrink: 1))
                               )
                           )
                       )
                   )
               );

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(1080, root.Layout.Width);
            Assert.AreEqual(240, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(1080, rootChild0.Layout.Width);
            Assert.AreEqual(240, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(1080, rootChild0Child0.Layout.Width);
            Assert.AreEqual(240, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(1080, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(144, rootChild0Child0Child0.Layout.Height);

            Assert.AreEqual(36, rootChild0Child0Child0Child0.Layout.Left);
            Assert.AreEqual(24, rootChild0Child0Child0Child0.Layout.Top);
            Assert.AreEqual(1044, rootChild0Child0Child0Child0.Layout.Width);
            Assert.AreEqual(120, rootChild0Child0Child0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0Child0Child0.Layout.Top);
            Assert.AreEqual(120, rootChild0Child0Child0Child0Child0.Layout.Width);
            Assert.AreEqual(120, rootChild0Child0Child0Child0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0Child0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0Child0Child0Child0.Layout.Top);
            Assert.AreEqual(120, rootChild0Child0Child0Child0Child0Child0.Layout.Width);
            Assert.AreEqual(120, rootChild0Child0Child0Child0Child0Child0.Layout.Height);

            Assert.AreEqual(120, rootChild0Child0Child0Child0Child1.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0Child0Child1.Layout.Top);
            Assert.AreEqual(72, rootChild0Child0Child0Child0Child1.Layout.Width);
            Assert.AreEqual(39, rootChild0Child0Child0Child0Child1.Layout.Height);

            Assert.AreEqual(36, rootChild0Child0Child0Child0Child1Child0.Layout.Left);
            Assert.AreEqual(21, rootChild0Child0Child0Child0Child1Child0.Layout.Top);
            Assert.AreEqual(0, rootChild0Child0Child0Child0Child1Child0.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0Child0Child0Child1Child0.Layout.Height);

            Assert.AreEqual(36, rootChild0Child0Child0Child0Child1Child1.Layout.Left);
            Assert.AreEqual(21, rootChild0Child0Child0Child0Child1Child1.Layout.Top);
            Assert.AreEqual(0, rootChild0Child0Child0Child0Child1Child1.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0Child0Child0Child1Child1.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child1.Layout.Left);
            Assert.AreEqual(144, rootChild0Child0Child1.Layout.Top);
            Assert.AreEqual(1080, rootChild0Child0Child1.Layout.Width);
            Assert.AreEqual(96, rootChild0Child0Child1.Layout.Height);

            Assert.AreEqual(174, rootChild0Child0Child1Child0.Layout.Left);
            Assert.AreEqual(24, rootChild0Child0Child1Child0.Layout.Top);
            Assert.AreEqual(906, rootChild0Child0Child1Child0.Layout.Width);
            Assert.AreEqual(72, rootChild0Child0Child1Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child1Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child1Child0Child0.Layout.Top);
            Assert.AreEqual(72, rootChild0Child0Child1Child0Child0.Layout.Width);
            Assert.AreEqual(72, rootChild0Child0Child1Child0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child1Child0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child1Child0Child0Child0.Layout.Top);
            Assert.AreEqual(72, rootChild0Child0Child1Child0Child0Child0.Layout.Width);
            Assert.AreEqual(72, rootChild0Child0Child1Child0Child0Child0.Layout.Height);

            Assert.AreEqual(72, rootChild0Child0Child1Child0Child1.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child1Child0Child1.Layout.Top);
            Assert.AreEqual(72, rootChild0Child0Child1Child0Child1.Layout.Width);
            Assert.AreEqual(39, rootChild0Child0Child1Child0Child1.Layout.Height);

            Assert.AreEqual(36, rootChild0Child0Child1Child0Child1Child0.Layout.Left);
            Assert.AreEqual(21, rootChild0Child0Child1Child0Child1Child0.Layout.Top);
            Assert.AreEqual(0, rootChild0Child0Child1Child0Child1Child0.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0Child1Child0Child1Child0.Layout.Height);

            Assert.AreEqual(36, rootChild0Child0Child1Child0Child1Child1.Layout.Left);
            Assert.AreEqual(21, rootChild0Child0Child1Child0Child1Child1.Layout.Top);
            Assert.AreEqual(0, rootChild0Child0Child1Child0Child1Child1.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0Child1Child0Child1Child1.Layout.Height);

            YogaArrange.CalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.RTL);

            Assert.AreEqual(0, root.Layout.Left);
            Assert.AreEqual(0, root.Layout.Top);
            Assert.AreEqual(1080, root.Layout.Width);
            Assert.AreEqual(240, root.Layout.Height);

            Assert.AreEqual(0, rootChild0.Layout.Left);
            Assert.AreEqual(0, rootChild0.Layout.Top);
            Assert.AreEqual(1080, rootChild0.Layout.Width);
            Assert.AreEqual(240, rootChild0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0.Layout.Top);
            Assert.AreEqual(1080, rootChild0Child0.Layout.Width);
            Assert.AreEqual(240, rootChild0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0.Layout.Top);
            Assert.AreEqual(1080, rootChild0Child0Child0.Layout.Width);
            Assert.AreEqual(144, rootChild0Child0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0Child0.Layout.Left);
            Assert.AreEqual(24, rootChild0Child0Child0Child0.Layout.Top);
            Assert.AreEqual(1044, rootChild0Child0Child0Child0.Layout.Width);
            Assert.AreEqual(120, rootChild0Child0Child0Child0.Layout.Height);

            Assert.AreEqual(924, rootChild0Child0Child0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0Child0Child0.Layout.Top);
            Assert.AreEqual(120, rootChild0Child0Child0Child0Child0.Layout.Width);
            Assert.AreEqual(120, rootChild0Child0Child0Child0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child0Child0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0Child0Child0Child0.Layout.Top);
            Assert.AreEqual(120, rootChild0Child0Child0Child0Child0Child0.Layout.Width);
            Assert.AreEqual(120, rootChild0Child0Child0Child0Child0Child0.Layout.Height);

            Assert.AreEqual(816, rootChild0Child0Child0Child0Child1.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child0Child0Child1.Layout.Top);
            Assert.AreEqual(72, rootChild0Child0Child0Child0Child1.Layout.Width);
            Assert.AreEqual(39, rootChild0Child0Child0Child0Child1.Layout.Height);

            Assert.AreEqual(36, rootChild0Child0Child0Child0Child1Child0.Layout.Left);
            Assert.AreEqual(21, rootChild0Child0Child0Child0Child1Child0.Layout.Top);
            Assert.AreEqual(0, rootChild0Child0Child0Child0Child1Child0.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0Child0Child0Child1Child0.Layout.Height);

            Assert.AreEqual(36, rootChild0Child0Child0Child0Child1Child1.Layout.Left);
            Assert.AreEqual(21, rootChild0Child0Child0Child0Child1Child1.Layout.Top);
            Assert.AreEqual(0, rootChild0Child0Child0Child0Child1Child1.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0Child0Child0Child1Child1.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child1.Layout.Left);
            Assert.AreEqual(144, rootChild0Child0Child1.Layout.Top);
            Assert.AreEqual(1080, rootChild0Child0Child1.Layout.Width);
            Assert.AreEqual(96, rootChild0Child0Child1.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child1Child0.Layout.Left);
            Assert.AreEqual(24, rootChild0Child0Child1Child0.Layout.Top);
            Assert.AreEqual(906, rootChild0Child0Child1Child0.Layout.Width);
            Assert.AreEqual(72, rootChild0Child0Child1Child0.Layout.Height);

            Assert.AreEqual(834, rootChild0Child0Child1Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child1Child0Child0.Layout.Top);
            Assert.AreEqual(72, rootChild0Child0Child1Child0Child0.Layout.Width);
            Assert.AreEqual(72, rootChild0Child0Child1Child0Child0.Layout.Height);

            Assert.AreEqual(0, rootChild0Child0Child1Child0Child0Child0.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child1Child0Child0Child0.Layout.Top);
            Assert.AreEqual(72, rootChild0Child0Child1Child0Child0Child0.Layout.Width);
            Assert.AreEqual(72, rootChild0Child0Child1Child0Child0Child0.Layout.Height);

            Assert.AreEqual(726, rootChild0Child0Child1Child0Child1.Layout.Left);
            Assert.AreEqual(0, rootChild0Child0Child1Child0Child1.Layout.Top);
            Assert.AreEqual(72, rootChild0Child0Child1Child0Child1.Layout.Width);
            Assert.AreEqual(39, rootChild0Child0Child1Child0Child1.Layout.Height);

            Assert.AreEqual(36, rootChild0Child0Child1Child0Child1Child0.Layout.Left);
            Assert.AreEqual(21, rootChild0Child0Child1Child0Child1Child0.Layout.Top);
            Assert.AreEqual(0, rootChild0Child0Child1Child0Child1Child0.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0Child1Child0Child1Child0.Layout.Height);

            Assert.AreEqual(36, rootChild0Child0Child1Child0Child1Child1.Layout.Left);
            Assert.AreEqual(21, rootChild0Child0Child1Child0Child1Child1.Layout.Top);
            Assert.AreEqual(0, rootChild0Child0Child1Child0Child1Child1.Layout.Width);
            Assert.AreEqual(0, rootChild0Child0Child1Child0Child1Child1.Layout.Height);
        }
    }
}
