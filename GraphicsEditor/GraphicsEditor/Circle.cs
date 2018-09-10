using DrawablesUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    class Circle : Ellipse
    {
        public override string ToString()
        {
            return String.Format("Окружность({0},радиус={1})",center.ToRussianString(),size.Width);
        }
        public Circle(float[] parameters) 
        {
            center = new PointF(parameters[0], parameters[1]);
            size = new SizeF(parameters[2], parameters[2]);
        }      

    }
}
