using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs3
{

    class Program
    {
        static Dictionary<string, Func<Rational, Rational, Rational>> commands = new Dictionary<string, Func< Rational,Rational, Rational>>()
        {
            {"add",(x,y)=>x+y },
            {"sub",(x,y)=>x-y },
            {"mul",(x,y)=>x*y },
            {"div",(x,y)=>x/y }
        };
        static string Handle(string[] args)
        {
            var arg1 = new Rational();
            var arg2 = new Rational();
            if (Rational.TryParse(args[1], out arg1) && Rational.TryParse(args[2], out arg2))
                try
                {
                    return commands[args[0]](arg1, arg2).ToString();
                }
                catch(Exception e) { }
                //catch (Exception e)
                //{
                //    return "Ошибка";
                //}
            return "Ошибка";
        }
        static void Main(string[] args)
        {

            var charsToTrim = new char[] { '[', ']' };
            var a="[aa]".Trim(charsToTrim);
            while (true) Console.WriteLine(Handle(Console.ReadLine().Split()));
        }
    }
}
