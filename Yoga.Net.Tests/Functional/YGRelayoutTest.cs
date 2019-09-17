using NUnit.Framework;
using static Yoga.Net.YogaGlobal;


namespace Yoga.Net.Tests
{
    [TestFixture]
    public class YGRelayoutTest
    {
        [Test]
        public void do_not_cache_computed_flex_basis_between_layouts()
        {
            YogaConfig config = YGConfigNew();
            YGConfigSetExperimentalFeatureEnabled(config, ExperimentalFeature.WebFlexBasis, true);

            YogaNode root = YGNodeNewWithConfig(config);
            YGNodeStyleSetHeightPercent(root, 100);
            YGNodeStyleSetWidthPercent(root, 100);

            YogaNode rootChild0 = YGNodeNewWithConfig(config);
            YGNodeStyleSetFlexBasisPercent(rootChild0, 100);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, 100, YogaValue.YGUndefined, Direction.LTR);
            YGNodeCalculateLayout(root, 100, 100, Direction.LTR);

            Assert.AreEqual(100, YGNodeLayoutGetHeight(rootChild0));
        }

        [Test]
        public void recalculate_resolvedDimension_onchange()
        {
            YogaNode root = YGNodeNew();

            YogaNode rootChild0 = YGNodeNew();
            YGNodeStyleSetMinHeight(rootChild0, 10);
            YGNodeStyleSetMaxHeight(rootChild0, 10);
            YGNodeInsertChild(root, rootChild0, 0);

            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);
            Assert.AreEqual(10, YGNodeLayoutGetHeight(rootChild0));

            YGNodeStyleSetMinHeight(rootChild0, YogaValue.YGUndefined);
            YGNodeCalculateLayout(root, YogaValue.YGUndefined, YogaValue.YGUndefined, Direction.LTR);

            Assert.AreEqual(0, YGNodeLayoutGetHeight(rootChild0));
        }
    }
}
