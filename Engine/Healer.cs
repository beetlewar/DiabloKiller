using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Healer : ACommand
    {        
        public Healer(IHero hero, IStaticValues staticValues) :
            this(hero, null, staticValues)
        {
        }

        internal Healer(
            IHero hero, 
            IRandomizer randomizer,
            IStaticValues staticValues) :
            base(hero, randomizer, staticValues, null)
        {
        }

        public override void Execute()
        {
            this.Hero.TakeCoins(this.StaticValues.HealPrice);
            this.Hero.AddHealth(this.StaticValues.HealEffect);
        }

        public override string ToString()
        {
            return "лечение";
        }
    }
}
