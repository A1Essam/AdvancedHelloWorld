 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        
        struct menuitem
        {
           public string colorName ;
           public ConsoleColor color;
           public ConsoleColor selecteditem;
            public menuitem(string colorName, ConsoleColor color,ConsoleColor selecteditem)
            {
                this.color = color;
                this.colorName = colorName;
                this.selecteditem = selecteditem;
            }
        }

        static ConsoleColor drawMenu()
        {
            string space = "  ";//space between items in menu

            //menu items color and color name
            menuitem[] menu = { new menuitem("Yellow", ConsoleColor.Yellow,ConsoleColor.DarkYellow),
                                new menuitem("Cyan", ConsoleColor.Cyan,ConsoleColor.DarkCyan),
                                new menuitem("Blue", ConsoleColor.Blue, ConsoleColor.DarkBlue),
                                new menuitem("Gray", ConsoleColor.Gray, ConsoleColor.White)};
                  
            int selecteditem = 0;     //item which user stand on currently

            writeMenu(menu, space, selecteditem); //write menu items 
            ConsoleKeyInfo ky = new ConsoleKeyInfo();

            
            while (true)
            {
                ky = Console.ReadKey();
                switch (ky.Key)
                {
                    //when user press righ arrow
                    //highlight and stand on the next item
                    case ConsoleKey.RightArrow:
                        
                        if (selecteditem < menu.Length - 1) //check boundaries 
                            writeMenu(menu, space, ++selecteditem); //highlight and stand on the next item
                        else
                            Console.SetCursorPosition(0, 0);//return to the start of menu
                        break;

                    case ConsoleKey.LeftArrow:
                        if (selecteditem > 0)
                            writeMenu(menu, space, --selecteditem);
                        else
                            Console.SetCursorPosition(0, 0);
                        break;

                    case ConsoleKey.Enter:
                        return menu[selecteditem].color;
                        

                    default:
                        Console.SetCursorPosition(0, 0);
                        writeMenu(menu, space, selecteditem);
                        break;
                }



            }
            
        }

        static void writeMenu(menuitem[] menu, string space, int seleteditem)
        {
            Console.BackgroundColor = menu[seleteditem].selecteditem;
            Console.Clear();
            Console.SetCursorPosition(1, 0);
            //highlight the selected color
            for (int i = 0; i < menu.Length; i++)
            {
                Console.ForegroundColor = menu[i].color;
                
                if (i == seleteditem)
                {
                    Console.ForegroundColor = menu[i].color;
                    Console.Write("{0}{1}", menu[i].colorName, space);
                    Console.ForegroundColor = menu[i].color;
                    continue;
                }
                if (i == menu.Length - 1) Console.Write("{0}", menu[i].colorName);
                else Console.Write("{0}{1}", menu[i].colorName, space);
            }


            content (menu[seleteditem].colorName, menu[seleteditem].color);
            Console.SetCursorPosition(0, 0);
        }

        //write the content of item 
        static void content(string word, ConsoleColor color)
        {

            Console.SetCursorPosition(3, 3);
            Console.ForegroundColor = color;
            Console.Write("Press enter to choice : {0}", word);
            Console.SetCursorPosition(0, 0);
        }


        static void timer(int speed)
        {
            for (int i = 0; i < 1000000000 / (speed * 10); i++) ;
        }

        static void sitting()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(60, 20);
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

            Console.BackgroundColor = drawMenu();
            Console.Clear();


            short i, p;
            string hello = "HELLO";
            string world = "WOLRD";
            ConsoleColor[] color = {ConsoleColor.Red , ConsoleColor.DarkGreen,
                                    ConsoleColor.DarkMagenta , ConsoleColor.DarkRed,
                                    ConsoleColor.Green };


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
