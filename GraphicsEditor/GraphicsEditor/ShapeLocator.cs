using DrawablesUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    public class ShapeLocator
    {
        // фигура, которая соответствует идентификатору типа 0:1:1
        public IShape Shape { get; private set; }
        // "родитель" фигуры, которая соответствует идентификатору, м.б. равен null
        public CompoundShape Parent { get; private set; }
        // "родитель" "родителя" фигуры которая, соответствует идентификатору, м.б. равен null
        public CompoundShape GrandParent { get; private set; }
        // метод, преобразующий строку-идентификатор, разделённый двоеточиями, в объект
        public static ShapeLocator Parse(string identifier, Picture picture)
        {
            var identifierSplited=identifier
                .Split(':')
                .Select((x)=>Convert.ToInt32(x))
                .ToArray();
            if(identifierSplited.Length==1)
                return new ShapeLocator(picture.GetAt(identifierSplited[2]));
            if(identifierSplited.Length==2)
                return new ShapeLocator(picture.GetAt(identifierSplited[2]), picture.GetAt(identifierSplited[1]));
            return new ShapeLocator(picture.GetAt(identifierSplited[2]), picture.GetAt(identifierSplited[]), picture.GetAt(identifierSplited[1]));
        }
        private ShapeLocator(IDrawable shape, IDrawable parent=null, IDrawable grandParent=null)
        {
            Shape = (IShape)shape;
            Parent = (CompoundShape)parent;
            GrandParent = (CompoundShape)grandParent;
        }
    }
}
