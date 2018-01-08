using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public struct Attraction : IHasID
    {
        public Guid ID;
        public float BandwidthPerHour;

        Guid IHasID.ID => ID;

    }
}
