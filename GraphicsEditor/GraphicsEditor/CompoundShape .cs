using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawablesUI;

namespace GraphicsEditor
{
    public class CompoundShape:IShape
    {
        public List<IShape> Shapes { get; private set; }


        public override string ToString()
        {
            var result=String.Empty;
            for (int i = 0; i < Shapes.Count; i++)
                 result+=String.Format(":{0}{1}",i, Shapes[i]);
            return result;
        }
        public void Add(IShape shape)
        {
            Shapes.Add(shape);
        }

        public void Draw(IDrawer drawer)
        {
            foreach(var shape in Shapes)
                shape.Draw(drawer);
        }

        public void Transform(Transformation trans)
        {
            throw new NotImplementedException();
        }
        


    }
}
