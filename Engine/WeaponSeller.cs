using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Продавец оружия
    /// </summary>
    public class WeaponSeller : ACommand
    {
        public WeaponSeller(IHero hero, IStaticValues staticValues) :
            this(hero, null, staticValues)
        {
        }

        internal WeaponSeller(
            IHero hero, 
            IRandomizer randomizer,
            IStaticValues staticValues) :
            base(hero, randomizer, staticValues)
        {
        }

        public override string Execute()
        {
            this.Hero.TakeCoins(this.StaticValues.WeaponPrice);
            var power = this.Randimozer.RandomizeInt(this.StaticValues.WeaponMinPower, this.StaticValues.WeaponMaxPower);
            this.Hero.IncreasePower(power);

            return string.Format(
                "Забрали {0} монет, добавили {1} мощи",
                this.StaticValues.WeaponPrice,
                power);
        }

        public override string ToString()
        {
            return "Покупка оружия";
        }
    }
}
