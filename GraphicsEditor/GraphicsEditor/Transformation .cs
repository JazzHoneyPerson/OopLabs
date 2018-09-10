using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    public class Transformation
    {
        ///// Возвращает преобразование поворота на угол angle вокруг точки (0,0)
        //public static Transformation Rotate(float angle)
        //{
        //    //SingularValueDecomposition.FirstAngle += angle;
        //}
        ///// Возвращает преобразование параллельного переноса на вектор ((0,0), point)
        //public static Transformation Translate(PointF point);
        ///// Возвращает преобразование масштабирования с коэффициентами scaleX и scaleY
        ///// относительно точки (0, 0).
        ///// отрицательные значения параметров соответствуют инверсии
        //public static Transformation Scale(float scaleX, float scaleY);
        ///// Возвращает центральное аффинное преобразование, заданное матрицей 2x2
        //public static Transformation FromMatrix(float[,] matrix);
        ///// Возвращает преобразование, получающееся последовательным применением
        ///// преобразований a и b
        //public static Transformation operator *(Transformation a, Transformation b);
        ///// Для любой точки плоскости возвращает её образ
        //public PointF this[PointF point] { get; }
        //private Transformation();
        //public SingularValueDecompositoin SingularValueDecomposition { get; }
        //public class SingularValueDecompositoin
        //{
        //    public float FirstAngle { get; private set; }
        //    public float[] Scale { get; private set; }
        //    public float SecondAngle { get; private set; }
        //}
    }
}
