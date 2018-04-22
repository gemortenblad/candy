using System;
using System.Threading;

namespace candy
{
    public class Outputter
    {
        private readonly int width;
        private readonly int height;

        public Outputter(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Write a character to console, return cursor to initial position
        /// </summary>
        public void WC(char c)
        {
            var top = Console.CursorTop;
            var left = Console.CursorLeft;
            Console.Write(c);
            Set(left, top);
        }

        /// <summary>
        /// Move the cursor
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        public void Set(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }
        
        /// <summary>
        /// Move the cursor from its current position
        /// </summary>
        /// <param name="addLeft"></param>
        /// <param name="addTop"></param>
        public void MoveFromTop(int steps)
        {
            var newPositionTop = Console.CursorTop + steps;

            if (newPositionTop < 0) newPositionTop = 0;
            if (newPositionTop >= height) newPositionTop = height -1;

            Console.CursorTop = newPositionTop;
            //Console.SetCursorPosition(Console.CursorLeft, newPositionTop);
        }
        
        
        /// <summary>
        /// Move the cursor from its current position
        /// </summary>
        /// <param name="addLeft"></param>
        /// <param name="addTop"></param>
        public void MoveFromLeft(int steps)
        {
            var newPositionLeft = Console.CursorLeft + steps;
            
            
            if (newPositionLeft < 0) newPositionLeft = 0;
            if (newPositionLeft >= width) newPositionLeft = width - 1;

            Console.CursorLeft = newPositionLeft;
            
            //Console.SetCursorPosition(newPositionLeft, Console.CursorTop);
        }
        
        
        

        public void InitCanvas()
        {
            
            Console.WindowWidth = width;
            Console.WindowHeight = height;
            Console.CursorVisible = false;
            
            
            for (int left = 0; left < width; left++)
            {
                int top;
                for (top = 0; top < height; top++)
                {
                    //Thread.Sleep(5);
                    Set(left, top);
                    WC('*');
                }
            }
            
            Set(5,5);
        }
    }
}