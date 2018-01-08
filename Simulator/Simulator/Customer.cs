using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public struct Customer : IHasID
    {
        public Guid ID;

        Guid IHasID.ID => ID;
    }
}
