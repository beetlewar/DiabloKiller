using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Weapon : IHeroModifier
    {
        public int Power { get; private set; }

        public Weapon(int power)
        {
            this.Power = power;
        }

        public void Modify(IHero hero)
        {
            if(hero == null)
            {
                throw new ArgumentNullException("hero");
            }
            hero.IncreasePower(this.Power);
        }
    }
}
