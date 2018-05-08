using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GwApiNET.Gw2PositionReader;

namespace GwApiNETExample
{

    public static class Extensions
    {
        public const float InchesPerMeter = 39.37010F;

        public static Vector3 MetersToInches(this Vector3 vector)
        {
            return vector*InchesPerMeter;
        }
    }
}
