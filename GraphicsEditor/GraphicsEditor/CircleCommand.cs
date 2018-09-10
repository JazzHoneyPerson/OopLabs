using ConsoleUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawablesUI;

namespace GraphicsEditor
{
    class CircleCommand : FigureCommand
    {
        public CircleCommand(Picture picture) : base(picture)
        {
        }

        public override string Name => "circle";

        public override string Help => "Рисует круг";

        public override string Description => "круг. Параметры — координаты центра круга и радиус, три числа float";

        public override string[] Synonyms => new string[] { };

        protected override int CountOfParameters => 3;

        protected override IDrawable initFigure(float[] parameters)
        {
            return new Circle(parameters);
        }
    }
}
