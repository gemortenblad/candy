using System;
using System.Threading;
using System.Threading.Tasks;

namespace candy
{
    class Program
    {
        static void Main(string[] args)
        {
            var height = 30;
            var width = 50;
            
            var op = new Outputter(width, height);
            op.InitCanvas();

            while (true)
            {
                var keyPress = GetUserInput(op);
                MoveAvatar(keyPress, op);
            }
            
        }

        private static void MoveAvatar(ConsoleKey keyPress, Outputter op)
        {
            var outputchar = '0';

            switch (keyPress)
            {
                case ConsoleKey.RightArrow:
                    op.MoveFromLeft(1);
                    break;
                case ConsoleKey.LeftArrow:
                    op.MoveFromLeft(-1);
                    break;
                case ConsoleKey.UpArrow:
                    op.MoveFromTop(-1);
                    break;
                case ConsoleKey.DownArrow:
                    op.MoveFromTop(1);
                    break;
            }

            op.WC(outputchar);
        }

        private static ConsoleKey GetUserInput(Outputter op)
        {
            var keyPress = Console.ReadKey().Key;
            op.MoveFromLeft(-1); // readkey verkar flytta markören till höger
            return keyPress;
        }


        private static async Task<int> GetInt()
        {
            return 3;
        }
    }
}