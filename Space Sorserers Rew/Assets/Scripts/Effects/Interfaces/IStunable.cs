using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal interface IStunable : IAffectable
    {
        public new void Stun()
        {
            CanAttack = false;
            CanMove = false;
        }

        public void StunEnd()
        {
            CanAttack = true;
            CanMove = true;
        }
    }
}
