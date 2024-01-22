using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

namespace Pacman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool Game = true;
            Console.CursorVisible = false;
            char[,] map = ReadMap("map.txt");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            DrawMap(map);
            int userX = map.GetLength(0) / 2;
            int userY = map.GetLength(1) / 2;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(userX, userY);
            Console.Write("@");
            int score = 0;
            int winPoint = 158;
            ConsoleKeyInfo pressKey = new ConsoleKeyInfo();

           Task.Run(() =>
           {
                while (true)
                {
                    
                }
           });

            while (Game = true)
            {
                pressKey = Console.ReadKey();
                Console.SetCursorPosition(0, map.GetLength(1)+1);
                Console.Write($"Score: {score}");
                Console.Write(" ");
                UserInputKeyInfo(pressKey, ref userX,ref userY, map, ref score);

                Thread.Sleep(250);

               
               if (score > winPoint)
                {
                    Console.Clear() ;
                    Console.SetCursorPosition(1, 1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("You Win");
                    Game = false;

                }
            }

           
        }

        private static char[,] ReadMap(string path)
        {
            string[] file  = File.ReadAllLines("map.txt");

            char[,] map = new char[GetLenghtOfLine(file), file.Length ];

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    map[x,y] = file[y][x];
                }
            }
            return map;
        }//метод переводящий карту из txt файла (сток) в многомерный массив

        private static void DrawMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x,y]);
                }
                Console.Write("\n");
            }
        }// метод рисующий карту 
        
        private static int GetLenghtOfLine(string [] lines)
        {
            int maxLehgth = lines[0].Length;
            foreach (var  line in lines)
            {
                if (line.Length > maxLehgth)
                    maxLehgth = line.Length;
            }
            return maxLehgth;
        }//Метод находящий максимальную длинну строки из файла

        private static void UserInputKeyInfo(ConsoleKeyInfo pressKey, ref int userX, ref int userY, char[,] map, ref int score) {

            Console.SetCursorPosition(userX, userY);
            Console.Write(" ");

            if (pressKey.Key == ConsoleKey.UpArrow)
            {
                if(map[userX, userY - 1] == '.')
                {
                    score += 1;
                    map[userX, userY - 1] = ' ';
                }
                if (map[userX, userY - 1] != '#') userY -= 1;

            }
            else if (pressKey.Key == ConsoleKey.DownArrow)
            {
                if (map[userX, userY + 1] == '.')
                {
                    score += 1;
                    map[userX, userY + 1] = ' ';


                }
                if (map[userX, userY + 1] != '#') userY += 1;
            }
            else if (pressKey.Key == ConsoleKey.LeftArrow)
            {
                if (map[userX-1, userY ] == '.')
                {
                    score += 1;
                    map[userX- 1, userY ] = ' ';
                }
                if (map[userX - 1, userY] != '#') userX -= 1;
            }
            else if (pressKey.Key == ConsoleKey.RightArrow) {

                if (map[userX + 1, userY] == '.')
                {
                    score += 1;
                    map[userX +1, userY] = ' ';
                }
                if (map[userX + 1, userY ] != '#') userX += 1; 
            }

            Console.SetCursorPosition(userX, userY);
            Console.Write("@");
        }




    }
}
