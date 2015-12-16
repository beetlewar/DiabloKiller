using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class HeroModifierFactory : IHeroModifierFactory
    {
        public IHeroModifier CreateWeapon(int power)
        {
            return new Weapon(power);
        }

        public IHeroModifier CreateArmor(int health)
        {
            return new Armor(health);
        }
    }
}
