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
            Assert.AreEqual("0,0,N", string.Format("{0},{1},{2}", rover.currentX, rover.currentY, rover.currenctDirection));
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
            Assert.AreEqual("0,1,N", string.Format("{0},{1},{2}", rover.currentX, rover.currentY, rover.currenctDirection));
        }

        [Test]
        public void Rover_Press_B_FromStartingPosition_Return09N()
        {
            // Arrange
            var rover = new Rover();

            // Act
            rover.ProcessCommand('B');

            // Assert
            Assert.AreEqual("0,9,N", string.Format("{0},{1},{2}", rover.currentX, rover.currentY, rover.currenctDirection));
        }



    }
}
