using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_FuelEfficiency
{
    internal class InvalidVehicleException:Exception
    {
        public InvalidVehicleException(string message):base(message){}
    }
}
