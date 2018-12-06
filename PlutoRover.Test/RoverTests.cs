using NUnit.Framework;
using PlutoRover;

namespace PlutoRover.Test
{
    [TestFixture]
    public class RoverTests
    {
        [Test]
        public void Rover_NewRoverStartingPosition_Returns00N()
        {
            // Arrange
            var rover = new Rover();

            // Assert
            Assert.AreEqual("0,0,N", string.Format("{0},{1},{2}", rover.currentX, rover.currentY, rover.currentDirection));
        }

        // tests to ensure F and B from starting position is correct (going to work with a grid 10x10)
        [Test]
        public void Rover_Press_F_FromStartingPosition_Return01N()
        {
            // Arrange
            var rover = new Rover();

            // Act
            rover.ProcessCommand('F');

            // Assert
            Assert.AreEqual("0,1,N", string.Format("{0},{1},{2}", rover.currentX, rover.currentY, rover.currentDirection));
        }

        [Test]
        public void Rover_Press_B_FromStartingPosition_Return09N()
        {
            // Arrange
            var rover = new Rover();

            // Act
            rover.ProcessCommand('B');

            // Assert
            Assert.AreEqual("0,9,N", string.Format("{0},{1},{2}", rover.currentX, rover.currentY, rover.currentDirection));
        }

        // test pressing L and R from the starting position
        [Test]
        public void Rover_Press_L_FromStartingPosition_Return00W()
        {
            // Arrange
            var rover = new Rover();

            // Act
            rover.ProcessCommand('L');

            // Assert
            Assert.AreEqual("0,0,W", string.Format("{0},{1},{2}", rover.currentX, rover.currentY, rover.currentDirection));
        }

        [Test]
        public void Rover_Press_R_FromStartingPosition_Return00E()
        {
            // Arrange
            var rover = new Rover();

            // Act
            rover.ProcessCommand('R');

            // Assert
            Assert.AreEqual("0,0,E", string.Format("{0},{1},{2}", rover.currentX, rover.currentY, rover.currentDirection));
        }

        // write test to make sure the navigation works correctly with multiple inputs of L
        [Test]
        public void Rover_Press_L_FromStartingPosition_CheckDirection(
            [Values("LL", "LLL", "LLLL", "LLLLL")] string input)
        {
            // Arrange
            var rover = new Rover();

            // Act - going to need a new command to process a string input, not just 1 character at a time
            rover.ProcessCommandString(input);

            // work out the result to expect
            var result = "";

            switch (input)
            {
                case "LL":
                    result = "0,0,S";
                    break;
                case "LLL":
                    result = "0,0,E";
                    break;
                case "LLLL":
                    result = "0,0,N";
                    break;
                case "LLLLL":
                    result = "0,0,W";
                    break;
            }

            // Assert
            Assert.AreEqual(result, string.Format("{0},{1},{2}", rover.currentX, rover.currentY, rover.currentDirection));
        }

        // write test to make sure the navigation works correctly with multiple inputs of R
        [Test]
        public void Rover_Press_R_FromStartingPosition_CheckDirection(
            [Values("RR", "RRR", "RRRR", "RRRRR")] string input)
        {
            // Arrange
            var rover = new Rover();

            // Act - going to need a new command to process a string input, not just 1 character at a time
            rover.ProcessCommandString(input);

            // work out the result to expect
            var result = "";

            switch (input)
            {
                case "RR":
                    result = "0,0,S";
                    break;
                case "RRR":
                    result = "0,0,W";
                    break;
                case "RRRR":
                    result = "0,0,N";
                    break;
                case "RRRRR":
                    result = "0,0,E";
                    break;
            }

            // Assert
            Assert.AreEqual(result, string.Format("{0},{1},{2}", rover.currentX, rover.currentY, rover.currentDirection));
        }


    }
}
