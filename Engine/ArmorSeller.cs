using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ArmorSeller : ACommand
    {
        public ArmorSeller(IHero hero, IStaticValues staticValues) :
            this(hero, null, staticValues, null)
        {
        }

        internal ArmorSeller(
            IHero hero, 
            IRandomizer randomizer,
            IStaticValues staticValues,
            IHeroModifierFactory modifierFactory) :
            base(hero, randomizer, staticValues, modifierFactory)
        {

        }

        public override string Execute()
        {
            this.Hero.TakeCoins(this.StaticValues.ArmorPrice);
            var health = this.Randimozer.RandomizeInt(this.StaticValues.ArmorMinHealth, this.StaticValues.ArmorMaxHealth);
            var armor = this.ModifierFactory.CreateArmor(health);
            this.Hero.AddModifier(armor);

            return string.Format(
                "Забрали {0} монет, добавили {1} к максимальному здоровью",
                this.StaticValues.ArmorPrice,
                health);
        }

        public override string ToString()
        {
            return "Покупка одежды";
        }
    }
}
