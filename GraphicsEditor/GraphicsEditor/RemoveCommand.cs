using ConsoleUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    class RemoveCommand : ICommand
    {
        Picture picture;
        public RemoveCommand (Picture picture)
        {
            this.picture = picture;
        }
        
        public string Name => "remove";

        public string Help => "удаляет фигуры по индексу";

        public string Description => " удаление фигуры с картинки. Параметры команды — индексы элементов, которые нужно удалить с картинки";

        public string[] Synonyms => new string[] { };

        public void Execute(params string[] parameters)
        {
            var intParams = parameters.ToPositiveInts();
            if (intParams == null)
            {
                Console.WriteLine("Можно вводить только целые положительные числа");
                return;
            }
            foreach(var index in intParams)
            {
                picture.RemoveAt(index);
            }

        }
    }
}
