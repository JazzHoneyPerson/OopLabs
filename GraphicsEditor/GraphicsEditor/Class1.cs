using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    static class StringArrayExtention
    {
        

        public static float[] ToPositiveFloats(this string[] parameters)
        {
            var parametersFloat = new float[parameters.Length];
            for(int i=0; i<parameters.Length;i++)
            {
                if (!float.TryParse(parameters[i], NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out parametersFloat[i]) || parametersFloat[i] < 0)
                    return null;
            }
            return parametersFloat;
        }
        public static int[] ToPositiveInts(this string[] parameters)
        {
            var parametersInt = new int[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                if (!int.TryParse(parameters[i], out parametersInt[i]) || parametersInt[i] < 0)
                    return null;
            }
            return parametersInt;
        }
    }
}
