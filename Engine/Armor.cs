using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Armor : IHeroModifier
    {
        public int Health { get; private set; }

        public Armor(int health)
        {
            this.Health = health;
        }

        public void Modify(IHero hero)
        {
            if (hero == null)
            {
                throw new ArgumentNullException("hero");
            }
            hero.IncreaseMaxHealth(this.Health);
        }
    }
}
