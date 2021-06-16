using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mview
{
    public class MapStyle
    {
        public bool showGridLines = true;
        public bool showAllWelltrack = true;
        public bool showBubbles = true;
        public bool showNoFillColor = false;
        public bool showVectorField = false;

        public BubbleMode bubbleMode = BubbleMode.Simulation;
        public float minValue = 0;
        public float maxValue = 1;
        public float scaleFactor = 30;
        public float zscale = 12;
        public float stretchFactor = 0;
    }
}
