using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRover
{
    // define an interface contract in case we want to extend the application to accept custom obstacles through
    // construction injection sometime in the future
    public interface IObstacle
    {
        int X { get; set; }
        int Y { get; set; }
    }
}
