using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class HeroeModifierFactory : IHeroeModifierFactory
    {
        public IHeroeModifier CreateWeapon(int power)
        {
            return new Weapon(power);
        }
    }
}
