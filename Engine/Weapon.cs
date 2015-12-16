using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Weapon : IHeroeModifier
    {
        public int Power { get; private set; }

        public Weapon(int power)
        {
            this.Power = power;
        }

        public void Modify(IHeroe heroe)
        {
            if(heroe == null)
            {
                throw new ArgumentNullException("heroe");
            }
            heroe.IncreasePower(this.Power);
        }
    }
}
