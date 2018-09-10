using GraphicsEditor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawablesUI
{
    class Point : IShape
    {
        PointF point;
        public override string ToString()
        {
            return point.ToRussianString();
        }
        public Point(float[] parameters)
        {
            point = new PointF(parameters[0],parameters[1]);
        }
        public void Draw(IDrawer drawer)
        {
            drawer.DrawPoint(point);
        }

        public void Transform(Transformation trans)
        {
            throw new NotImplementedException();
        }
    }
}
