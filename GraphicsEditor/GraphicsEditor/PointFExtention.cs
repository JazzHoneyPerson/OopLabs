using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    static class PointFExtention
    {
        public static string ToRussianString(this PointF point)
        {
            return String.Format("Точка({0},{1})",point.X,point.Y);
        }
    }
}
