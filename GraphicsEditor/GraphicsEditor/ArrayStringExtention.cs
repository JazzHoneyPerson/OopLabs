using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    static class ArrayStringExtention
    {
        public static bool CheckPrefix(this string[] list, string prefix)
        {
            foreach(var word in list)
            {
                if(word.StartsWith(prefix)&&word!=prefix)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
