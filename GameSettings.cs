using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProt0type_1
{
    class GameSettings 
    {
        public static int Width { get; set; } // So are accessible throught the program
        public static int Height { get; set; } // So are accessible throught the program

        public static string directions; //

        public GameSettings() // size of the points (pixels)
        {
            Width = 16;
            Height = 16;
            directions = "left"; // default directions of the snake
        }
    }
}
