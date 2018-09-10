using ConsoleUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawablesUI;

namespace GraphicsEditor
{
    class LineCommand:FigureCommand
    {
        public LineCommand(Picture picture) : base(picture)
        {
        }

        public override string Name => "line";
        public override string Help => "Рисует линию";
        public override string Description => "отрезок. Параметры — координаты точек начала и конца отрезка, четыре числа float";

        public override string[] Synonyms => new string[] { };

        protected override int CountOfParameters => 4;

        protected override IDrawable initFigure(float[] parameters)
        {
            return new Line(parameters);
        }
    }
}
