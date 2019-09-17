using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGLayoutDiffingTest
    {
        /*
        [Test] public void assert_layout_trees_are_same() {
            var config = YGConfigNew();
            YGConfigSetUseLegacyStretchBehaviour(config, true);
            YGNode root1 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root1, 500);
            YGNodeStyleSetHeight(root1, 500);

            YGNode root1_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root1_child0, YGAlign.FlexStart);
            YGNodeInsertChild(root1, root1_child0, 0);

            YGNode root1_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root1_child0_child0, 1);
            YGNodeStyleSetFlexShrink(root1_child0_child0, 1);
            YGNodeInsertChild(root1_child0, root1_child0_child0, 0);

            YGNode root1_child0_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root1_child0_child0_child0, 1);
            YGNodeStyleSetFlexShrink(root1_child0_child0_child0, 1);
            YGNodeInsertChild(root1_child0_child0, root1_child0_child0_child0, 0);

            //int cal1_configInstanceCount = YGConfigGetInstanceCount();
            //int cal1_nodeInstanceCount = YGNodeGetInstanceCount();

            YGNodeCalculateLayout(root1, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            //Assert.AreEqual(YGConfigGetInstanceCount(), cal1_configInstanceCount);
            //Assert.AreEqual(YGNodeGetInstanceCount(), cal1_nodeInstanceCount);

            YGNode root2 = YGNodeNewWithConfig(config);
            YGNodeStyleSetWidth(root2, 500);
            YGNodeStyleSetHeight(root2, 500);

            YGNode root2_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetAlignItems(root2_child0, YGAlign.FlexStart);
            YGNodeInsertChild(root2, root2_child0, 0);

            YGNode root2_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root2_child0_child0, 1);
            YGNodeStyleSetFlexShrink(root2_child0_child0, 1);
            YGNodeInsertChild(root2_child0, root2_child0_child0, 0);

            YGNode root2_child0_child0_child0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexGrow(root2_child0_child0_child0, 1);
            YGNodeStyleSetFlexShrink(root2_child0_child0_child0, 1);
            YGNodeInsertChild(root2_child0_child0, root2_child0_child0_child0, 0);

            //int cal2_configInstanceCount = YGConfigGetInstanceCount();
            //int cal2_nodeInstanceCount = YGNodeGetInstanceCount();

            YGNodeCalculateLayout(root2, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            //Assert.AreEqual(YGConfigGetInstanceCount(), cal2_configInstanceCount);
            //Assert.AreEqual(YGNodeGetInstanceCount(), cal2_nodeInstanceCount);

            Assert.IsTrue(YGNodeLayoutGetDidUseLegacyFlag(root1));
            Assert.IsTrue(YGNodeLayoutGetDidUseLegacyFlag(root2));
            Assert.IsTrue(root1.isLayoutTreeEqualToNode(root2));

            YGNodeStyleSetAlignItems(root2, YGAlign.FlexEnd);

            //int cal3_configInstanceCount = YGConfigGetInstanceCount();
            //int cal3_nodeInstanceCount = YGNodeGetInstanceCount();

            YGNodeCalculateLayout(root2, YGValue.YGUndefined, YGValue.YGUndefined, YGDirection.LTR);

            //Assert.AreEqual(YGConfigGetInstanceCount(), cal3_configInstanceCount);
            //Assert.AreEqual(YGNodeGetInstanceCount(), cal3_nodeInstanceCount);

            Assert.IsFalse(root1.isLayoutTreeEqualToNode(root2));
        }
        */
    }
}
