using DrawablesUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    class Line : IShape
    {
        PointF point1, point2;
        public override string ToString()
        {
            return String.Format("Линия({0},{1})",point1.ToRussianString(),point2.ToRussianString());
        }
        public Line(float[] parameters)
        {
            point1 = new PointF(parameters[0],parameters[1]);
            point2 = new PointF(parameters[2],parameters[3]);
        }
        public void Draw(IDrawer drawer)
        {
            drawer.DrawLine(point1,point2);
        }

        public void Transform(Transformation trans)
        {
            throw new NotImplementedException();
        }
    }
}
