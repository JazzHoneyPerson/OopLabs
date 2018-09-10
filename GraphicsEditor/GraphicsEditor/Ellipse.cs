using DrawablesUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    class Ellipse : IShape
    {
        protected PointF center;
        protected SizeF size;
        float rotate = 0;

        public override string ToString()
        {
            return String.Format("Эллипс({0},высота={1},ширина={2},угол={3})", center.ToRussianString(),size.Height,size.Width,rotate);
        }

        protected Ellipse(){ }
        public Ellipse(float[] parameters)
        {
            center = new PointF(parameters[0],parameters[1]);
            size = new SizeF(parameters[2],parameters[3]);
            rotate = parameters[4];
        }
        public void Draw(IDrawer drawer)
        {
            drawer.DrawEllipseArc(center,size,0,360,rotate);
        }

        public void Transform(Transformation trans)
        {
            throw new NotImplementedException();
        }
    }
}
