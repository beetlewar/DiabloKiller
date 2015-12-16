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

        public override string Execute()
        {
            this.Hero.TakeCoins(this.StaticValues.HealPrice);
            var prevHealth = this.Hero.Health;
            this.Hero.AddHealth(this.StaticValues.HealEffect);

            return string.Format(
                "Забрали {0} монет, вылечили {1} здоровья", 
                this.StaticValues.HealPrice,
                this.Hero.Health - prevHealth);
        }

        public override string ToString()
        {
            return "Лечение";
        }
    }
}
