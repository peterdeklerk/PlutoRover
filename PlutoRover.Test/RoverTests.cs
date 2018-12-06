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
    }
}
