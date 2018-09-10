using ConsoleUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawablesUI;

namespace GraphicsEditor
{
    class EllipseCommand : FigureCommand
    {
        public EllipseCommand(Picture picture) : base(picture)
        {
        }

        public override string Name => "ellipse";

        public override string Help => "рисует эллипс";

        public override string Description => "эллипс. Параметры — координаты точки центра эллипса, размеры осей эллипса, угол поворота эллипса, пять ";

        public override string[] Synonyms => new string[] { };

        protected override int CountOfParameters => 5;

        protected override IDrawable initFigure(float[] parameters)
        {
           return new Ellipse(parameters);
        }
    }
}
