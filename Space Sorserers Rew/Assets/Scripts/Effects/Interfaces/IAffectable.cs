using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityEditor.Experimental.GraphView;

namespace Assets.Scripts
{
    internal interface IAffectable : IResistable
    {
        
        public bool CanAttack { get; set; }
        public bool CanMove {  get; set; }
        public float Speed {  get; set; }

        public void Fire(Damage dmg) { }
        public void Slow(float multi) { }
        public void ResistDebuff(Dictionary<string, float> resDeb) { }
        public void Disarm() { }
        public void Stun() { }
        public void Wet(float sLowMulti, Dictionary<string, float> resDeb) { }
        public void Froze(float sLowMulti, Dictionary<string, float> resDeb) { }



    }
}
