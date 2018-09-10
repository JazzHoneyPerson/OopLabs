using ConsoleUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    class ListCommand : ICommand
    {
        Picture picture;

        public ListCommand(Picture picture)
        {
            this.picture = picture;
        }
        public string Name => "list";

        public string Help => "показывает список фигур";

        public string Description => "выводит список фигур на картинке";

        public string[] Synonyms => new string[] { };

        public void Execute(params string[] parameters)
        {
            picture.ShowList();
        }
    }
}
