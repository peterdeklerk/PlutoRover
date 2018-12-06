using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRover
{
    public enum DIRECTION
    {
        N, S, E, W
    }

    public class Rover
    {
        // set properties to keep track of the rover's current position
        public int currentX { get; set; }
        public int currentY { get; set; }
        public DIRECTION currenctDirection { get; set; }

        public Rover()
        {
            currentX = 0;
            currentY = 0;
            currenctDirection = DIRECTION.N;
        }



    }
}
