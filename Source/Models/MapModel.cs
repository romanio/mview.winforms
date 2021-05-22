using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mview
{
    public enum BubbleMode
    {
        Simulation,
        Historical,
        SimVSHist
    }

    public class MapStyle
    {
        public bool showGridLines = true;
        public bool showAllWelltrack = true;
        public bool showBubbles = true;
        public bool showNoFillColor = false;
        public bool showVectorField = false;

        public BubbleMode bubbleMode = BubbleMode.Simulation;
        public double minValue = 0;
        public double maxValue = 1;
        public double scaleFactor = 30;
        public double ZScale = 12;
        public double stretchFactor = 0;
    }

    public class MapModel
    {
        private readonly EclipseProject ecl;

        public MapModel(EclipseProject ecl)
        {
            this.ecl = ecl;
        }
    }
}
