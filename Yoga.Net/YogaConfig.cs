using System.Diagnostics;
using static Yoga.Net.YogaGlobal;

namespace Yoga.Net
{
    public class YogaConfig
    {
        public static YogaConfig DefaultConfig { get; } = new YogaConfig();

        public YogaCloneNodeFunc CloneNodeFunc { get; set; }
        public bool PrintTree { get; set; }

        /// <summary>
        /// Set this to number of pixels in 1 point to round calculation results If you
        /// want to avoid rounding - set PointScaleFactor to 0
        /// 
        /// We store points for Pixel as we will use it for rounding
        /// </summary>
        public float PointScaleFactor
        {
            get => _pointScaleFactor;
            set
            {
                Debug.Assert(value >= 0.0f,"Scale factor should not be less than zero");
                _pointScaleFactor = value;
            }
        }

        public bool[] ExperimentalFeatures { get; } = {false};
        public LoggerFunc LoggerFunc
        {
            get => _loggerFunc ?? Logger.DefaultLogger;
            set => _loggerFunc = value;
        }


        LoggerFunc _loggerFunc;
        float _pointScaleFactor = 1.0f;

        public YogaConfig(LoggerFunc logger = null)
        {
            LoggerFunc = logger;
        }

        public YogaConfig(YogaConfig config)
        {
            CloneNodeFunc = config.CloneNodeFunc;
            LoggerFunc    = config.LoggerFunc;
        }

        public void CopyFrom(YogaConfig config)
        {
            CloneNodeFunc = config.CloneNodeFunc;
            LoggerFunc    = config.LoggerFunc;
        }

        public void Log(LogLevel level, string message) => LoggerFunc?.Invoke(level, message);

        public YogaNode CloneNode(YogaNode node, YogaNode owner, int childIndex, object cloneContext)
        {
            YogaNode clone = CloneNodeFunc?.Invoke(node, owner, childIndex, cloneContext);
            return clone ?? YGNodeClone(node);
        }

        public override string ToString() => $"Config({PointScaleFactor:F2}; )";
    }
}
