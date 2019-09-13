using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void timer(int speed)
        {
            for (int i = 0; i < 1000000000 / (speed * 10); i++) ;
        }

        static void sitting()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(60, 20);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Clear();
        }

        static void print(char character, int x, int y, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(character);
        }

        static void Main(string[] args)
        {
            sitting();

            short i, p;
            string hello = "HELLO";
            string world = "WOLRD";
            ConsoleColor[] color = {ConsoleColor.DarkBlue , ConsoleColor.DarkGreen,
                                    ConsoleColor.DarkMagenta , ConsoleColor.DarkRed,
                                    ConsoleColor.DarkYellow };


            //print HELLO
            for (i = 26, p = 0; i <= 34; i += 2, p++, timer(p + 1))
                print(hello[p], i, 8, color[p]);


            //print WORLD
            for (i = 26, p = 0; i <= 34; i += 2, p++, timer(p + 1))
                print(world[p], i, 9, color[p]);



            Console.ReadKey();
        }
    }
}
