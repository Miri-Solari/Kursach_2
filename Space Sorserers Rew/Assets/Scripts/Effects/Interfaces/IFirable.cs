using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace Assets.Scripts
{
    internal interface IFirable : IAffectable, IDamagable
    {
        public new void Fire(Damage dmg)
        {
            TakeDamage(dmg);
        }
    }
}
