using DrawablesUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    public interface IShape:IDrawable
    {

        int Index { get; set; }

        void Transform(Transformation trans);
    }
}
