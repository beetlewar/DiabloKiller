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
        internal IHeroeModifierFactory ModifierFactory { get; private set; }

        public WeaponSeller(IHeroe heroe) :
            this(heroe, null, null, null)
        {
        }

        internal WeaponSeller(
            IHeroe heroe, 
            IRandomizer randomizer,
            IStaticValues staticValues,
            IHeroeModifierFactory modifierFactory) :
            base(heroe, randomizer, staticValues)
        {
            this.ModifierFactory = modifierFactory ?? new HeroeModifierFactory();
        }

        public void Execute()
        {
            this.Heroe.TakeCoins(this.StaticValues.WeaponPrice);
            var power = this.Randimozer.RandomizeInt(this.StaticValues.WeaponMinPower, this.StaticValues.WeaponMaxPower);
            var weapon = this.ModifierFactory.CreateWeapon(power);
            this.Heroe.AddModifier(weapon);
        }
    }
}
