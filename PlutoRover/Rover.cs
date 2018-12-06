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

        // define the limits of the grid representing Pluto (10x10)
        private const int MaxX = 9;
        private const int MaxY = 9;

        public Rover()
        {
            currentX = 0;
            currentY = 0;
            currenctDirection = DIRECTION.N;
        }

        // process to accept a command character and act accordingly (F, B, L, R)
        public void ProcessCommand(char command)
        {
            // Process commands for F and B, work out how much to move by
            var moveby = command == 'F' ? 1 : command == 'B' ? -1 : 0;

            // if N or S, then Y changes, if E or W, then X changes
            int newX = currentX;
            int newY = currentY + moveby;

            // make sure we wrap around the grid (IE if we reach the edge, go to the other side)
            newX = newX == -1 ? newX = MaxX : newX > MaxX ? 0 : newX;
            newY = newY == -1 ? newY = MaxY : newY > MaxY ? 0 : newY;

            // move the rover
            currentX = newX;
            currentY = newY;




        }

    }
}
