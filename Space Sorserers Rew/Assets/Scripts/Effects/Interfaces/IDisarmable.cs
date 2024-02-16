using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal interface IDisarmable : IAffectable
    {
        public new void Disarm()
        {
            CanAttack = false;
        }

        public void DisarmEnd()
        {
            CanAttack = true;
        }
    }
}
