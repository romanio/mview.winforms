using System;
using System.Collections.Generic;
using OpenTK;
using mview.ECL;

namespace mview
{
    public interface ICellStrategy
    {
        int NX
        {
            get;
        }
        int NY
        {
            get;
        }
        int Slice
        {
            set;
        }
        Vector2 DxDy 
        {
            set;
        }
        Vector2 MinPoint
        {
            set;
        }

        float StretchFactor { set; }
        List<Vector2> Points { get; }
        long Index { get; }
        void SetEclipse(EclipseProject ecl);
        bool Extract(int X, int Y);
    }

    public abstract class CellViewModeBaseStrategy: ICellStrategy
    {
        protected EclipseProject ecl;
        protected List<Vector2> points;
        protected Cell cell;
        protected int S;
        protected float sf;
        protected float xmin, ymin;
        protected float dx, dy;
        protected long index;
        
        public abstract int NX { get; }
        public abstract int NY { get; }
        public List<Vector2> Points => this.points;
        public long Index => this.index;

        public int Slice
        {
            set => S = value;
        }

        public float StretchFactor
        {
            set => sf = value;
        }

        public Vector2 DxDy
        {
            set
            {
                dx = value.X;
                dy = value.Y;
            }
        }

        public Vector2 MinPoint
        {
            set
            {
                xmin = value.X;
                ymin = value.Y;
            }
        }

        public void SetEclipse(EclipseProject ecl) => this.ecl = ecl;
        public abstract bool Extract(int X, int Y);
    }

    public class CellViewModeZStrategy : CellViewModeBaseStrategy
    {
        public override int NX => ecl.EGRID.NX;
        public override int NY => ecl.EGRID.NY;

        public override bool Extract(int X, int Y)
        {
            index = ecl.INIT.GetActive(X, Y, S);

            if (index > 0)
            {
                cell = ecl.EGRID.GetCell(X, Y, S);

                points = new List<Vector2> // XY Plan
                    {
                        new Vector2(cell.TNW.X, cell.TNW.Y),
                        new Vector2(cell.TNE.X, cell.TNE.Y),
                        new Vector2(cell.TSE.X, cell.TSE.Y),
                        new Vector2(cell.TSW.X, cell.TSW.Y)
                    };

            }
            return index > 0;
        }
    }

    public class CellViewModeXStrategy : CellViewModeBaseStrategy
    {
        public override int NX => ecl.EGRID.NZ;
        public override int NY => ecl.EGRID.NY;

        public override bool Extract(int X, int Y)
        {
            index = ecl.INIT.GetActive(S, Y, X);

            if (index > 0)
            {
                cell = ecl.EGRID.GetCell(S, Y, X);

                points = new List<Vector2> // YZ Plan
                    {
                        new Vector2(cell.TSE.Y * (1 - sf) + (xmin + dx * (Y + 1)) * sf, cell.TSE.Z * (1 - sf) + (ymin + dy * X) * sf),
                        new Vector2(cell.BSE.Y * (1 - sf) + (xmin + dx * (Y + 1)) * sf, cell.BSE.Z * (1 - sf) + (ymin + dy * (X + 1)) * sf),
                        new Vector2(cell.BNE.Y * (1 - sf) + (xmin + dx * Y) * sf, cell.BNE.Z * (1 - sf) + (ymin + dy * (X + 1)) * sf),
                        new Vector2(cell.TNE.Y * (1 - sf) + (xmin + dx * Y) * sf, cell.TNE.Z * (1 - sf) + (ymin + dy * X) * sf)
                    };
            }
            return index > 0;
        }
    }

    public class CellViewModeYStrategy : CellViewModeBaseStrategy
    {
        public override int NX => ecl.EGRID.NZ;
        public override int NY => ecl.EGRID.NX;

        public override bool Extract(int X, int Y)
        {
            index = ecl.INIT.GetActive(Y, S, X);

            if (index > 0)
            {
                cell = ecl.EGRID.GetCell(Y, S, X);

                points = new List<Vector2> // XZ Plan
                    {
                        new Vector2(cell.TSW.X * (1 - sf) + (xmin + dx * Y) * sf, cell.TSW.Z * (1 - sf) + (ymin + dy * X) * sf),
                        new Vector2(cell.TSE.X * (1 - sf) + (xmin + dx * (Y + 1)) * sf, cell.TSE.Z * (1 - sf) + (ymin + dy * X) * sf),
                        new Vector2(cell.BSE.X * (1 - sf) + (xmin + dx * (Y + 1)) * sf, cell.BSE.Z * (1 - sf) + (ymin + dy * (X + 1)) * sf),
                        new Vector2(cell.BSW.X * (1 - sf) + (xmin + dx * Y) * sf, cell.BSW.Z * (1 - sf) + (ymin + dy * (X + 1)) * sf)
                    };
            }
            return index > 0;
        }
    }
}