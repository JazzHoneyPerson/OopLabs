using ConsoleUI;
using GraphicsEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    class GroupCommand : ICommand
    {
        Picture picture;

        public GroupCommand(Picture picture)
        {
            this.picture = picture;
        }
        public string Name => "group";

        public string Help => "группировка фигур";

        public string Description => "Параметры - идентификаторы фигур, которые нужно сгруппировать. Переносит фигуры, идентификаторы которых перечислены в параметрах, в новую составную фигуру, которая добавляется на картинку";

        public string[] Synonyms => new string[] { };

        public void Execute(params string[] parameteres)
        {
            var shapeLocators = new List<ShapeLocator>();
            for(int i=0; i< parameteres.Length;i++)
            {
                for(int j=i+1; j<parameteres.Length;j++)
                {
                    if(parameteres[i]==parameteres[j])
                    {
                        Console.WriteLine("Введены одинаковые индификаторы.");
                        return;
                    }
                    if(parameteres[i].StartsWith(parameteres[j])|| parameteres[j].StartsWith(parameteres[i]))
                    {
                        Console.WriteLine("Нельзя группировать дочернюю и родительскую фигуру вместе.");
                        return;
                    }
                }
                shapeLocators.Add(ShapeLocator.Parse(parameteres[i],picture));
            }
            


            
            //var parameteresInt = new List<int>();
            //var compoundShape=new CompoundShape();

            //foreach(var param in parameteres)
            //{
            //    int result;
            //    if(!int.TryParse(param, out result)||result<0)
            //    {
            //        Console.WriteLine("Можно вводить только целые положительные числа");
            //        return;
            //    }
            //    if(parameteresInt.Contains(result))
            //    {
            //        Console.WriteLine("Группирование одной и той же фигуры");
            //        return;
            //    }
            //    parameteresInt.Add(result);

            //}
            //foreach (var index in parameteresInt)
            //{
            //    compoundShape.Add((IShape)picture.GetAt(index));
            //    picture.RemoveAt(index);
            //}
            //picture.Add(compoundShape);



        }
    }
}
