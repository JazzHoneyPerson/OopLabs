using ConsoleUI;
using DrawablesUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    abstract class FigureCommand : ICommand
    {
        protected Picture picture;

        public abstract string Name { get; }
        public abstract string Help { get; }
        public abstract string Description { get; }
        public abstract string[] Synonyms { get; }
        protected abstract int CountOfParameters { get ; }


        public FigureCommand(Picture picture) => this.picture = picture;

        protected abstract IDrawable initFigure(float[] parameters);

        public void Execute(params string[] parameters)
        {
            if (parameters.Length != CountOfParameters)
            {
                Console.WriteLine("У команды " +Name+ " должно быть " + CountOfParameters + " аргумента(ов).");
                return;
            }
            var floatParams = parameters.ToPositiveFloats();
            if (floatParams == null)
            {
                Console.WriteLine("Можно вводить только рациональные положительные числа");
                return;
            }
            picture.Add(initFigure(floatParams));
        }
    }
}
