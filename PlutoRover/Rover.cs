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
        // set a direction array to navigate by (instead of using big if conditionals)
        private DIRECTION[] dirArray = { DIRECTION.E, DIRECTION.S, DIRECTION.W, DIRECTION.N };

        // set properties to keep track of the rover's current position
        public int currentX { get; set; }
        public int currentY { get; set; }
        public DIRECTION currentDirection { get; set; }

        // define the limits of the grid representing Pluto (10x10)
        private const int MaxX = 9;
        private const int MaxY = 9;

        public Rover()
        {
            currentX = 0;
            currentY = 0;
            currentDirection = DIRECTION.N;
        }

        // process to accept a command character and act accordingly (F, B, L, R)
        private void ProcessCommand(char command)
        {
            // we need to process L and R now, do this first because if these are the commands then we don't have to move
            if ((command == 'L') || (command == 'R'))
            {
                // use the array instead of a bunch of crazy if or case statements to work out which direction to point to
                var dirIndex = Array.IndexOf(dirArray, currentDirection);
                dirIndex = command == 'L' ? dirIndex -= 1 : dirIndex += 1;

                // we now have the new index, make sure it doesn't go out of bounds
                dirIndex = dirIndex == -1 ? dirIndex = dirArray.Length - 1 : dirIndex == dirArray.Length ? dirIndex = 0 : dirIndex;

                // set the new direction
                currentDirection = dirArray[dirIndex];

                // return, as we don't need to process the movements
                return;
            }

            // Process commands for F and B, work out how much to move by
            var moveby = command == 'F' ? 1 : command == 'B' ? -1 : 0;

            // if N or S, then Y changes, if E or W, then X changes (we need to account for all directions now)
            int newX = currentX;
            int newY = currentY;

            switch (currentDirection)
            {
                case DIRECTION.N:
                    newY += moveby;
                    break;
                case DIRECTION.S:
                    newY -= moveby;
                    break;
                case DIRECTION.E:
                    newX += moveby;
                    break;
                case DIRECTION.W:
                    newX -= moveby;
                    break;
            }

            // make sure we wrap around the grid (IE if we reach the edge, go to the other side)
            newX = newX == -1 ? newX = MaxX : newX > MaxX ? 0 : newX;
            newY = newY == -1 ? newY = MaxY : newY > MaxY ? 0 : newY;

            // move the rover
            currentX = newX;
            currentY = newY;
        }

        public void ProcessCommandString(string command)
        {
            var commandlist = command.ToCharArray();

            foreach (var c in commandlist)
            {
                ProcessCommand(c);
            }
        }

    }
}
