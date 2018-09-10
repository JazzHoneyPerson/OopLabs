using DrawablesUI;
using GraphicsEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class PointCommand:FigureCommand
    {
        public PointCommand(Picture picture) : base(picture)
        {
        }

        public override string Name => "point";
        public override string Help => "Рисует точку";
        public override string Description => " точка. Параметры — координаты точки, два числа float";
        public override string[] Synonyms => new string[] { };

        protected override int CountOfParameters => 2;

        protected override IDrawable initFigure(float[] parameters)
        {
            return new Point(parameters);
        }
    }
}
