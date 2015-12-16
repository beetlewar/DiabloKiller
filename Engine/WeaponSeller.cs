﻿using System;
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
            this(hero, null, staticValues, null)
        {
        }

        internal WeaponSeller(
            IHero hero, 
            IRandomizer randomizer,
            IStaticValues staticValues,
            IHeroModifierFactory modifierFactory) :
            base(hero, randomizer, staticValues, modifierFactory)
        {
        }

        public override void Execute()
        {
            this.Hero.TakeCoins(this.StaticValues.WeaponPrice);
            var power = this.Randimozer.RandomizeInt(this.StaticValues.WeaponMinPower, this.StaticValues.WeaponMaxPower);
            var weapon = this.ModifierFactory.CreateWeapon(power);
            this.Hero.AddModifier(weapon);
        }

        public override string ToString()
        {
            return "Покупка оружия";
        }
    }
}
